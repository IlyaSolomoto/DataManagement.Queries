namespace Application.Domain
{
	public class City
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Country Country { get; set; }

		/// <summary>
		/// Процент чёрных.
		/// </summary>
		public float BlackPeopleRate { get; set; }
	}
}
