using System;

namespace DataManagement.Queries.Consistency
{
    /// <summary>
    /// Единица работы.
    /// </summary>
    /// <remarks>
    /// IDisposable - не Leaking abstraction, а поддержка транзакционности.
    /// </remarks>
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
