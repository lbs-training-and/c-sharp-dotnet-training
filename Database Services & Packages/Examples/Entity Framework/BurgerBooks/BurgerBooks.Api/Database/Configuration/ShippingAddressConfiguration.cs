using BurgerBooks.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerBooks.Api.Database.Configuration;

public class ShippingAddressConfiguration : IEntityTypeConfiguration<ShippingAddress>
{
    public void Configure(EntityTypeBuilder<ShippingAddress> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.Firstname).HasMaxLength(100);
        builder.Property(a => a.Lastname).HasMaxLength(100);
        builder.Property(a => a.AddressLine1).HasMaxLength(100);
        builder.Property(a => a.AddressLine2).HasMaxLength(100);
        builder.Property(a => a.AddressLine3).HasMaxLength(100);
        builder.Property(a => a.City).HasMaxLength(100);
        builder.Property(a => a.Postcode).HasMaxLength(8);
    }
}