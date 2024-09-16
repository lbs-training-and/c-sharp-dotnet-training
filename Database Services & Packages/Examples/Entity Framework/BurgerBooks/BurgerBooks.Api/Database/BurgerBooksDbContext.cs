using BurgerBooks.Api.Database.Configuration;
using BurgerBooks.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BurgerBooks.Api.Database;

public class BurgerBooksDbContext : DbContext
{
    public BurgerBooksDbContext(DbContextOptions<BurgerBooksDbContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<OrderBook> OrderBooks => Set<OrderBook>();
    public DbSet<ShippingAddress> ShippingAddresses => Set<ShippingAddress>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new OrderBookConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ShippingAddressConfiguration());
    }
}