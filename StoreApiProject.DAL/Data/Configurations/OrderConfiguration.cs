using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApiProject.Domain.Models;
using System.Reflection.Emit;

namespace StoreApiProject.DAL.Data.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        //One to many relation between Order and Buyer classes

        builder.HasOne(o => o.Buyer)
        .WithMany(b => b.Orders)
        .HasForeignKey(o => o.BuyerId);

    }
}
