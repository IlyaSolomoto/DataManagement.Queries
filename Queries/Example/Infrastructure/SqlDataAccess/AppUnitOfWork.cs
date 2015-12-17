using System.Linq;
using Domain.Entities;
using Domain.Persistance;

namespace SqlDataAccess
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public AppUnitOfWork(string connectionString)
        {
            _dbContext = new AppDbContext(connectionString);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public IQueryable<Country> Countries
        {
            get
            {
                return _dbContext.Countries
                    .AsNoTracking(); // для Queries и disconnected-сценария EF AsNoTracking сильно сокращает время выполнения запросов
            }
        }

        public IQueryable<City> Cities
        {
            get
            {
                return _dbContext.Cities
                    .AsNoTracking();
            }
        }
    }
}
