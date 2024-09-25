using BurgerBooks.Function.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerBooks.Function.Database.Configuration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(g => g.Id);
        
        builder.Property(b => b.Name).HasMaxLength(100);

        builder.HasMany(g => g.Books).WithOne(b => b.Genre).OnDelete(DeleteBehavior.Restrict);
    }
}