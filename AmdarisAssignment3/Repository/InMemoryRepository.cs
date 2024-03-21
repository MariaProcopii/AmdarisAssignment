using AmdarisAssignment3.Model;
using AmdarisAssignment3.Exceptions;

namespace AmdarisAssignment3.Repository;

public class InMemoryRepository<T> : IRepository<T> where T : Entity
{
    private readonly List<T> _entities = new List<T>();

    public T GetById(int id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater or equal to zero.");
        }
        var entity = _entities.FirstOrDefault(e => e.Id == id);
        return entity ?? throw new EntityNotFoundException("Entity not found.");
    }

    public List<T> GetAll()
    {
        return _entities;
    }

    public void Create(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
        }
        _entities.Add(entity);
    }

    public void Update(int id, T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
        }
        var existingEntity = GetById(id);
        
        var index = _entities.IndexOf(existingEntity);
        _entities[index] = entity;
    }

    public void Delete(int id)
    {
        var entityToDelete = GetById(id);
        _entities.Remove(entityToDelete);
    }
}