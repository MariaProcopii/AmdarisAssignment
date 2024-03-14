namespace AmdarisAssignment3.Model;

public abstract class User
{
    public required int Id { get; init; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public abstract void DisplayInfo();
}