using DAL.Models;

namespace DemoGotrust.Models.Response
{
    public class BasicBookResponse
    {

        public string BookId { get; set; } = null!;
        public string BookName { get; set; } = null!;
        public int? Quantity { get; set; }
        public string? AuthorName { get; set; }
        public virtual BasicPublisherResponse? Publisher { get; set; }

        public BasicBookResponse(Book book)
        {
            BookId = book.BookId;
            BookName = book.BookName;
            Quantity = book.Quantity;
            AuthorName = book.AuthorName;
            Publisher = new BasicPublisherResponse { Description = book.Publisher.Description, PublisherId = book.PublisherId, PublisherName = book.Publisher.PublisherName };
            
        }
    }

    
}
