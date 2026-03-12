using System.Linq;
using Microsoft.VisualBasic;
using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.interfaces;

namespace MiniHittegods.Domain.Repository;

public class Repository<T> : IRepository<T>
    where T : IEntity
{
    private readonly List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public void Clear()
    {
        items.Clear();
    }

    public IEnumerable<T> GetAll()
    {
        return items;
    }

    public T GetById(int id)
    {
        return items.FirstOrDefault(i => i.Id == id)!;
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
