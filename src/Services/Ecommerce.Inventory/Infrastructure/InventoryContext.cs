using Ecommerce.Inventory.Domain.StockAggregate;
using Ecommerce.Inventory.Domain.SupplierAggregate;
using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Infrastructure;

public sealed class InventoryContext(DbContextOptions<InventoryContext> options)
    : DbContext(options)
{
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.HasPostgresExtension(UniqueType.Extension);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryContext).Assembly);
    }
}
