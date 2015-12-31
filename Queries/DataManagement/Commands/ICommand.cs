using Persistance.Consistency;

namespace Persistance.Commands
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Команда - это логика по модификации хранилища.
	/// Для абстракции играет роль только тип хранилища, которое
	/// может быть модифицировано путём данной команды.
	/// 
	/// По аналогии с IQuery, хранилище является ресурсом для команды,
	/// а сама команда содержит только алгоритм его модификации.
	/// </remarks>
	/// <typeparam name="TStorage"></typeparam>
	public interface ICommand<in TStorage>
		where TStorage : IStorage
	{
		void Execute(TStorage storage);
	}
}
