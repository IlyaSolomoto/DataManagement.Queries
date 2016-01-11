using System;
using System.Collections.Generic;
using Application.Domain;
using Application.Persistance;
using Application.Queries;

namespace Application
{
	/// <summary>
	/// 
	/// </summary>
	public class ReportsService
	{
		private readonly IPersistanceController _persistanceController;

		public ReportsService(IPersistanceController persistanceController)
		{
			if (persistanceController == null)
				throw new ArgumentNullException("persistanceController");

			_persistanceController = persistanceController;
		}

		public IEnumerable<City> GetCitiesReport(int pageIndex, int itemsPerPage)
		{
			/* Query - это "как получать данные".
			 * Specification - это "что именно получать".
			 * Конкретный класс query внутри может использовать любые спецификации
			 * 
			 * Но что где должно находиться?
			 * Спецификации контролируют инварианты элементов доменной модели, значит им место в DomainModel.
			 * 
			 * Но вот Query предназначены инкапсулировать в себе способ извлечения данных из хранилища на основе спецификаций.
			 * Т.е. Query использует Persistance-шаблон. А поскольку Persistance-шаблон выходит за рамки DomainModel (доменная модель не должна знать,
			 * где и в каких состояниях она хранится), Query тоже не место в DomainModel.
			 * 
			 * Необходим третий слой - Application, который будет связывать доменную модель с Persistance-шаблоном.
			 * Именно здесь и должны располагаться Query-типы.
			 */

			/* Query - это "как получать данные". Query "умеет" (знает как) извлекать данные из IQueryable-коллекций.
			 * 
			 * Чтобы извлечь данные, нужно "дать" Query IQueryable-коллекции, и попросить её "найти" в них всё необходимое.
			 */
			var query = new CitiesRateReportQuery(pageIndex, itemsPerPage);

			using (var storage = _persistanceController.GetStorage()) // storage - это unit of work
			{
				// просим Query извлечь данные из наших IQueryable-коллекций
				var fetchedData = query.Fetch(storage.Cities, storage.Countries);

				/* P.S. объединение query в цепочку возможно при использовании Query<..., IQueryable<...>>, т.е. TResult такой Query - это IQueryable-коллекция,
				 * которая затем может использовать другой Query.
				 */

				return fetchedData;
			}
		}
	}
}
