using Microsoft.EntityFrameworkCore;
using MiniHittegods.Domain.Core;
using MiniHittegods.Domain.Models;

namespace MiniHittegods.Infrastructure.Persistence;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options) { }

    public DbSet<FoundItemsModel> FoundItems { get; set; }
}
