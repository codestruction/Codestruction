using Codestruction.Domain.Blog;
using Examine;

namespace Codestruction.Infrastructure.Umbraco
{
    public interface IBlogPostFactory
    {
        IBlogPostOverview BuildOverview(SearchResult searchResult);
    }
}