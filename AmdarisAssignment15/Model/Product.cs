namespace AmdarisAssignment15.Model;

public abstract class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    protected Product(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract void ListProductDetails();
}