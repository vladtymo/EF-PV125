using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_access
{
    //////////////// Entities
    public class Client
    {
        // Primary Key naming: Id/id/ID EntityName+Id
        //public int Id { get; set; }
        public int CredentialsId { get; set; } // foreign and primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }

        // -------------- Navigation Properties --------------
        public ICollection<Flight> Flights { get; set; }
        public Credentials Credentials { get; set; }
    }
}
