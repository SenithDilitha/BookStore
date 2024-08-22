using BookListService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookListService.Infrastructure.Data;

public class BookListDbContext : DbContext
{
    public BookListDbContext(DbContextOptions<BookListDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt, David Thomas",
                Genre = "Programming",
                Price = 35.99M,
                PublishedDate = new DateTime(1999, 10, 20)
            },
            new Book
            {
                Id = 2,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Genre = "Programming",
                Price = 45.99M,
                PublishedDate = new DateTime(2008, 8, 1)
            }
        );
    }
}