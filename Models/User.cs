using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Hashed password
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } // e.g., "Admin", "Librarian", "Member"
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Navigation property for borrowing history
        public ICollection<BorrowRecord> BorrowRecords { get; set; }
        public ICollection<BorrowRequest> BorrowRequests { get; set; }
    }
}