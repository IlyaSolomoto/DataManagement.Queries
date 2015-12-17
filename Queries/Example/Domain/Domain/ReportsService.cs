using System;
using System.Collections.Generic;
using DataManagement.Queries.Consistency;
using Domain.Entities;
using Domain.Persistance;
using Domain.Queries;

namespace Domain
{
    /// <summary>
    /// Сервис получения данных для отчётов.
    /// </summary>
    /// <remarks>
    /// Содержит по одному методу для каждого отчёта.
    /// Каждому методы соответствует свой Query-класс, объявленный в Domain.Queries.
    /// Параметры каждого метода соответствуют параметрам используемого Query-объекта.
    /// </remarks>
    public class ReportsService
    {
        private readonly IUnitOfWorkProvider<IAppUnitOfWork> _uowProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Поскольку это сервис для построения отчётов, он использует UoW только для чтения данных.
        /// Поэтому сервис использует поставщика uow, который управляет временем жизни UoW на правах владельца.
        /// </remarks>
        /// <param name="uowProvider"></param>
        public ReportsService(IUnitOfWorkProvider<IAppUnitOfWork> uowProvider)
        {
            if (uowProvider == null)
                throw new ArgumentNullException("uowProvider");

            _uowProvider = uowProvider;
        }

        public IEnumerable<City> GetCitiesRateReport(int pageIndex, int itemsPerPage)
        {
            // создание Query с параметрами
            var reportQuery = new CitiesRateReportQuery(pageIndex, itemsPerPage);

            var uow = _uowProvider.GetUnitOfWork();

            // получение данных из uow
            var reportDataPage = reportQuery.Execute(uow);
            return reportDataPage;
        }
    }
}
