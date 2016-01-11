using System;

namespace Application.Domain.Specifications
{
	public class GenericSpecification<T> : ISpecification<T>
	{
		private readonly Func<T, bool> _predicate;

		public GenericSpecification(Func<T, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException("predicate");

			_predicate = predicate;
		}

		public bool IsSatisfiedBy(T item)
		{
			return _predicate(item);
		}
	}
}
