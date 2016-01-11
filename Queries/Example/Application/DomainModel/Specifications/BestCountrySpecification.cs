namespace Application.Domain.Specifications
{
	public class BestCountrySpecification : ISpecification<Country>
	{
		public bool IsSatisfiedBy(Country item)
		{
			return !item.HomosectualizmAllowed;
		}
	}
}
