using AzureFunction.Challenge.Function.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunction.Challenge.Function.Database.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.OwnsOne(o => o.DeliveryAddress);
            builder.OwnsOne(o => o.BillingAddress);
            builder.Property(o => o.Email).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Phone).IsRequired().HasMaxLength(20);
        }
    }
}
