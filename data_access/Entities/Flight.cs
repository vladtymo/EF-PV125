using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace data_access
{
    public class Flight
    {
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int? Rating { get; set; }

        // Foreign Key naming: RelatedEntityName+RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }

        // -------------- Navigation Properties --------------

        // Relationship Type: One to Many (1...*)
        public Airplane Airplane { get; set; }

        // Relationship Type: Many to Many (*...*)
        public ICollection<Client> Clients { get; set; }
    }
}
