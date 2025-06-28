using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable, set when returned
        public decimal FineAmount { get; set; } // Calculated fine
        public bool IsFinePaid { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Book Book { get; set; }
        public ICollection<Fine> Fines { get; set; }
    }
}