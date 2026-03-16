using MiniHittegods.Domain.Core;

namespace MiniHittegods.Domain.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T item);
    void Update(T item);

    void SaveChanges();
    void Remove(T item);
}

public interface IEntity
{
    public int Id { get; set; }
}
