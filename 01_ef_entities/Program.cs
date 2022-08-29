using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace data_access
{
    class Program
    {
        static void Main(string[] args)
        {
            AirlinesDbContext context = new AirlinesDbContext();

            ////////////////////// LINQ to Entities

            // Read data
            //foreach (var c in context.Clients)
            //{
            //    Console.WriteLine($"Client [{c.Id}] {c.Name} {c.Email} {c.Birthdate?.ToShortDateString()}");
            //}

            // Eager data loading: Include(relation data)
            var flights = context.Flights
                .Include(f => f.Airplane) // like JOIN operator in SQL
                .Include(f => f.Clients)
                .OrderBy(f => f.DepartureTime);

            foreach (var f in flights)
            {
                Console.WriteLine(
                    $"Flight #{f.Number}: from {f.DepartureCity} ({f.DepartureTime}) to {f.ArrivalCity} ({f.ArrivalTime})" +
                    $" - airplane: {f.Airplane?.Model}" +
                    $" - with {f.Clients?.Count} passengers.");
            }

            // Find data
            var client = context.Clients.Find(2);

            // Explicit data loading: Context.Entry(entity).Colleciton/Reference().Load();
            context.Entry(client).Collection(c => c.Flights).Load();

            Console.WriteLine($"Client {client.Name} has {client.Flights?.Count} flights!"); 

            // Insert data
            //context.Clients.Add(new Client
            //{
            //    Name = "Volodia",
            //    Birthdate = new DateTime(2006, 7, 3),
            //    Email = "blabla@gmail.com"
            //});

            //context.SaveChanges();

            // Delete data
            //if (client != null)
            //{
            //    context.Clients.Remove(client);
            //    context.SaveChanges();
            //}
        }
    }
}
