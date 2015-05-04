using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codestruction.Domain.Blog
{
    public interface IBlogDao
    {
        SearchResponse<IBlogPostOverview> GetLatestPosts(LatestPostsRequest request);
        SearchResponse<IBlogPostOverview> Find(FindPostsRequest request);

        IList<DateTime> GetAllDates();
    }
}
