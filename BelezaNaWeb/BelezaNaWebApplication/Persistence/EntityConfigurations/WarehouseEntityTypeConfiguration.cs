using BelezaNaWebDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BelezaNaWebApplication.Persistence.EntityConfigurations
{
    internal class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey("WarehouseId");

            builder
                .Property<String>(nameof(Warehouse.Locality))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Warehouse.Locality));

            builder
                .Property<long>(nameof(Warehouse.Quantity))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Warehouse.Quantity));

            builder
                .Property<WarehouseType>(nameof(Warehouse.Type))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Warehouse.Type));
        }
    }
}