using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public Guid CreatedBy { get; set; } // User ID of the creator

        public DateTime CreatedAt { get; set; } // Timestamp of creation

        public Guid? UpdatedBy { get; set; } // User ID of the last updater (nullable)

        public DateTime? UpdatedAt { get; set; } // Timestamp of last update (nullable)

        // Navigation property for the one-to-many relationship with Book
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
