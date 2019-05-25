using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data
{
    public class AppDbContext : IdentityDbContext<Employee, Role, int>
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTravel> EmployeeTravel { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Apartment>().HasData(new Apartment[] {
                new Apartment{Id=1, Title="Devbridge Vilnius Apartament", Address="Žalgirio g. 135, Vilnius 08217", FitsPeople=6},
                new Apartment{Id=2, Title="Devbridge Kaunas Apartament", Address="A. Juozapavičiaus pr. 11 D, Kaunas 45252", FitsPeople=6},
                new Apartment{Id=3, Title="Devbridge Chicago Apartament", Address="343 W. Erie St. Suite 600 Chicago, IL 60654", FitsPeople=6},
                new Apartment{Id=4, Title="Devbridge Toronto Apartament", Address="36 Toronto Street Suite 260 Toronto, Ontarion M5C 2C5", FitsPeople=6},
                new Apartment{Id=5, Title="Devbridge London Apartament", Address="8 Devonshire Square London EC2M 4PL", FitsPeople=6}
            });

            
            modelBuilder.Entity<Office>().HasData(new Office[] {
                new Office{
                    Id = 1,
                    OfficeApartmentId = 1,
                    Title = "Devbridge Vilnius",
                    Address = "Žalgirio g. 135, Vilnius 08217"
                },
                new Office{
                    Id = 2,
                    OfficeApartmentId = 2,
                    Title = "Devbridge Kaunas",
                    Address = "A. Juozapavičiaus pr. 11 D, Kaunas 45252"
                },
                new Office{
                    Id = 3,
                    OfficeApartmentId = 3,
                    Title = "Devbridge Chicago",
                    Address = "343 W. Erie St. Suite 600 Chicago, IL 60654"
                },
                new Office{
                    Id = 4,
                    OfficeApartmentId = 4,
                    Title = "Devbridge Toronto",
                    Address = "36 Toronto Street Suite 260 Toronto, Ontarion M5C 2C5"
                },
                new Office{
                    Id = 5,
                    OfficeApartmentId = 5,
                    Title = "Devbridge London",
                    Address = "8 Devonshire Square London EC2M 4PL"
                },
            });

            modelBuilder.Entity<Employee>().HasData(new Employee[] {
                new Employee{
                    Id = 1,
                    UserName = "paulius.grigaliunas.pg@gmail.com",
                    Email = "paulius.grigaliunas.pg@gmail.com",
                    FirstName = "Paulius",
                    LastName = "Grigaliūnas",
                    ProfilePhoto = "https://www.w3schools.com/howto/img_avatar.png",
                    RegisteredOfficeId = 1,
                    Available = true
                },
                new Employee{
                    Id = 2,
                    UserName = "emilija.lamanauskaite@gmail.com",
                    Email = "emilija.lamanauskaite@gmail.com",
                    FirstName = "Emilija",
                    LastName = "Lamanauskaite",
                    ProfilePhoto = "https://www.w3schools.com/howto/img_avatar2.png",
                    RegisteredOfficeId = 1,
                    Available = false
                },
                new Employee{
                    Id = 3,
                    UserName = "elena.reivytyte@gmail.com",
                    Email = "elena.reivytyte@gmail.com",
                    FirstName = "Elena",
                    LastName = "Reivytytė",
                    ProfilePhoto = "https://www.w3schools.com/howto/img_avatar2.png",
                    RegisteredOfficeId = 1,
                    Available = true
                },
                new Employee{
                    Id = 4,
                    UserName = "karolis.staskevicius@gmail.com",
                    Email = "karolis.staskevicius@gmail.com",
                    FirstName = "Karolis",
                    LastName = "Staskevičius",
                    ProfilePhoto = "https://www.w3schools.com/howto/img_avatar.png",
                    RegisteredOfficeId = 2,
                    Available = true
                },
                new Employee{
                    Id = 5,
                    UserName = "tomas.kazlauskas@gmail.com",
                    Email = "tomas.kazlauskas@gmail.com",
                    FirstName = "Tomas",
                    LastName = "Kazlauskas",
                    ProfilePhoto = "https://www.w3schools.com/howto/img_avatar.png",
                    RegisteredOfficeId = 3,
                    Available = true
                },
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
