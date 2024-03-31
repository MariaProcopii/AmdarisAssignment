namespace AmdarisAssignment15.Model;

public class Book : Product
{
    public int Price { get; set; }
    public string Author { get; set; }
    
    public Book(Guid id, string name, string author, int price) : base(id, name)
    {
        Price = price;
        Author = author;
    }
    
    public  override void ListProductDetails()
    {
        Console.WriteLine($"Book Name: {Name}, Author: {Author}, Price {Price}");
    }
}