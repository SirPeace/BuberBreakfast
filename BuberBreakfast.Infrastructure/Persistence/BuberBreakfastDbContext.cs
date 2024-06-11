using System.Reflection;
using BuberBreakfast.Domain.HostAggregate;
using BuberBreakfast.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Infrastructure.Persistence;

public class BuberBreakfastDbContext(DbContextOptions<BuberBreakfastDbContext> options)
    : DbContext(options)
{
    public required DbSet<Menu> Menus { get; init; }
    public required DbSet<Host> Hosts { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}