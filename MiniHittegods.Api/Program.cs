using Microsoft.EntityFrameworkCore;
using MiniHittegods.Domain.Interfaces;
using MiniHittegods.Domain.Services;
using MiniHittegods.Infrastructure.Persistence;
using MiniHittegods.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
);

// Repository + Service
builder.Services.AddScoped(typeof(IRepository<>), typeof(PostgresRepository<>));
builder.Services.AddScoped<FoundItemsService>();

var app = builder.Build();

// Create database schema
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PostgresDbContext>();
    db.Database.EnsureCreated();
}

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
