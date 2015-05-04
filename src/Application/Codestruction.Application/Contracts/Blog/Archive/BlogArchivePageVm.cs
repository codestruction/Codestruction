using System.Collections;
using System.Collections.Generic;

namespace Codestruction.Application.Contracts.Blog.Archive
{
    public class BlogArchivePageVm
    {
        public SearchInfoVm SearchInfo { get; set; }
        public IList<BlogPostOverviewDto> BlogPosts { get; set; }
        public string DataUrl { get; set; }
    }
}
