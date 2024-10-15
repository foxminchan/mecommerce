using Ecommerce.Location.Domain.AddressAggregate;
using Ecommerce.Location.Domain.CountryAggregate;
using Ecommerce.Location.Domain.DistrictAggregate;
using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Infrastructure;

public sealed class LocationContext(DbContextOptions<LocationContext> options)
    : DbContext(options),
        IDatabaseFacade
{
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<StateOrProvince> StateOrProvinces => Set<StateOrProvince>();
    public DbSet<District> Districts => Set<District>();
    public DbSet<WardOrCommune> WardOrCommunes => Set<WardOrCommune>();
    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.HasPostgresExtension(UniqueType.Extension);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocationContext).Assembly);
    }
}
