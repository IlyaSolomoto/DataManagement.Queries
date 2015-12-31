using System.Data.Entity;
using System.Linq;
using Persistance.Consistency;

namespace SqlDataAccess
{
	public class Storage : IStorage
	{
		private readonly AppDbContext _dbContext;

		internal Storage(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<T> Queryable<T>() where T : class
		{
			return _dbContext.Set<T>()
				.AsNoTracking();
		}

		public void Add<T>(T item) where T : class
		{
			_dbContext.Set<T>().Add(item);
		}

		public void Update<T>(T item) where T : class
		{
			_dbContext.Entry(item).State = EntityState.Modified;
		}

		public void Remove<T>(T item) where T : class
		{
			_dbContext.Set<T>().Remove(item);
		}
	}
}
