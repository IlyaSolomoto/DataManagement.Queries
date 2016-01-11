using System;
using System.Linq;
using Application.Domain;

namespace Application.Persistance
{
	/// <summary>
	/// Unit of Work приложения.
	/// </summary>
	/// <remarks>
	/// Storage - хранилище доменной модели приложения.
	/// Данный интерфейс - абстракция Persistance-паттерна. Где конкретно хранить какие сущности решает имплементация.
	/// </remarks>
	public interface IApplicationStorage : IDisposable
	{
		IQueryable<City> Cities { get; }

		IQueryable<Country> Countries { get; }
	}
}
