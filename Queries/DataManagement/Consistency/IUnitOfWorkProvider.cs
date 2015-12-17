namespace DataManagement.Queries.Consistency
{
    /// <summary>
    /// Интерфейс поставщика UoW.
    /// </summary>
    /// <remarks>
    /// Предоставляет экземпляр UoW по запросу. 
    /// Управляет временем жизни UoW на правах владельца, т.к. используется для выполнения запросов ЧТЕНИЯ данных.
    /// </remarks>
    /// <typeparam name="TUniOfWork"></typeparam>
    public interface IUnitOfWorkProvider<out TUniOfWork>
    {
        TUniOfWork GetUnitOfWork();
    }
}
