using Persistance.Consistency;

namespace Persistance
{
	/// <summary>
	/// Запрос извлечения данных из хранилища.
	/// </summary>
	/// <remarks>
	/// Запрос служит для извлечения данных из хранилища.
	/// Для абстракции важны только тип хранилища и тип возвращаемых данных.
	/// 
	/// Сам запрос - это логика (алгоритм) по извлечению данных и ничего более.
	/// Сами данные, как и хранилище, из которого они извлекаются, - это ресурсы для запроса.
	/// </remarks>
	/// <typeparam name="TStorage"></typeparam>
	/// <typeparam name="TResult"></typeparam>
	public interface IQuery<in TStorage, out TResult>
		where TStorage : IStorage
	{
		TResult Fetch(TStorage storage);
	}
}
