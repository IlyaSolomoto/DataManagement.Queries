using System.Data.Entity;
using Application.Domain;

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
