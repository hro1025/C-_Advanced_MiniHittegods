using System.Runtime.CompilerServices;
using MiniHittegods.Domain.Core;

namespace MiniHittegods.Domain.Interfaces;

public interface IRepository<T>
{
    IEnumerable<FoundItem> GetAll();
    FoundItem GetById(int id);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
    void SaveChanges();
}
