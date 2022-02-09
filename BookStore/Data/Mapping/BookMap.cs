using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Isbn).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasData(
                new Book(1, "Domain-Driven Design: Tackling Complexity in the Heart of Software", "8721893718", 50, "Eric Evans", new DateTime(1990, 10, 10), 1),
                new Book(2, "Agile Principles, Patterns, and Practices in C#", "7632153123", 35, "Robert C. Martin", new DateTime(1990, 10, 10), 2),
                new Book(3, "Clean Code: A Handbook of Agile Software Craftsmanship", "6372168304", 22, "Robert C. Martin", new DateTime(1990, 10, 10), 3),
                new Book(4, "Implementing Domain-Driven Design", "7812382103", 34, "Vaughn Vernon", new DateTime(1990, 10, 10), 4),
                new Book(5, "Patterns, Principles, and Practices of Domain-Driven Design", "8812936542", 15, "Scott Millet", new DateTime(1990, 10, 10), 2),
                new Book(6, "Refactoring: Improving the Design of Existing Code", "5892187320", 13, "Martin Fowler", new DateTime(1990, 10, 10), 1)
            );
        }
    }
}
