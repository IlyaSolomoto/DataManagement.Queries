using System.Linq;

namespace Queries
{
	/// <summary>
	/// Query абстрагирует способ извлечения данных.
	/// </summary>
	/// <remarks>
	/// Сам запрос - это логика (алгоритм) по извлечению данных и ничего более.
	/// Сами данные - это ресурсы для запроса.
	/// </remarks>
	/// <typeparam name="TItem"></typeparam>
	/// <typeparam name="TResult"></typeparam>
	public interface IQuery<in TItem, out TResult>
	{
		TResult Fetch(IQueryable<TItem> items);
	}

	public interface IQuery<in TItem1, in TItem2, out TResult>
	{
		TResult Fetch(IQueryable<TItem1> items1, IQueryable<TItem2> items2);
	}

	public interface IQuery<in TItem1, in TItem2, in TItem3, out TResult>
	{
		TResult Fetch(IQueryable<TItem1> items1, IQueryable<TItem2> items2, IQueryable<TItem3> items3);
	}
}
