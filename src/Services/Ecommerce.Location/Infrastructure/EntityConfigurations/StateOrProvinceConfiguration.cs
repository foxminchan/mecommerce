using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Infrastructure.EntityConfigurations;

internal sealed class StateOrProvinceConfiguration : IEntityTypeConfiguration<StateOrProvince>
{
    public void Configure(EntityTypeBuilder<StateOrProvince> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasMaxLength(DataSchemaLength.SuperLarge).IsRequired();

        builder.Property(x => x.Code).HasMaxLength(DataSchemaLength.Small).IsRequired();

        builder.Property(x => x.Type).IsRequired();

        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.LastModifiedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version).IsConcurrencyToken();

        builder
            .HasOne(x => x.Country)
            .WithMany(x => x.StateOrProvinces)
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
