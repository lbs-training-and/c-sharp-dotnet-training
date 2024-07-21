using AzureFunction.Challenge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunction.Challenge.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.DeliveryAddress).IsRequired().HasMaxLength(200);
            builder.Property(o => o.BillingAddress).IsRequired().HasMaxLength(200);
            builder.Property(o => o.Email).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Phone).IsRequired().HasMaxLength(20);
        }
    }
}
