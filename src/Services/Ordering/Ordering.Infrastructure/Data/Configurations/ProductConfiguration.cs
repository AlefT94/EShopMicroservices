using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValuesObjects;

namespace Ordering.Infrastructure.Data.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value, //How to save the Id in the database
            dbId => ProductId.Of(dbId)); //How to recover the Id from the database and convert it to the correct type

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}
