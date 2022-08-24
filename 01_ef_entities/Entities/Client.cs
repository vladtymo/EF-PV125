using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_ef_entities
{
    //////////////// Entities
    [Table("Passengers")] // set table name
    public class Client
    {
        // Primary Key naming: Id/id/ID EntityName+Id
        public int Id { get; set; }

        [Required]              // not null
        [MaxLength(100)]        // nvarchar(100)
        [Column("FirstName")]   // set column name
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        public DateTime? Birthdate { get; set; }

        // -------------- Navigation Properties --------------
        public ICollection<Flight> Flights { get; set; }
    }
}
