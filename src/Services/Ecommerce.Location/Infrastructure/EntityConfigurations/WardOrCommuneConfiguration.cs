using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Infrastructure.EntityConfigurations;

internal sealed class WardOrCommuneConfiguration : IEntityTypeConfiguration<WardOrCommune>
{
    public void Configure(EntityTypeBuilder<WardOrCommune> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasMaxLength(DataSchemaLength.SuperLarge).IsRequired();

        builder.Property(x => x.Type).IsRequired();

        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.LastModifiedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version).IsConcurrencyToken();

        builder
            .HasOne(x => x.District)
            .WithMany(x => x.WardOrCommunes)
            .HasForeignKey(x => x.DistrictId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
