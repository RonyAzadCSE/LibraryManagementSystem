namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime DateRegistered { get; set; }

        public bool IsActive { get; set; }
    }
}
