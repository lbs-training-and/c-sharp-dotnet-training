using AzureFunction.Challenge.Function.Core.Entities;
using AzureFunction.Challenge.Function.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AzureFunction.Challenge.Function
{
    public class AzureFunctionDbContext : DbContext
    {
        public AzureFunctionDbContext(DbContextOptions<AzureFunctionDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
        }
    }
}
