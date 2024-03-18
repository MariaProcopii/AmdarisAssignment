using AmdarisAssignment3.Model;
using AmdarisAssignment3.Service;
using AmdarisAssignment3.Repository;

var rideService = new RideService(new InMemoryRepository<Ride>());
var userService = new UserService(new InMemoryRepository<User>());

userService.CreateUser("Passenger1", "p1.example@gmail.com", "Card");
userService.CreateUser("Passenger2", "p2.example@gmail.com", "Card");
userService.CreateUser("Driver1", "d1.example@gmail.com", "Toyota","123AAA");

var driver = userService.FindUser("d1.example@gmail.com");
var passenger1 = userService.FindUser("p1.example@gmail.com");
var passenger2 = userService.FindUser("p2.example@gmail.com");

rideService.CreateRide(  "Comrat", owner: driver, destinationTo: "Chisinau", availableSeats: 1);
rideService.CreateRide(  "Cahul", owner: driver, destinationTo: "Chisinau");

rideService.BookRide(passenger1, 1);
rideService.BookRide(passenger2, 1);

var ride1 = rideService.FindRide(1);
var ride2 = ride1.Clone();

Console.WriteLine(ride1 == ride2); // IClonable

Console.WriteLine("Passengers in the ride:");
foreach (var passenger in ride1)
{
    Console.WriteLine("User " + passenger.Name + " is in the ride."); //IEnumerable
}

