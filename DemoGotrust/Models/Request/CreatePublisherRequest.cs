namespace DemoGotrust.Models.Request
{
    public class CreatePublisherRequest
    {
        public string PublisherId { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
