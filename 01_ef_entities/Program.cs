using System;
using System.Linq;

namespace _01_ef_entities
{
    class Program
    {
        static void Main(string[] args)
        {
            AirlinesDbContext context = new AirlinesDbContext();

            ////////////////////// LINQ to Entities

            // Read data
            var flights = context.Flights.Where(f => f.ArrivalCity == "Lviv").OrderBy(f => f.DepartureTime);

            foreach (var f in flights)
            {
                Console.WriteLine($"Flight #{f.Number}: from {f.DepartureCity} ({f.DepartureTime}) to {f.ArrivalCity} ({f.ArrivalTime})");
            }

            foreach (var c in context.Clients)
            {
                Console.WriteLine($"Client [{c.Id}] {c.Name} {c.Email} {c.Birthdate?.ToShortDateString()}");
            }

            // Insert data
            context.Clients.Add(new Client
            {
                Name = "Volodia",
                Birthdate = new DateTime(2006, 7, 3),
                Email = "blabla@gmail.com"
            });

            context.SaveChanges();

            // Find data
            var client = context.Clients.Find(1);

            // Delete data
            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }
    }
}
