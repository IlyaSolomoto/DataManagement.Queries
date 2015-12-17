using System;
using DataManagement.Queries.Consistency;

namespace DataManagement.Queries
{
    /// <summary>
    /// Запрос извлечения данных из UoW.
    /// </summary>
    /// <remarks>
    /// Контейнер для делегата Func'2, служащего для извлечения данных из UoW.
    /// </remarks>
    /// <typeparam name="TUnitOfWork"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class Query<TUnitOfWork, TResult> : IQuery<TUnitOfWork, TResult>
        where TUnitOfWork : IUnitOfWork
    {
        private readonly Func<TUnitOfWork, TResult> _select;

        public Query(Func<TUnitOfWork, TResult> select)
        {
            if (select == null)
                throw new ArgumentNullException("select");

            _select = select;
        }

        public TResult Execute(TUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            var selectedData = _select(unitOfWork);

            return selectedData;
        }
    }
}
