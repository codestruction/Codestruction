using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codestruction.Application.Context;
using Codestruction.Application.Contracts.Widgets;
using Codestruction.Domain.Blog;
using Codestruction.Infrastructure;
using Codestruction.Infrastructure.Umbraco;
using Umbraco.Web;

namespace Codestruction.Application.Services
{
    public class WidgetService
    {
        private readonly IBlogDao _blogDao;
        private readonly IAppContext _context;

        public WidgetService(IBlogDao blogDao, IAppContext context)
        {
            _blogDao = blogDao;
            _context = context;
        }

        public BlogTagsWidget GetTagsWidget()
        {
            var blogTagsWidget = new BlogTagsWidget();

            var tags = UmbracoContext.Current.Application.Services.TagService.GetAllTags(Consts.TagGroups.Blog);
            blogTagsWidget.Tags = tags.ToList().Select(p => new TagVm()
            {
                Name = p.Text,
                Count = p.NodeCount,
                Url = _context.Urls.BlogArchiveTags(p.Text)
            }).ToList();

            return blogTagsWidget;
        }
        public BlogArchivesWidget GetBlogArchives()
        {
            var blogDates = _blogDao.GetAllDates().OrderByDescending(d => d);

            var years = blogDates.Select(p => p.Year).ToList().Distinct();

            var dateLinks = new List<LinkVm>();

            foreach (var year in years)
            {
                var months = blogDates.Where(p => p.Year == year).Select(p => p.Month).ToList().Distinct();
                foreach (var month in months)
                {
                    var date = new DateTime(year, month, 1);
                    var blogLink = new LinkVm()
                    {
                        Title = date.MonthName() + " " + year.ToString(),
                        Url = _context.Urls.BlogArchiveDate(date)
                    };
                    dateLinks.Add(blogLink);
                }

            }
            return new BlogArchivesWidget()
            {
                Links = dateLinks,
                Title = "Archives"
            };

        }
    }
}
