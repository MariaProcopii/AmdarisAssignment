namespace AmdarisAssignment3.Service;
using Repository;
using Model;

public class RideService
{
    private readonly IRepository<Ride> _rideRepository;

    public RideService(IRepository<Ride> rideRepository)
    {
        _rideRepository = rideRepository;
    }
    
    public Ride? FindRide(int rideId)
    {
        return _rideRepository.GetById(rideId);
    }

    public Ride? FindRide(RideCompare rideCompare, string compareArg)
    {
        foreach(var ride in _rideRepository.GetAll())
        {
            if (rideCompare(ride, compareArg))
            {
                return ride;
            }
        }
        return null;
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
            _rideRepository.Create(newRide);
            driver.CreatedRides.Add(newRide);
            Console.WriteLine("Ride was created");
        }
        else
        {
            Console.WriteLine("You're not allowed to create a ride");
        }
    }

    public void DeleteRide(int rideId)
    {
        _rideRepository.Delete(rideId);
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
                ride.AvailableSeats--;
                Console.WriteLine("Ride was booked");
            }
            else
            {
                Console.WriteLine("No available seats for this ride.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ride or user type.");
        }
    }

    private int GenerateNewId()
    {
        return _rideRepository.GetAll().Count != 0 ? _rideRepository.GetAll().Max(u => u.Id) + 1 : 0;
    }
}
