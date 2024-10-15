using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Infrastructure.Data;

public sealed class MediaContext(DbContextOptions<MediaContext> options)
    : DbContext(options),
        IDatabaseFacade
{
    public DbSet<Image> Images => Set<Image>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.HasPostgresExtension(UniqueType.Extension);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MediaContext).Assembly);
    }
}
