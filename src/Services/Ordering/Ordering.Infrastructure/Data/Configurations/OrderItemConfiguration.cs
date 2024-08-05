using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValuesObjects;

namespace Ordering.Infrastructure.Data.Configuration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(
            OrderItemId => OrderItemId.Value, //How to save the Id in the database
            dbId => OrderItemId.Of(dbId)); //How to recover the Id from the database and convert it to the correct type

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(x => x.ProductId);

        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Price).IsRequired();
    }
}
