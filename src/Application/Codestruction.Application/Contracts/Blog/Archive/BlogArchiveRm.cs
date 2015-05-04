using Umbraco.Web;
using Umbraco.Web.Models;

namespace Codestruction.Application.Contracts.Blog.Archive
{
    public class BlogArchiveRm : RenderModel, IBlogArchiveRequest
    {
        public BlogArchiveRm() :
            base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
        {

        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public string Date { get; set; }
        public string Tag { get; set; }
    }
}
