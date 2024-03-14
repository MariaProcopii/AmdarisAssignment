using AmdarisAssignment3.Model;
namespace AmdarisAssignment3.Service;

public class RideService
{
    private readonly List<Ride> _rides = new List<Ride>();
    
    public Ride? FindRide(int rideId)
    {
        return _rides.FirstOrDefault(r => r.Id == rideId);
    }

    public void CreateRide(string destinationFrom, string destinationTo, User? owner, int availableSeats = 3)
    {
        if (owner is Driver driver)
        {
            var newRide = new Ride
            {
                Id = GenerateNewId(),
                DestinationFrom = destinationFrom,
                DestinationTo = destinationTo,
                AvailableSeats = availableSeats,
                Owner = driver
            };
            _rides.Add(newRide);
            driver.CreatedRides.Add(newRide);
            Console.WriteLine("Ride was created");
        }
        else
        {
            Console.WriteLine("You're not allowed to create a ride");
        }
    }

    public Ride? DeleteRide(int rideId)
    {
        Ride? rideToDelete = FindRide(rideId);
        if (rideToDelete is not null)
        {
            _rides.Remove(rideToDelete);
        }
        
        return rideToDelete;
    }
    
    public void BookRide(User user, int rideId)
    {
        var ride = FindRide(rideId);
        if (ride is not null && user is Passenger)
        {
            if (ride.AvailableSeats > 0)
            {
                (user as Passenger)?.BookRides.Add(ride);
                ride.Passengers.Add(user);
                Console.WriteLine("Ride was booked");
            }
        }
    }

    private int GenerateNewId()
    {
        return _rides.Count != 0 ? _rides.Max(r => r.Id) + 1 : 0;
    }
}
