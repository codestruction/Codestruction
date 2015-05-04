using System.Web.Mvc;
using Codestruction.Application.Contracts.Blog.Listing;
using Codestruction.Application.Services;
using Umbraco.Web.Mvc;

namespace Codestruction.Application.Controllers
{
    public class BlogListingPageController : RenderMvcController
    {
        private readonly BlogService _blogService;

        public BlogListingPageController(BlogService blogService)
        {
            _blogService = blogService;
       
        }

        public  ActionResult BlogListingPage(BlogListingRm model)
        {
            var listingPage = _blogService.GetListingPageVm(model.Page, model.PageSize);

            return View(listingPage);
        }
    }
}
