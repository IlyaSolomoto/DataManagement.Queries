using System.Data.Entity;
using Domain.Entities;

namespace SqlDataAccess
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
