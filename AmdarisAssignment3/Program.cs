namespace AmdarisAssignment3;
using System.Text.RegularExpressions;
using Model;
using Service;
using Repository;
using Logger;

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

    public static async Task Main(string[] args)
    {
        const string logDirectory = "Logger";
        var logger = new FileLogger(logDirectory);
        var rideService = new RideService(new InMemoryRepository<Ride>(), logger);
        var userService = new UserService(new InMemoryRepository<User>(), logger);
        await DoSomething().ConfigureAwait(true);
        await userService.CreateUser("Ana", "p1.example@gmail.com", "Card");
        await userService.CreateUser("Maria", "p2.example@gmail.com", "Card");
        await userService.CreateUser("Maria", "p2.example@gmail.com", "Card");
        await userService.CreateUser("Ana", "p2.example@gmail.com", "Card");
        await userService.CreateUser("Driver1", "d1.example@gmail.com", "Toyota", "123AAA");

        var driver = await userService.FindUser("d1.example@gmail.com");
        var passenger1 = await userService.FindUser("p1.example@gmail.com");
        var passenger2 = await userService.FindUser("p2.example@gmail.com");

        await rideService.CreateRide(destinationFrom: "Orhei", owner: driver, destinationTo: "Chisinau", availableSeats: 4);
        await rideService.CreateRide(destinationFrom: "Cahul", owner: driver, destinationTo: "Soroca", availableSeats: 2);
        await rideService.CreateRide(destinationFrom: "Comrat", owner: driver, destinationTo: "Briceni", availableSeats: 1);

        await rideService.BookRide(passenger1, 0);
        await rideService.BookRide(passenger2, 0);
        await rideService.BookRide(passenger2, 2);
    }

    private static Task DoSomething()
    {
        return Task.Run(() => { Console.WriteLine("ll"); });
    }
}