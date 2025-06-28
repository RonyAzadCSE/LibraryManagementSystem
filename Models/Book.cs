using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int BookCategoryId { get; set; } // Foreign key for category
        public string CoverImageUrl { get; set; } // Path or URL to cover image
        public DateTime PublishedDate { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; } // Calculated field

        // Navigation property
        public BookCategory BookCategory { get; set; }
        public ICollection<BorrowRecord> BorrowRecords { get; set; }
        public ICollection<BorrowRequest> BorrowRequests { get; set; }
    }
}