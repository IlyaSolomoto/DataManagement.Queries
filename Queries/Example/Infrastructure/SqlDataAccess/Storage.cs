using System;
using System.Linq;
using Application.Domain;
using Application.Persistance;

namespace SqlDataAccess
{
	public class ApplicationStorage : IApplicationStorage
	{
		private readonly AppDbContext _dbContext;

		internal ApplicationStorage(string sqlConnectionString)
		{
			if (sqlConnectionString == null)
				throw new ArgumentNullException("sqlConnectionString");

			_dbContext = new AppDbContext(sqlConnectionString);
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}

		public IQueryable<City> Cities
		{
			get { return _dbContext.Set<City>(); }
		}

		public IQueryable<Country> Countries
		{
			get { return _dbContext.Set<Country>(); }
		}
	}
}
