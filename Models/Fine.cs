using System;

namespace LibraryManagementSystem.Models
{
    public class Fine
    {
        public int Id { get; set; }
        public int BorrowRecordId { get; set; }
        public decimal Amount { get; set; }
        public DateTime FineDate { get; set; }
        public bool IsPaid { get; set; }
        public string Reason { get; set; } // e.g., "Overdue"

        // Navigation property
        public BorrowRecord BorrowRecord { get; set; }
    }
}