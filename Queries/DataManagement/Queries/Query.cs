using System;
using Persistance.Consistency;

namespace Persistance
{
	public class Query<TStorage, TResult> : IQuery<TStorage, TResult>
		where TStorage : IStorage
	{
		private readonly Func<TStorage, TResult> _query;

		public Query(Func<TStorage, TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException("query");

			_query = query;
		}

		public TResult Fetch(TStorage storage)
		{
			if (storage == null)
				throw new ArgumentNullException("storage");

			var selectedData = _query(storage);

			return selectedData;
		}
	}
}
