using AzureFunction.Challenge.Function.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunction.Challenge.Function.Database.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Price);

            builder.HasData(new Product
            {
                Id = 1,
                Name = "ByteBurger",
                Description = "Delicious beef burger",
                Price = 5.99m
            },
            new Product
            {
                Id = 2,
                Name = "BitFries",
                Description = "Bits of fries",
                Price = 1.99m
            },
            new Product
            {
                Id = 3,
                Name = "HashBrown",
                Description = "A small hashbrown",
                Price = 0.99m
            },
            new Product
            {
                Id = 4,
                Name = "ClassCola",
                Description = "A cold glass of cola",
                Price = 1.50m
            },
            new Product
            {
                Id = 5,
                Name = "StackShake",
                Description = "A giant milkshake",
                Price = 3.50m
            });
        }
    }
}
