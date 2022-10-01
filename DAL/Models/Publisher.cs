using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public string PublisherId { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
