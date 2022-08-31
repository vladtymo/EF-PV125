using data_access.Repositories;

namespace data_access
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Flight> flightRepo = new Repository<Flight>(new AirlinesDbContext());

            foreach (var f in flightRepo.GetAll())
            {
                Console.WriteLine(
                    $"Flight #{f.Number}: from {f.DepartureCity} ({f.DepartureTime}) to {f.ArrivalCity} ({f.ArrivalTime})" +
                    $" - airplane: {f.Airplane?.Model}" +
                    $" - with {f.Clients?.Count} passengers.");
            }

            flightRepo.GetAll();
        }
    }
}