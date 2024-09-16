using BurgerBooks.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerBooks.Api.Database.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Property(b => b.Name).HasMaxLength(100);

        builder.HasMany(a => a.Books).WithMany(b => b.Authors);
    }
}