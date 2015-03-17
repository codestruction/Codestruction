using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codestruction.Application.Contracts.ViewModels;
using Codestruction.Domain.Blog;
using Codestruction.Infrastructure.Umbraco;

namespace Codestruction.Application.Services
{
    public class BlogService
    {
        public BlogListingPageVm GetListingPage(int pageId)
        {
            var dao = new BlogDao();

            var posts = dao.GetLatestPosts(new LatestPostsRequest());

            var listingPage = new BlogListingPageVm();

            listingPage.BlogPosts =
                posts.Select(p => new BlogPostOverviewDto() {Title = p.Title, Content = p.Content}).ToList();

            return listingPage;
        }
    }
}
