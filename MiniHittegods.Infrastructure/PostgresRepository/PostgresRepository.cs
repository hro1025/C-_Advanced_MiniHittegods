using Microsoft.EntityFrameworkCore;
using MiniHittegods.Domain.Interfaces;
using MiniHittegods.Infrastructure.Persistence;

namespace MiniHittegods.Infrastructure.Repository;

public class PostgresRepository<T> : IRepository<T>
    where T : class, IEntity
{
    private readonly PostgresDbContext _context;
    private readonly DbSet<T> _dbSet;

    public PostgresRepository(PostgresDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void Add(T item)
    {
        _dbSet.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id)!;
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }

    public void Update(T item)
    {
        _dbSet.Update(item);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
