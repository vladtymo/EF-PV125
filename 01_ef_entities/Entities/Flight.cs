using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_ef_entities
{
    public class Flight
    {
        [Key] // set primary key
        public int Number { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
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
