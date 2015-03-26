using System;
using System.Collections.Generic;
using System.Linq;
using Codestruction.Application.Contracts.Blog;
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

            var posts = dao.GetLatestPosts(new LatestPostsRequest(){Page = 1, PageSize = 10});

            var listingPage = new BlogListingPageVm();

            foreach (var post in posts.Data)
            {
                var postVm = new BlogPostOverviewDto
                {
                    Title = post.Title,
                    Teaser = post.Teaser,
                    PublishDate = post.PublishDate,
                    Authors = post.Authors.Select(a => new AuthorVm()
                    {
                        Name = a,
                        Url = "/author/" + a
                    }).ToList(),
                    Tags = post.Tags.Select(t => new TagVm()
                    {
                        Name = t,
                        Url = "/tag/" + t
                    }).ToList(),
                    Comments = new CommentsVm() {Count = 2, Url = "/blog/date/october-2013"}
                };
                listingPage.BlogPosts.Add(postVm);
            }

            return listingPage;
        }
    }
}
