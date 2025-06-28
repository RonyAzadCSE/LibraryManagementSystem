using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
