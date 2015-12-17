using System.Collections.Generic;

namespace Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Поддержка гомосексуализма на законодательном уровне.
        /// </summary>
        public bool HomosectualizmAllowed { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
