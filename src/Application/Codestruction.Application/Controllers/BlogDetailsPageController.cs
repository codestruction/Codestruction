using System.Web.Mvc;
using Codestruction.Application.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Codestruction.Application.Controllers
{
    public class BlogListingPageController : RenderMvcController 
    {

        public override ActionResult Index(RenderModel model)
        {
            var service = new BlogService();

            var listingPage = service.GetListingPage(model.Content.Id);

            return View(listingPage);
        }

    }
}
