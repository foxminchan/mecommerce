using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Infrastructure.EntityConfigurations;

internal sealed class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasMaxLength(DataSchemaLength.SuperLarge).IsRequired();

        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.LastModifiedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version).IsConcurrencyToken();

        builder
            .HasOne(x => x.StateOrProvince)
            .WithMany(x => x.Districts)
            .HasForeignKey(x => x.StateOrProvinceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
