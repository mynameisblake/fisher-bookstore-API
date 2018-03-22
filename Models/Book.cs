using System;
using System.Collections.Generic;

namespace Fisher.Bookstore.Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  Author Author { get; set; }
        public string Isbn { get; set; }
        public DateTime PublishDate { get; set; }
        public string Publisher { get; set; }
    }
}