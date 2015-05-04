using System.Web.Mvc;
using Codestruction.Application.Contracts.Blog.Archive;
using Codestruction.Application.Services;
using Umbraco.Web.Mvc;

namespace Codestruction.Application.Controllers
{
    public class BlogArchivePageController : RenderMvcController
    {
        private readonly BlogService _blogService;

        public BlogArchivePageController(BlogService blogService)
        {
            _blogService = blogService;
        }

        public  ActionResult BlogArchivePage(BlogArchiveRm model)
        {
            var archivePage = _blogService.GetArchivePageVm(model);

            return View(archivePage);
        }

    }
}
