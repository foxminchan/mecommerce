using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Infrastructure.EntityConfigurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasMaxLength(DataSchemaLength.SuperLarge).IsRequired();

        builder.Property(x => x.FirstCode).HasMaxLength(DataSchemaLength.Micro).IsRequired();

        builder.Property(x => x.SecondCode).HasMaxLength(DataSchemaLength.Micro);

        builder.Property(x => x.ThirdCode).HasMaxLength(DataSchemaLength.Micro);

        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.LastModifiedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version).IsConcurrencyToken();

        builder
            .HasMany(x => x.StateOrProvinces)
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
