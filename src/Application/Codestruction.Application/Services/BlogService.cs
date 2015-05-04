using System;
using System.Collections.Generic;
using System.Linq;
using Codestruction.Application.Context;
using Codestruction.Application.Contracts.Blog;
using Codestruction.Application.Contracts.Blog.Archive;
using Codestruction.Application.Contracts.Shared;
using Codestruction.Application.Factories;
using Codestruction.Domain.Blog;
using Codestruction.Infrastructure;

namespace Codestruction.Application.Services
{
    public class BlogService
    {
        private readonly IBlogDao _blogDao;
        private readonly BlogFactory _blogFactory;
        private readonly IAppContext _context;

        public BlogService(IBlogDao blogDao, BlogFactory blogFactory, IAppContext context)
        {
            _blogDao = blogDao;
            _blogFactory = blogFactory;
            _context = context;
        }

       
        public ListingResponse<BlogPostOverviewDto> GetListingPage(int page, int pageSize)
        {
            var postRequest = new LatestPostsRequest()
            {
                Page = page,
                PageSize = pageSize
            };

            var latestPosts =_blogDao.GetLatestPosts(postRequest);

            var listingResponse = new ListingResponse<BlogPostOverviewDto>();
            listingResponse.Data = GetPosts(latestPosts.Data);

            if (latestPosts.HasMoreResults)
            {
                listingResponse.DataUrl = _context.Urls.BlogApiListing(page + 1, pageSize);
            }

            return listingResponse;
        }

        private IList<BlogPostOverviewDto> GetPosts(IEnumerable<IBlogPostOverview> posts)
        {
            var postsDtos = new List<BlogPostOverviewDto>();
            foreach (var post in posts)
            {
                var postVm = new BlogPostOverviewDto
                {
                    Title = post.Title,
                    Teaser = post.Teaser,
                    PublishDate = post.PublishDate,
                    Url = post.Url,
                    Authors = post.Authors.Select(_blogFactory.BuildAuthor).ToList(),
                    Tags = post.Tags.Select(_blogFactory.BuildTag).ToList(),
                    Comments = new CommentsVm() { Count = 0, Url = "" }
                };
                postsDtos.Add(postVm);
            }
            return postsDtos;
        }
        public BlogListingPageVm GetListingPageVm(int page, int pageSize)
        {
            var postRequest = new LatestPostsRequest()
            {
                Page = (page == 0 ? 1 : page),
                PageSize = pageSize == 0 ? 3 : pageSize
            };

            var latestPosts = _blogDao.GetLatestPosts(postRequest);

            var listingPage = new BlogListingPageVm {BlogPosts = GetPosts(latestPosts.Data)};
            if (latestPosts.HasMoreResults)
            {
                listingPage.DataUrl = _context.Urls.BlogApiListing(postRequest.Page + 1, postRequest.PageSize);
            }


            return listingPage;
        }

        public ListingResponse<BlogPostOverviewDto> GetArchivePageResults(IBlogArchiveRequest requestDto)
        {
            var archiveRequest = BuildArchiveRequest(requestDto);
            var latestPosts = _blogDao.Find(archiveRequest);

            var listingResponse = new ListingResponse<BlogPostOverviewDto>()
            {
                Data = GetPosts(latestPosts.Data)
            };

            if (latestPosts.HasMoreResults)
            {
                listingResponse.DataUrl = _context.Urls.BlogApiArchive(requestDto);
            }

            return listingResponse;

        }
        public BlogArchivePageVm GetArchivePageVm(IBlogArchiveRequest requestDto)
        {
            var request = BuildArchiveRequest(requestDto);

            var latestPosts = _blogDao.Find(request);

            var archivePage = new BlogArchivePageVm
            {
                BlogPosts = GetPosts(latestPosts.Data),
                SearchInfo = BuildInfo(requestDto)
            };

            if (latestPosts.HasMoreResults)
            {
                archivePage.DataUrl = _context.Urls.BlogApiArchive(requestDto);
            }

            return archivePage;
        }

        private static FindPostsRequest BuildArchiveRequest(IBlogArchiveRequest requestDto)
        {
            var request = new FindPostsRequest()
            {
                Page = (requestDto.Page == 0 ? 1 : requestDto.Page),
                PageSize = requestDto.PageSize == 0 ? 1 : requestDto.PageSize,
                Query = requestDto.Query,
                Tag = requestDto.Tag,
            };

            var date = requestDto.Date.FromMonthName();
            if (date.HasValue)
            {
                request.DateStart = new DateTime(date.Value.Year, date.Value.Month, 1);
                request.DateEnd = request.DateStart.Value.AddMonths(1).AddSeconds(-1);
            }
            return request;
        }

        private SearchInfoVm BuildInfo(IBlogArchiveRequest archiveRm)
        {
            var info = new SearchInfoVm {Mode = SearchMode.Undefined};

            // Ify na kozaku, a jak
            if (!string.IsNullOrEmpty(archiveRm.Query))
            {
                info.Mode = SearchMode.Query;
                info.Value = archiveRm.Query;
            }
            else if (!string.IsNullOrEmpty(archiveRm.Date))
            {
                info.Mode = SearchMode.Date;
                info.Value = archiveRm.Date;
            }
            else if (!string.IsNullOrEmpty(archiveRm.Tag))
            {
                info.Mode = SearchMode.Tag;
                info.Value = archiveRm.Tag;
            }
            //TODO: Wyjebac do url managera
            info.AllPostsUrl = "/blog/archive/";

            return info;
        }
    }
}
