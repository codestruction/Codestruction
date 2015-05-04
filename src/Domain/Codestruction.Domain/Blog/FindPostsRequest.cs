using System;

namespace Codestruction.Domain.Blog
{
    public class FindPostsRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Tag { get; set; }
        public DateTime? DateStart { get; set; } 
        public DateTime? DateEnd { get; set; } 
        public string Query { get; set; } 
    }
}
