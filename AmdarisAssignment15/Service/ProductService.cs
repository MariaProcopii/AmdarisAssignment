using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Service;

public class ProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        _products =
        [
            new Book(Guid.NewGuid(), "To Kill a Mockingbird", "Harper Lee", 10),
            new Book(Guid.NewGuid(), "The Catcher in the Rye", "J.D. Salinger", 12),
            new Book(Guid.NewGuid(), "1984", "George Orwell", 12),
            new Book(Guid.NewGuid(), "The Great Gatsby", "F. Scott Fitzgerald", 10)
        ];
    }

    public List<Product> GetProducts(Predicate<Product> condition)
    {
        return _products.FindAll(condition);
    }
}