// Data/ApplicationDbContext.cs
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets here, which will become tables in your database
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BorrowRequest> BorrowRequests { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<Fine> Fines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships if needed (e.g., composite keys, specific foreign key names)
            // For simple relationships, EF Core's conventions are usually sufficient.

            // Example: One-to-many relationship between BookCategory and Book
            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookCategory)
                .WithMany(bc => bc.Books)
                .HasForeignKey(b => b.BookCategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting category if books exist

            // Example: One-to-many between User and BorrowRecord
            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.User)
                .WithMany(u => u.BorrowRecords)
                .HasForeignKey(br => br.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Example: One-to-many between Book and BorrowRecord
            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.Book)
                .WithMany(b => b.BorrowRecords)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // Example: One-to-many between User and BorrowRequest
            modelBuilder.Entity<BorrowRequest>()
                .HasOne(br => br.User)
                .WithMany(u => u.BorrowRequests)
                .HasForeignKey(br => br.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Example: One-to-many between Book and BorrowRequest
            modelBuilder.Entity<BorrowRequest>()
                .HasOne(br => br.Book)
                .WithMany(b => b.BorrowRequests)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // Example: One-to-many between BorrowRecord and Fine
            modelBuilder.Entity<Fine>()
                .HasOne(f => f.BorrowRecord)
                .WithMany(br => br.Fines)
                .HasForeignKey(f => f.BorrowRecordId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
