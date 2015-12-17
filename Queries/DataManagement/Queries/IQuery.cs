using DataManagement.Queries.Consistency;

namespace DataManagement.Queries
{
    /// <summary>
    /// Запрос извлечения данных из UoW.
    /// </summary>
    /// <typeparam name="TUnitOfWork"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IQuery<in TUnitOfWork, out TResult>
        where TUnitOfWork : IUnitOfWork
    {
        TResult Execute(TUnitOfWork unitOfWork);
    }
}
