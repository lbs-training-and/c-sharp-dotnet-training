using BurgerBooks.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerBooks.Api.Database.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).HasMaxLength(100);
        builder.Property(b => b.Price).HasPrecision(18, 2);
        
        builder.HasMany(b => b.Authors).WithMany(a => a.Books);
        builder.HasMany(o => o.BookOrders).WithOne(bo => bo.Book).OnDelete(DeleteBehavior.Restrict);
    }
}