using Ecommerce.Inventory.Domain.SupplierAggregate;
using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Infrastructure;

public sealed class InventoryContext : DbContext, IDatabaseFacade
{
    private readonly IPublisher? _publisher;

    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();

    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options) { }

    public InventoryContext(DbContextOptions<InventoryContext> options, IPublisher mediator)
        : base(options)
    {
        _publisher = Guard.Against.Null(mediator);
        System.Diagnostics.Debug.WriteLine("InventoryContext::ctor ->" + GetHashCode());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.HasPostgresExtension(UniqueType.Extension);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        await _publisher!.DispatchDomainEventsAsync(this);
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        _publisher!.DispatchDomainEventsAsync(this).GetAwaiter().GetResult();
        return base.SaveChanges();
    }
}
