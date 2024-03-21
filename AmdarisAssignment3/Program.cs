using System.Text.RegularExpressions;
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
        userService.CreateUser("Alex", "p2.example@gmail.com", "Card");
        userService.CreateUser("Anton", "p2.example@gmail.com", "Card");
        userService.CreateUser("Driver1", "d1.example@gmail.com", "Toyota","123AAA");

        var driver = userService.FindUser("d1.example@gmail.com");
        var passenger1 = userService.FindUser("p1.example@gmail.com");
        var passenger2 = userService.FindUser("p2.example@gmail.com");

        rideService.CreateRide(  destinationFrom: "Orhei", owner: driver, destinationTo: "Chisinau", availableSeats: 4);
        rideService.CreateRide(  destinationFrom: "Cahul", owner: driver, destinationTo: "Soroca", availableSeats: 2);
        rideService.CreateRide(  destinationFrom: "Comrat", owner: driver, destinationTo: "Briceni", availableSeats: 1);
        
        rideService.BookRide(passenger1, 0);
        rideService.BookRide(passenger2, 2);
        
        //Exception Handling
        userService.FindUser(10);
        userService.FindAll();
        
        //manipulate collection via delegate
        RideCompare findRideById = FindRideById;
        RideCompare findRideByDestination = FindRideByDestinationTo;
        var ride1 = rideService.FindRide(findRideById, "0");
        var ride2 = rideService.FindRide(findRideByDestination, "Briceni");
        Console.WriteLine(ride1);
        Console.WriteLine(ride2);
        
        //rewrite using anonymous functions
        RideCompare rideById = delegate(Ride ride, string rideId)
        {
            return ride.Id.ToString().Equals(rideId);
        };
        RideCompare rideByDestination = delegate(Ride ride, string destination)
        {
            return ride.DestinationTo.Equals(destination);
        };
        
        var ride3 = rideService.FindRide(rideById, "0");
        var ride4 = rideService.FindRide(rideByDestination, "Briceni");
        Console.WriteLine(ride3);
        Console.WriteLine(ride4);
        
        //rewrite using lambda expressions
        RideCompare rideById1 = (ride, id) => id.Equals(ride.Id.ToString());
        RideCompare rideByDestination1 = (ride, destination) => ride.DestinationTo.Equals(destination);
        var ride5 = rideService.FindRide(rideById1, "0");
        var ride6 = rideService.FindRide(rideByDestination1, "Briceni");
        Console.WriteLine(ride5);
        Console.WriteLine(ride6);
        
        //using extension methods on the collection
        var pattern = @"^A.*";
        userService.FindAll()
                   .Where(user => Regex.IsMatch(user.Name, pattern))
                   .OrderBy(user => user.Name)
                   .ToList()
                   .ForEach(user => user.DisplayInfo());
        
        userService.FindAll()
                   .Select(user => user.Name)
                   .Take(2)
                   .ToList()
                   .ForEach(Console.WriteLine);
    }
}