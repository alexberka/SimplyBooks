using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using SimplyBooks.Data;

public class SimplyBooksDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public SimplyBooksDbContext(DbContextOptions<SimplyBooksDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(AuthorData.Authors);
        modelBuilder.Entity<Book>().HasData(BookData.Books);
    }
}