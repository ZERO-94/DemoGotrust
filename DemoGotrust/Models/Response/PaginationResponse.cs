namespace DemoGotrust.Models.Response
{
    public class PaginationResponse<T>
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public List<T> objects { get; set; }
    }
}
