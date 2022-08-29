using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
                {
                    new Airplane()
                    {
                        Id = 1,
                        Model = "Boeing 765",
                        MaxPassengers = 1200
                    }
                }
            );
        }

        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
                {
                    new Flight()
                    {
                        Number = 1,
                        AirplaneId = 1,
                        DepartureCity = "Kyiv",
                        ArrivalCity = "Lviv",
                        DepartureTime = new DateTime(2022, 8, 25, 13, 30, 0),
                        ArrivalTime = new DateTime(2022, 8, 25, 18, 25, 0)
                    },
                    new Flight()
                    {
                        Number = 2,
                        AirplaneId = 1,
                        DepartureCity = "Warsaw",
                        ArrivalCity = "Lviv",
                        DepartureTime = new DateTime(2022, 9, 12, 15, 30, 0),
                        ArrivalTime = new DateTime(2022, 9, 13, 05, 0, 0)
                    }
                }
            );
        }
    }
}
