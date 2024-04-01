using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Book>().HasKey(b => b.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
