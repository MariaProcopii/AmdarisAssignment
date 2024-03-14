namespace AmdarisAssignment3.Model;

public class Ride
{
    public required int Id { get; init; }
    public required string DestinationFrom { get; set; }
    public required string DestinationTo { get; set; }
    public required int AvailableSeats { get; set; }
    public required User Owner { get; set; }
    public List<User> Passengers { get; set; } = new List<User>();
}
