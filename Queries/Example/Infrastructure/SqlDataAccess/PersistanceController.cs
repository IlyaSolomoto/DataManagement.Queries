using System;
using Persistance;
using Persistance.Commands;
using Persistance.Consistency;

namespace SqlDataAccess
{
	public class PersistanceController : IPersistanceController<IStorage>
	{
		private readonly string _connectionString;

		public PersistanceController(string connectionString)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			_connectionString = connectionString;
		}

		public void ExecuteTransactional(ICommand<IStorage> command)
		{
			using (var dbcontext = new AppDbContext(_connectionString)) // транзакционность при модификации данных
			{
				var storage = new Storage(dbcontext);

				command.Execute(storage);

				dbcontext.SaveChanges();
			}
		}

		public TResult FetchData<TResult>(IQuery<IStorage, TResult> query)
		{
			/* Здесь контролируется время жизни контекста данных.
			 * 
			 * Таким образом, контроль времени жизни выполняется в единой точке
			 * и легко может быть вынесен в отдельный модуль, который сможет, например, переиспользовать контекст.
			 */
			using (var dbcontext = new AppDbContext(_connectionString))
			{
				var storage = new Storage(dbcontext);

				return query.Fetch(storage);

				// не используется SaveChanges() - query не может модифиировать данные
			}
		}
	}
}
