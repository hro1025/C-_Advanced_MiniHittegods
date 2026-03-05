using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Interfaces;

namespace MiniHittegods.Domain.Repository;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly List<T> items = new List<T>();

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Delete(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FoundItem> GetAll()
    {
        throw new NotImplementedException();
    }

    public FoundItem GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void Update(T item)
    {
        throw new NotImplementedException();
    }
}
