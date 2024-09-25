using BurgerBooks.Function.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerBooks.Function.Database.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(b => b.TotalPrice).HasPrecision(18, 2);

        builder.HasOne(o => o.ShippingAddress).WithOne().HasPrincipalKey<Order>(o => o.Id).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(o => o.OrderBooks).WithOne(ob => ob.Order).OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(o => o.BillingAddress, b =>
        {
            b.Property(a => a.Firstname).HasMaxLength(100);
            b.Property(a => a.Lastname).HasMaxLength(100);
            b.Property(a => a.AddressLine1).HasMaxLength(100);
            b.Property(a => a.AddressLine2).HasMaxLength(100);
            b.Property(a => a.AddressLine3).HasMaxLength(100);
            b.Property(a => a.City).HasMaxLength(100);
            b.Property(a => a.Postcode).HasMaxLength(8);
        });
    }
}