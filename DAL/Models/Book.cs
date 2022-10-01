using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public partial class Book
    {
        [Key]
        public string BookId { get; set; } = null!;
        public string BookName { get; set; } = null!;
        public int? Quantity { get; set; }
        public string? AuthorName { get; set; }
        public string? PublisherId { get; set; }

        public virtual Publisher? Publisher { get; set; }
    }
}
