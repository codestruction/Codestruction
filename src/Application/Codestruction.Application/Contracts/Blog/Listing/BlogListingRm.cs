using Umbraco.Web;
using Umbraco.Web.Models;

namespace Codestruction.Application.Contracts.Blog.Listing
{
    public class BlogListingRm: RenderModel 
    {
        public BlogListingRm() :
            base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
        {

        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
