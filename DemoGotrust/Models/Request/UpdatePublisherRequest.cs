namespace DemoGotrust.Models.Request
{
    public class UpdatePublisherRequest
    {
        public string PublisherId { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
