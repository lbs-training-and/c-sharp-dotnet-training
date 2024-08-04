using AzureFunction.Challenge.Function.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunction.Challenge.Function.Database.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(op => op.Id);
            builder.Property(op => op.Quantity).IsRequired();
            builder.Property(op => op.Notes).HasMaxLength(500);
            builder.Property(op => op.Price);

            builder.HasOne(op => op.Order)
                   .WithMany(o => o.OrderProducts)
                   .HasForeignKey(op => op.OrderId);
        }
    }

}
