namespace AmdarisAssignment3.Model;

public class Ride : ICloneable
{
    public required int Id { get; init; }
    public required string DestinationFrom { get; set; }
    public required string DestinationTo { get; set; }
    public required int AvailableSeats { get; set; }
    public required User Owner { get; set; }
    public List<User> Passengers { get; set; } = new List<User>();
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
