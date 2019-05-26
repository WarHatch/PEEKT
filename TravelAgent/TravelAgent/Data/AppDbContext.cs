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
            /*
            modelBuilder.Entity<Apartment>().HasData(new Apartment[] {
                new Apartment{Id=1, Title="Devbridge Vilnius Apartament", Address="Žalgirio g. 135, Vilnius 08217", FitsPeople=6},
                new Apartment{Id=2, Title="Devbridge Kaunas Apartament", Address="A. Juozapavičiaus pr. 11 D, Kaunas 45252", FitsPeople=6},
                new Apartment{Id=3, Title="Devbridge Chicago Apartament", Address="343 W. Erie St. Suite 600 Chicago, IL 60654", FitsPeople=6},
                new Apartment{Id=4, Title="Devbridge Toronto Apartament", Address="36 Toronto Street Suite 260 Toronto, Ontarion M5C 2C5", FitsPeople=6},
                new Apartment{Id=5, Title="Devbridge London Apartament", Address="8 Devonshire Square London EC2M 4PL", FitsPeople=6},
            });*/
            modelBuilder.Entity<Office>().HasData(new Office[] {
                new Office{
                    Id =1,
                    OfficeApartment = new Apartment {
                        Id = 1,
                        Title = "Devbridge Vilnius Apartament",
                        Address = "Žalgirio g. 135, Vilnius 08217",
                        FitsPeople = 6
                    },
                    Title = "Devbridge Vilnius",
                    Address = "Žalgirio g. 135, Vilnius 08217"
                },
                new Office{
                    Id = 2,
                    OfficeApartment = new Apartment{
                        Id = 2,
                        Title = "Devbridge Kaunas Apartament",
                        Address = "A. Juozapavičiaus pr. 11 D, Kaunas 45252",
                        FitsPeople = 6
                    },
                    Title = "Devbridge Kaunas",
                    Address = "A. Juozapavičiaus pr. 11 D, Kaunas 45252"
                },
                new Office{
                    Id = 3,
                    OfficeApartment = new Apartment{
                        Id = 3,
                        Title = "Devbridge Chicago Apartament",
                        Address = "343 W. Erie St. Suite 600 Chicago, IL 60654",
                        FitsPeople = 6
                    },
                    Title = "Devbridge Chicago",
                    Address = "343 W. Erie St. Suite 600 Chicago, IL 60654"
                },
                new Office{
                    Id = 4,
                    OfficeApartment = new Apartment{
                        Id = 4,
                        Title = "Devbridge Toronto Apartament",
                        Address = "36 Toronto Street Suite 260 Toronto, Ontarion M5C 2C5", FitsPeople = 6
                    },
                    Title = "Devbridge Toronto",
                    Address = "36 Toronto Street Suite 260 Toronto, Ontarion M5C 2C5"
                },
                new Office{
                    Id = 5,
                    OfficeApartment = new Apartment{
                        Id = 5,
                        Title = "Devbridge London Apartament",
                        Address = "8 Devonshire Square London EC2M 4PL",
                        FitsPeople = 6
                    },
                    Title = "Devbridge London",
                    Address = "8 Devonshire Square London EC2M 4PL"
                },
            });



            base.OnModelCreating(modelBuilder);
        }
    }
}
