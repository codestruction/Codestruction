namespace Codestruction.Application.Contracts.Blog.Archive
{
    public interface IBlogArchiveRequest
    {
         int Page { get; set; }
         int PageSize { get; set; }
         string Query { get; set; }
         string Date { get; set; }
         string Tag { get; set; }
    }

    public class BlogArchiveRequestDto : IBlogArchiveRequest
    {

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public string Date { get; set; }
        public string Tag { get; set; }
    }
}