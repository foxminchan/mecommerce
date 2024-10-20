using Ecommerce.Tax.Domain.CalculationAggregate;
using Ecommerce.Tax.Domain.CategoryAggregate;

namespace Ecommerce.Tax.Infrastructure;

public sealed class TaxContext(DbContextOptions<TaxContext> options) : DbContext(options), IDatabaseFacade
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Calculation> Calculations => Set<Calculation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasPostgresExtension(UniqueType.Extension);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxContext).Assembly);
    }
}
