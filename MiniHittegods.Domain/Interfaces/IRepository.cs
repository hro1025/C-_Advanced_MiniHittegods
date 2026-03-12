using MiniHittegods.Domain.Core;

namespace MiniHittegods.Domain.interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T item);
    void Update(T item);
    void Remove(T item);
    void SaveChanges();
}

public interface IEntity
{
    public int Id { get; set; }
}
