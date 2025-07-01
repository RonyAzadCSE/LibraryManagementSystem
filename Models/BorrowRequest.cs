using System;

namespace LibraryManagementSystem.Models
{
    public class BorrowRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Approved", "Rejected"
        public string Comment { get; set; } // Admin/Librarian comment on rejection

    }
}