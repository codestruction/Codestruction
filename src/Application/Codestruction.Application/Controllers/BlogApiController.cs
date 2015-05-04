using Codestruction.Application.Contracts.Blog;
using Codestruction.Application.Contracts.Blog.Archive;
using Codestruction.Application.Contracts.Shared;
using Codestruction.Application.Services;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Codestruction.Application.Controllers
{
    [PluginController("Codestruction")]
    public class BlogApiController: UmbracoApiController 
    {
        private readonly BlogService _blogService;

        public BlogApiController(BlogService blogService)
        {
            _blogService = blogService;
        }

        public ListingResponse<BlogPostOverviewDto> GetListing(int page, int pageSize)
        {
            return _blogService.GetListingPage(page, pageSize);
        }

        public ListingResponse<BlogPostOverviewDto> GetArchive(BlogArchiveRequestDto request)
        {
            return _blogService.GetArchivePageResults(request);
        } 
    }
}
