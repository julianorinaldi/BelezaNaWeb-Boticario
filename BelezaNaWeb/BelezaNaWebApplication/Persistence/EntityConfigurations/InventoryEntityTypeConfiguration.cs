using BelezaNaWebDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWebApplication.Persistence.EntityConfigurations
{
    internal class InventoryEntityTypeConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey("Id");

            builder.Ignore(x => x.Warehouses);

            builder.Ignore(x => x.Quantity);

            builder.HasOne<Product>(o => o.Product)
                .WithOne(x => x.Inventory)
                .HasForeignKey<Product>(x => x.SKU);
        }
    }
}