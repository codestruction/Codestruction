using System;
using System.Collections.Generic;
using System.Linq;
using Codestruction.Domain.Blog;
using Examine;
using Examine.LuceneEngine.Config;
using Examine.SearchCriteria;

namespace Codestruction.Infrastructure.Umbraco
{
    public class BlogDao : IBlogDao 
    {
        private readonly IBlogPostFactory _blogPostFactory;

        public BlogDao()
         {
             _blogPostFactory = new BlogPostFactory();
         }
        public SearchResponse<IBlogPostOverview> GetLatestPosts(LatestPostsRequest request)
        {
            var searcher = Examine.ExamineManager.Instance.SearchProviderCollection[Consts.ContentSearcher];
            var searchCriteria = searcher.CreateSearchCriteria(BooleanOperation.And);

            var query = searchCriteria.Field(Consts.ContentIndexFields.DocumentType, Consts.DocumentTypes.BlogDetailsPage);
        
            ISearchResults tempResults = searcher.Search(query.Compile());
            var orderedResults = tempResults.OrderByDescending(f => f.Fields[Consts.ContentIndexFields.PublishDate]);

            var results = orderedResults.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).OrderByDescending(p => p.Score);

            return new SearchResponse<IBlogPostOverview>()
            {
                Data = results.Select(s => _blogPostFactory.BuildOverview(s)).ToList(),
                Count = tempResults.TotalItemCount,
                HasMoreResults = tempResults.TotalItemCount > request.Page * request.PageSize
            };


        }

        public SearchResponse<IBlogPostOverview> Find(FindPostsRequest request)
        {
            var searcher = Examine.ExamineManager.Instance.SearchProviderCollection[Consts.ContentSearcher];
            var searchCriteria = searcher.CreateSearchCriteria(BooleanOperation.And);

            // Build query, custom query has boosting enabled, title is more important than content
            var query = searchCriteria.Field(Consts.ContentIndexFields.DocumentType,Consts.DocumentTypes.BlogDetailsPage);
            var customQueries = new List<string>();

            if (!string.IsNullOrEmpty(request.Query))
            {
                customQueries.Add(CustomQueries.Content(request.Query));
            }

            if (!string.IsNullOrEmpty(request.Tag))
            {
                query = query.And().Field(Consts.ContentIndexFields.TagsTokenized, request.Tag);
            }

            if (request.DateEnd.HasValue && request.DateStart.HasValue)
            {
                query = query.And().Range(Consts.ContentIndexFields.PublishDate,request.DateStart.Value, request.DateEnd.Value);
            }


            // Sort and pagination
            ISearchResults tempResults = searcher.Search(query.AddRawQueries(customQueries));
            var orderedResults = tempResults.OrderByDescending(f => f.Fields[Consts.ContentIndexFields.PublishDate]);

            var results = orderedResults.Skip((request.Page - 1)*request.PageSize)
                    .Take(request.PageSize)
                    .OrderByDescending(p => p.Score);

            return new SearchResponse<IBlogPostOverview>()
            {
                Data = results.Select(s => _blogPostFactory.BuildOverview(s)).ToList(),
                Count = tempResults.TotalItemCount,
                HasMoreResults = tempResults.TotalItemCount > request.Page*request.PageSize

            };
        }

        public IList<DateTime> GetAllDates()
        {
            var searcher = Examine.ExamineManager.Instance.SearchProviderCollection[Consts.ContentSearcher];
            var searchCriteria = searcher.CreateSearchCriteria(BooleanOperation.And);

            var query = searchCriteria.Field(Consts.ContentIndexFields.DocumentType, Consts.DocumentTypes.BlogDetailsPage);

           return 
                searcher.Search(query.Compile())
                    .Select(p => p.Fields[Consts.ContentIndexFields.PublishDate].ToDateTime())
                    .Where(s => s.HasValue).Select(d=> d.Value)
                    .ToList();

        }
    }
}
    