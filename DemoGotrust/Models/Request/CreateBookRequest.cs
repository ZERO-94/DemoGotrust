namespace DemoGotrust.Models.Request
{
    public class CreateBookRequest
    {
        public string BookId { get; set; } = null!;
        public string BookName { get; set; } = null!;
        public int? Quantity { get; set; }
        public string? AuthorName { get; set; }
        public string? PublisherId { get; set; }
    }
}
