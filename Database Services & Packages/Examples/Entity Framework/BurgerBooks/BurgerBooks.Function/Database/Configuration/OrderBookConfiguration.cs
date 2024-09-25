using BurgerBooks.Function.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerBooks.Function.Database.Configuration;

public class OrderBookConfiguration : IEntityTypeConfiguration<OrderBook>
{
    public void Configure(EntityTypeBuilder<OrderBook> builder)
    {
        builder.HasKey(ob => ob.Id);
        
        builder.Property(ob => ob.UnitPrice).HasPrecision(18, 2);
    }
}