using DAL.Models;

namespace DemoGotrust.Models.Response
{
    public class BasicPublisherResponse
    {
        public string PublisherId { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string? Description { get; set; }
        public BasicPublisherResponse()
        {

        }

        public BasicPublisherResponse(Publisher publisher)
        {
            PublisherId = publisher.PublisherId;
            PublisherName = publisher.PublisherName;
            Description = publisher.Description;
        }
    }
}
