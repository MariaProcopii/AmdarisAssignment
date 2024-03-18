namespace AmdarisAssignment3.Repository;

public interface IRepository<T>
{
    T? GetById(int id);
    List<T> GetAll();
    void Create(T entity);
    void Update(int id, T entity);
    void Delete(int id);
}
