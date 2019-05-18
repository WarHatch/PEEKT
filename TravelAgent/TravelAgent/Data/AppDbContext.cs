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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<TravelerTransport> TravelerTransports { get; set; }
    }
}
