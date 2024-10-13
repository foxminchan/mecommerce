using Ecommerce.Location.Domain.AddressAggregate;

namespace Ecommerce.Location.Infrastructure.EntityConfigurations;

internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql(UniqueType.Algorithm).ValueGeneratedOnAdd();

        builder.Property(x => x.Street).HasMaxLength(DataSchemaLength.SuperLarge).IsRequired();

        builder.Property(x => x.ZipCode).HasMaxLength(DataSchemaLength.Small).IsRequired();

        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.LastModifiedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version).IsConcurrencyToken();
    }
}
