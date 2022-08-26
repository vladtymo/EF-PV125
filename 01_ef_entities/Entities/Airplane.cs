using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_ef_entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassengers { get; set; }

        // -------------- Navigation Properties --------------
        public ICollection<Flight> Flights { get; set; }
    }
}
