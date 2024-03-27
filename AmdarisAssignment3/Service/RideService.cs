namespace AmdarisAssignment3.Service;
using Repository;
using Model;
using Logger;
using Exceptions;

public class RideService
{
    private readonly IRepository<Ride> _rideRepository;
    private readonly FileLogger _logger;

    public RideService(IRepository<Ride> rideRepository, FileLogger logger)
    {
        _rideRepository = rideRepository;
        _logger = logger;
    }
    
    public async Task<Ride?> FindRide(int rideId)
    {
        Ride? ride = null;
        try
        {
            ride = _rideRepository.GetById(rideId);
            await _logger.LogMessage(nameof(FindRide), "Success");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(FindRide), "Failure");
            throw;
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(FindRide), "Failure");
            throw;
        }

        return ride;
    }

    public async Task<List<Ride>> FindAll()
    {
        var rides = _rideRepository.GetAll();
        await _logger.LogMessage(nameof(FindAll), "Success");
        return rides;
    }

    public async Task<Ride?> FindRide(RideCompare rideCompare, string compareArg)
    {
        foreach (var ride in _rideRepository.GetAll().Where(ride => rideCompare(ride, compareArg)))
        {
            await _logger.LogMessage(nameof(FindRide), "Success");
            return ride;
        }
        await _logger.LogMessage(nameof(FindRide), "Failure");
        return null;
    }

    public async Task CreateRide(string destinationFrom, string destinationTo, User? owner, int availableSeats = 3)
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
            await _logger.LogMessage(nameof(CreateRide), "Success");
            Console.WriteLine("Ride was created");
        }
        else
        {
            await _logger.LogMessage(nameof(FindRide), "Failure");
            Console.WriteLine("You're not allowed to create a ride");
        }
    }

    public async Task DeleteRide(int rideId)
    {
        try
        {
            _rideRepository.Delete(rideId);
            await _logger.LogMessage(nameof(DeleteRide), "Success");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(DeleteRide), "Failure");
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(DeleteRide), "Failure");
        }
    }
    
    public async Task BookRide(User user, int rideId)
    {
        var ride = await FindRide(rideId);
        if (ride is not null && user is Passenger passenger)
        {
            if (ride.AvailableSeats > 0)
            {
                passenger?.BookRides.Add(ride);
                ride.Passengers.Add(passenger);
                ride.AvailableSeats--;
                Console.WriteLine("Ride was booked");
                await _logger.LogMessage(nameof(BookRide), "Success");
            }
            else
            {
                Console.WriteLine("No available seats for this ride.");
                await _logger.LogMessage(nameof(BookRide), "Failure");
            }
        }
        else
        {
            Console.WriteLine("Invalid ride or user type.");
            await _logger.LogMessage(nameof(BookRide), "Failure");
        }
    }

    private int GenerateNewId()
    {
        return _rideRepository.GetAll().Count != 0 ? _rideRepository.GetAll().Max(u => u.Id) + 1 : 0;
    }
}
