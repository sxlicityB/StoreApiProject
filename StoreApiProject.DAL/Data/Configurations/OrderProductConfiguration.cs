using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApiProject.Domain.Models;
using System.Reflection.Emit;

namespace StoreApiProject.DAL.Data.Configurations;

internal class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        //Many to many relations between Order and Product classes

        builder.HasKey(op => new { op.OrderId, op.ProductId });

        builder.HasOne(o => o.Order)
        .WithMany(op => op.OrderProducts)
        .HasForeignKey(op => op.OrderId);

        builder.HasOne(p => p.Product)
       .WithMany(p => p.OrderProducts)
       .HasForeignKey(op => op.ProductId);


        builder.Property(op => op.UnitPrice)
        .HasPrecision(18, 2);
    }
}
