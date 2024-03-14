namespace AmdarisAssignment3.Service;
using AmdarisAssignment3.Model;

public interface IRideService
{
    Ride? FindRide(int rideId);
    void CreateRide(string destinationFrom, string destinationTo, int availableSeats, User owner);
    Ride? DeleteRide(int rideId);
    void BookRide(User user, int rideId);
}
