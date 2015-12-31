using Persistance.Commands;
using Persistance.Consistency;

namespace Persistance
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Persistance-контроллер дополняет собой абстракцию хранилища.
	/// Хранилище даёт доступ к коллекциям объектов и его использование напрямую было бы небезопасным.
	/// 
	/// Persistance-контроллер служит для контроля доступа к хранилищу.
	/// Он контролирует согласованность данных, поддерживая транзакционность при модификации хранилища,
	/// а так же контролирует неизменность хранилища при выполнении query.
	/// </remarks>
	/// <typeparam name="TStorage"></typeparam>
	public interface IPersistanceController<out TStorage>
		where TStorage : IStorage
	{
		void ExecuteTransactional(ICommand<TStorage> command);

		TResult FetchData<TResult>(IQuery<TStorage, TResult> query);
	}
}
