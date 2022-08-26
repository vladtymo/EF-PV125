using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_ef_entities
{
    //////////////// Entities
    public class Client
    {
        // Primary Key naming: Id/id/ID EntityName+Id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }

        // -------------- Navigation Properties --------------
        public ICollection<Flight> Flights { get; set; }
    }
}
