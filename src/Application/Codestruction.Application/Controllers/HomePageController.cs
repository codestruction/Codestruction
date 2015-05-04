using System.Web.Mvc;
using Codestruction.Application.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Codestruction.Application.Controllers
{
    public class HomePageController : RenderMvcController 
    {
        private readonly BlogService _blogService;

        public HomePageController(BlogService blogService)
        {
            _blogService = blogService;
        }

        public override ActionResult Index(RenderModel model)
        {

            var listingPage = _blogService.GetListingPageVm(1, 1);

            return View(listingPage);
        }

    }
}
