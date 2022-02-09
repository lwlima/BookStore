using BookStore.Domain;
using BookStore.Mapping;
using Microsoft.EntityFrameworkCore;
using BookStore.ViewModels;

namespace BookStore.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Book>? Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
