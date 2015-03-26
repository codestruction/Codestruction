using System.Collections.Generic;

namespace Codestruction.Application.Contracts.Blog
{
    public class BlogListingPageVm
    {
        public IList<BlogPostOverviewDto> BlogPosts { get; set; }

        public string DataUrl { get; set; }

        public BlogListingPageVm()
        {
            BlogPosts = new List<BlogPostOverviewDto>();
        }
    }
}
