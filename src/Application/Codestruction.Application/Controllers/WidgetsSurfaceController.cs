using System.Web.Mvc;
using Codestruction.Application.Services;
using Umbraco.Web.Mvc;

namespace Codestruction.Application.Controllers
{
    public class WidgetsSurfaceController: SurfaceController
    {
        private readonly WidgetService _widgetService;

        public WidgetsSurfaceController(WidgetService widgetService)
        {
            _widgetService = widgetService;
        }


     
        
        public ActionResult BlogArchives()
        {
                var blogArchives = _widgetService.GetBlogArchives();
                return View("~/Views/Partials/Widgets/BlogArchivesWidget.cshtml", blogArchives);

        }

        public ActionResult BlogTags()
        {
            var blogTags = _widgetService.GetTagsWidget();
            return View("~/Views/Partials/Widgets/BlogTagsWidget.cshtml", blogTags);

        }
 
    }
}
