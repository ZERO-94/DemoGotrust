namespace DemoGotrust.Models.Response
{
    public class PublisherResponse : BasicPublisherResponse
    {
        public IEnumerable<BasicBookResponse> Books { get; set; }
    }
}
