using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Category);

            builder.HasData(
                new Category(1, "Terror"),
                new Category(2, "Suspense"),
                new Category(3, "Comedia"),
                new Category(4, "Romance"),
                new Category(5, "Ficção"),
                new Category(6, "Drama")
            );
        }
    }
}
