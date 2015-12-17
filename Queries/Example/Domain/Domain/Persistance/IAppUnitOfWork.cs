using System.Linq;
using DataManagement.Queries.Consistency;
using Domain.Entities;

namespace Domain.Persistance
{
    /// <summary>
    /// Единица работы приложения.
    /// </summary>
    /// <remarks>
    /// Предоставляет набор разнородных данных в виде IQueryable-коллекций.
    /// Таким образом данные рассматриваются как единое целое.
    /// В комбинации с Query позволяет выполнять любые запросы на извлечение данных,
    /// используя все возможности LINQ.
    /// </remarks>
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IQueryable<Country> Countries { get; }

        IQueryable<City> Cities { get; }
    }
}
