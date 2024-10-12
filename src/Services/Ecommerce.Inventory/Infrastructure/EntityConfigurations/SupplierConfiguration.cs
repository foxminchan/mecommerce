using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Infrastructure.EntityConfigurations;

internal sealed class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasMaxLength(DataSchemaLength.ExtraLarge).IsRequired();

        builder.Property(x => x.Email).HasMaxLength(DataSchemaLength.ExtraLarge).IsRequired();

        builder.Property(x => x.Phone).HasMaxLength(DataSchemaLength.Small).IsRequired();

        builder.OwnsMany(
            x => x.ContactPersons,
            contactPerson =>
            {
                contactPerson.HasKey(x => x.Id);

                contactPerson.Property(x => x.Id).ValueGeneratedOnAdd();

                contactPerson
                    .Property(x => x.Name)
                    .HasMaxLength(DataSchemaLength.ExtraLarge)
                    .IsRequired();

                contactPerson.Property(x => x.Email).HasMaxLength(DataSchemaLength.ExtraLarge);

                contactPerson
                    .Property(x => x.Phone)
                    .HasMaxLength(DataSchemaLength.Small)
                    .IsRequired();
            }
        );
    }
}
