using System;
using System.Collections.Generic;
using System.Linq;
using Application.Domain;
using Application.Domain.Specifications;
using Queries;

namespace Application.Queries
{
	/// <summary>
	/// Запрос данных отчёта "рейтинг городов".
	/// </summary>
	/// <remarks>
	/// Application layer не использует напрямую Query'2, вместо этого создаются и используются потомки,
	/// в которых содержатся запросы извлечения данных.
	/// Это позволит избежать бесконтрольного использования Query и сделает возможным
	/// тестирование запросов в изоляции от другой бизнес-логики (и на тестовых данных).
	/// </remarks>
	public class CitiesRateReportQuery : Query<City, Country, IEnumerable<City>>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Конструктор принимает те же параметры, что и Select-метод.
		/// </remarks>
		/// <param name="pageIndex"></param>
		/// <param name="itemsPerPage"></param>
		public CitiesRateReportQuery(int pageIndex, int itemsPerPage)
			: base(Select(pageIndex, itemsPerPage)) // создаёт делегат с помощью фабрики и передаёт его в base.ctor
		{
		}

		/// <summary>
		/// Метод-фабрика, создающий делегат для Query с использованием переданных параметров.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="itemsPerPage"></param>
		/// <returns></returns>
		private static Func<IQueryable<City>, IQueryable<Country>, IEnumerable<City>> Select(int pageIndex, int itemsPerPage)
		{
			var bestCountrySpecification = new BestCountrySpecification();

			Func<IQueryable<City>, IQueryable<Country>, IEnumerable<City>> selector = (cities, countries) =>
				countries
				.Where(c => bestCountrySpecification.IsSatisfiedBy(c))
				.SelectMany(c => c.Cities)
				.OrderBy(c => c.BlackPeopleRate)
				.Skip(pageIndex * itemsPerPage)
				.Take(itemsPerPage)
				.ToList();

			return selector;
		}
	}
}
