using System.Linq;

namespace Persistance.Consistency
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Storage - хранилище доменной модели приложения.
	/// Нет смысла в разбиении сущностей домена по отдельным репозиториям, потому что эти сущности вместе составляют одну единую модель.
	/// Но это вовсе не означает, что сущности должны храниться либо все в СУБД MS, либо все в Xml, либо в Mongo.
	/// 
	/// Данный интерфейс - абстракция Persistance-паттерна. Где конкретно хранить какие сущности решает имплементация.
	/// </remarks>
	public interface IStorage
	{
		IQueryable<T> Queryable<T>() where T : class;

		void Add<T>(T item) where T : class;

		void Update<T>(T item) where T : class;

		void Remove<T>(T item) where T : class;
	}
}
