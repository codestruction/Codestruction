using System.Collections.Generic;
using Codestruction.Domain.Blog;
using umbraco;
using Umbraco.Web;

namespace Codestruction.Infrastructure.Umbraco
{
    public class BlogDao : IBlogDao 
    {
        public IList<IBlogPostOverview> GetLatestPosts(LatestPostsRequest request)
        {
            var pageListsing = UmbracoContext.Current.ContentCache.GetById(1058);

            var blogPosts = new List<IBlogPostOverview>();
            foreach (var postPage in pageListsing.Children)
            {
                var blogPost = new BlogPost();
                blogPost.Title = postPage.GetPropertyValue<string>("title");
                blogPost.Content = postPage.GetPropertyValue<string>("content");

                blogPosts.Add(blogPost);
            }

            return blogPosts;
        }
    }
}
    