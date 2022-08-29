using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace data_access
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
