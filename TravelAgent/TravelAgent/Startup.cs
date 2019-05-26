using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Threading.Tasks;
using TravelAgent.Data;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories;
using TravelAgent.Data.Repositories.Interfaces;

namespace TravelAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Travel Agent API", Version = "v1" });
            });

            // Duombazë
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TodosConnection")));

            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeTravelRepository, EmployeeTravelRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<ITransportRepository, TransportRepository>();
            services.AddScoped<ITravelRepository, TravelRepository>();    

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            //Autentifikacija SingUp
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

            services.AddIdentity<Employee, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 3;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            //Autentifikacija LogIn
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;

                options.Events.OnRedirectToLogin = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api")
                        && context.Response.StatusCode == StatusCodes.Status200OK)
                    {
                        context.Response.Clear();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.FromResult<object>(null);
                    }
                    context.Response.Redirect(context.RedirectUri);
                    return Task.FromResult<object>(null);
                };

                options.Events.OnRedirectToLogout = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api")
                        && context.Response.StatusCode == StatusCodes.Status200OK)
                    {
                        context.Response.Clear();
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return Task.FromResult<object>(null);
                    }
                    context.Response.Redirect(context.RedirectUri);
                    return Task.FromResult<object>(null);
                };

                options.Events.OnRedirectToAccessDenied = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api")
                        && context.Response.StatusCode == StatusCodes.Status200OK)
                    {
                        context.Response.Clear();
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return Task.FromResult<object>(null);
                    }
                    context.Response.Redirect(context.RedirectUri);
                    return Task.FromResult<object>(null);
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();
            app.UseCors("authPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
