using System.Linq;
using Codestruction.Domain.Blog;
using Examine;
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
            var searcher = Examine.ExamineManager.Instance.SearchProviderCollection["InternalSearcher"];
            var searchCriteria = searcher.CreateSearchCriteria(BooleanOperation.And);

            var query = searchCriteria.Field(Consts.BlogFields.DocumentType, Consts.DocumentTypes.BlogDetailsPage);
        
            ISearchResults tempResults = searcher.Search(query.Compile());
            var orderedResults = tempResults.OrderByDescending(f => f.Fields[Consts.BlogFields.PublishDate]);

            var results = orderedResults.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).OrderByDescending(p => p.Score);

            return new SearchResponse<IBlogPostOverview>()
            {
                Data = results.Select(s => _blogPostFactory.BuildOverview(s)).ToList(),
                Count = tempResults.TotalItemCount,
                HasMoreResults = tempResults.TotalItemCount > request.Page * request.PageSize
            };


        }
    }
}
    