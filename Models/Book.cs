﻿using Humanizer.Localisation;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public int PublishedYear { get; set; }

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateAdded { get; set; }


    }
}
