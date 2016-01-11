using System;
using Application.Persistance;

namespace SqlDataAccess
{
	public class PersistanceController : IPersistanceController
	{
		private readonly string _connectionString;

		public PersistanceController(string connectionString)
		{
			if (connectionString == null)
				throw new ArgumentNullException("connectionString");

			_connectionString = connectionString;
		}

		public IApplicationStorage GetStorage()
		{
			/* Здесь контролируется время жизни контекста данных.
			 * 
			 * Таким образом, контроль времени жизни выполняется в единой точке
			 * и легко может быть вынесен в отдельный модуль, который сможет, например, переиспользовать контекст.
			 */
			return new ApplicationStorage(_connectionString);
		}
	}
}
