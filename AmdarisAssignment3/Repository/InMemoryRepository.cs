using AmdarisAssignment3.Model;

namespace AmdarisAssignment3.Repository;

public class InMemoryRepository<T> : IRepository<T> where T : Entity
{
    private readonly List<T> _entities = new List<T>();

    public T? GetById(int id)
    {
        return _entities.FirstOrDefault(e => e.Id == id);
    }

    public List<T> GetAll()
    {
        return _entities;
    }

    public void Create(T entity)
    {
        _entities.Add(entity);
    }

    public void Update(int id, T entity)
    {
        var existingEntity = GetById(id);
        if (existingEntity is not null)
        {
            var index = _entities.IndexOf(existingEntity);
            _entities[index] = entity;
        }
        else
        {
            throw new ArgumentException("Entity not found.");
        }
    }

    public void Delete(int id)
    {
        var entityToDelete = GetById(id);
        if (entityToDelete is not null)
        {
            _entities.Remove(entityToDelete);
        }
        else
        {
            throw new ArgumentException("Entity not found.");
        }
    }
}