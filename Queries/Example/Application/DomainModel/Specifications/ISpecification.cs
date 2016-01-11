namespace Application.Domain.Specifications
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Следуя определению Эванса, спецификация предназначена абстрагировать "что" от "как".
	/// Она используется, чтобы указать (специфицировать), что именно нужно, но не как это получить.
	/// </remarks>
	/// <typeparam name="T"></typeparam>
	public interface ISpecification<in T>
	{
		bool IsSatisfiedBy(T item);
	}
}
