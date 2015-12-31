using System;
using System.Collections.Generic;
using Application.Queries;
using Domain.Entities;
using Persistance;
using Persistance.Consistency;

namespace Application
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	public class ReportsService
	{
		private readonly IPersistanceController<IStorage> _persistanceController;

		public ReportsService(IPersistanceController<IStorage> persistanceController)
		{
			if (persistanceController == null)
				throw new ArgumentNullException("persistanceController");

			_persistanceController = persistanceController;
		}

		public IEnumerable<City> GetCitiesReport(int pageIndex, int itemsPerPage)
		{
			var query = new CitiesRateReportQuery(pageIndex, itemsPerPage);

			var reportDataPage = _persistanceController.FetchData(query);

			return reportDataPage;
		}
	}
}
