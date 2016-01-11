using System;
using System.Linq;

namespace Queries
{
	public class Query<TItem, TResult> : IQuery<TItem, TResult>
	{
		private readonly Func<IQueryable<TItem>, TResult> _query;

		public Query(Func<IQueryable<TItem>, TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException("query");

			_query = query;
		}

		public TResult Fetch(IQueryable<TItem> items)
		{
			if (items == null)
				throw new ArgumentNullException("items");

			var selectedData = _query(items);

			return selectedData;
		}
	}

	public class Query<TItem1, TItem2, TResult> : IQuery<TItem1, TItem2, TResult>
	{
		private readonly Func<IQueryable<TItem1>, IQueryable<TItem2>, TResult> _query;

		public Query(Func<IQueryable<TItem1>, IQueryable<TItem2>, TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException("query");

			_query = query;
		}

		public TResult Fetch(IQueryable<TItem1> items1, IQueryable<TItem2> items2)
		{
			if (items1 == null)
				throw new ArgumentNullException("items1");

			if (items2 == null)
				throw new ArgumentNullException("items2");

			var selectedData = _query(items1, items2);

			return selectedData;
		}
	}
}
