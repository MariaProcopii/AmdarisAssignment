using System.Text.RegularExpressions;
using AmdarisAssignment3;


using AmdarisAssignment3.Model;
using AmdarisAssignment3.Service;
using AmdarisAssignment3.Repository;

public delegate bool RideCompare(Ride ride, string comparisonArg);

public class Program
{
    public static bool FindRideById(Ride ride, string rideId)
    {
        return ride.Id.ToString().Equals(rideId);
    }
    
    public static bool FindRideByDestinationTo(Ride ride, string destination)
    {
        return ride.DestinationTo.Equals(destination);
    }

    public static void Main(string[] args)
    {

        var rideService = new RideService(new InMemoryRepository<Ride>());
        var userService = new UserService(new InMemoryRepository<User>());

        userService.CreateUser("Ana", "p1.example@gmail.com", "Card");
        userService.CreateUser("Maria", "p2.example@gmail.com", "Card");
        userService.CreateUser("Maria", "p2.example@gmail.com", "Card");
        userService.CreateUser("Ana", "p2.example@gmail.com", "Card");
        userService.CreateUser("Driver1", "d1.example@gmail.com", "Toyota", "123AAA");

        var driver = userService.FindUser("d1.example@gmail.com");
        var passenger1 = userService.FindUser("p1.example@gmail.com");
        var passenger2 = userService.FindUser("p2.example@gmail.com");

        rideService.CreateRide(destinationFrom: "Orhei", owner: driver, destinationTo: "Chisinau", availableSeats: 4);
        rideService.CreateRide(destinationFrom: "Cahul", owner: driver, destinationTo: "Soroca", availableSeats: 2);
        rideService.CreateRide(destinationFrom: "Comrat", owner: driver, destinationTo: "Briceni", availableSeats: 1);

        rideService.BookRide(passenger1, 0);
        rideService.BookRide(passenger2, 0);
        rideService.BookRide(passenger2, 2);

        //Filtering Operators
        var pattern = @"^A.*";
        var enumerable1 = userService.FindAll().Where(user => Regex.IsMatch(user.Name, pattern));
        var enumerable2 = userService.FindAll().OfType<Passenger>();

        //Join Operators
        var enumerable3 = userService.FindAll().Join(rideService.FindAll(),
            user => user,
            ride => ride.Owner,
            (user, ride) => new
            {
                UserName = user.Name,
                RideDestination = ride.DestinationTo
            });
        var enumerable4 = userService.FindAll().GroupJoin(rideService.FindAll(),
            user => user,
            ride => ride.Owner,
            (user, rides) => new
            {
                UserName = user.Name,
                Rides = rides.Select(ride => ride).ToList()
            });

        var enumerable5 = rideService.FindAll().Zip(rideService.FindAll(), (desTo, desFrom) => new
        {
            desTo.DestinationTo, desFrom.DestinationFrom
        });
        
        //Projection Operators
        var enumerable6 = rideService.FindAll().Select(ride => ride.DestinationFrom);
        var enumerable7 = rideService.FindAll().SelectMany(ride => ride.Passengers);

        //Sorting Operators
        var enumerable8 = userService.FindAll().OrderBy(user => user.Id).ThenBy(user => user.Name);
        var enumerable9 = userService.FindAll().OrderByDescending(user => user.Id).ThenByDescending(user => user.Name);
        userService.FindAll().Reverse();

        //Grouping Operators
        var enumerable10 = userService.FindAll().GroupBy(user => user.Name);
        var enumerable11 = userService.FindAll().ToLookup(user => user.Name);

        //Conversion Operators
        var enumerable12 = rideService.FindAll().Select(ride => ride.Owner).Cast<Driver>();
        var enumerable13 = userService.FindAll().Select(user => user.Id).ToList();
        var enumerable14 = userService.FindAll().Select(user => user.Id).ToArray();
        var enumerable15 = userService.FindAll().ToDictionary(user => user.Id, user => user.Name);

        //Concatenation Operations
        var enumerable16 = userService.FindAll().Concat<Entity>(rideService.FindAll());
        
        //Aggregation Operations
        var enumerable17 = rideService.FindAll().Select(ride => ride.AvailableSeats).Average();
        var enumerable18 = rideService.FindAll().Count();
        var enumerable19 = rideService.FindAll().Select(ride => ride.AvailableSeats).Max();
        var enumerable20 = rideService.FindAll().Select(ride => ride.AvailableSeats).Min();
        var enumerable21 = rideService.FindAll().MinBy(ride => ride.AvailableSeats);
        var enumerable22 = rideService.FindAll().MaxBy(ride => ride.AvailableSeats);
        var enumerable23 = rideService.FindAll().Select(ride => ride.AvailableSeats).Sum();
        var enumerable24 = rideService.FindAll().Select(ride => ride.AvailableSeats).Aggregate((x, y) => x - y);
        
        //Quantifier Operations
        var enumerable25 = userService.FindAll().Any(user => user is Passenger);
        var enumerable26 = userService.FindAll().All(user => user is Passenger);
        var enumerable27 = userService.FindAll().Contains(passenger1);
        
        //Partition Operators
        var enumerable28 = userService.FindAll().Skip(2);
        var enumerable29 = userService.FindAll().SkipWhile(user => user.Id < 1);
        var enumerable30 = userService.FindAll().Take(2);
        var enumerable31 = userService.FindAll().TakeWhile(user => user.Id < 1);
        
        //Generation Operations
        var enumerable32 = userService.FindAll().Where(user => user.Name == "Random").DefaultIfEmpty();
        var enumerable33 = Enumerable.Empty<User>();
        var enumerable34 = Enumerable.Range(1, 5).Select(id => new { Id = id, Name = $"Human {id}" });
        var enumerable35 = Enumerable.Repeat(driver, 5);
        
        //Set Operations
        var enumerable36 = userService.FindAll()
                                                .Where(u => u.Name is "Ana" or "Maria")
                                                .DistinctBy(u => u.Name)
                                                .ToList();
        
        var enumerable37 = userService.FindAll().Except(enumerable36);
        var enumerable38 = userService.FindAll().Intersect(enumerable36);
        var enumerable39 = enumerable37.Union(enumerable36).ToList();
        
        //Equality Operations
        var enumerable40 = userService.FindAll().SequenceEqual(enumerable39); 
        
        //Element Operators
        var enumerable41 = enumerable39.ElementAt(0);
        var enumerable42 = enumerable39.ElementAtOrDefault(10);
        var enumerable43 = userService.FindAll().First(u => u.Name == "Ana");
        var enumerable44 = userService.FindAll().FirstOrDefault(u => u.Name == "Ana");
        var enumerable45 = userService.FindAll().Last(u => u.Name == "Ana");
        var enumerable46 = userService.FindAll().LastOrDefault(u => u.Name == "Ana");
        var enumerable47 = userService.FindAll().Single(u => u.Name == "Driver1");
        var enumerable48 = userService.FindAll().SingleOrDefault(u => u.Name == "Maria");
    }
}