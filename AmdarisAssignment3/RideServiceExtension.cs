using AmdarisAssignment3.Service;

namespace AmdarisAssignment3;

public static class RideServiceExtension
{


    public static void DeleteIfExists(this RideService rideService, int id)
    {
        if (rideService.FindRide(id) is not null)
        {
            rideService.DeleteRide(id);
        }
    }
}