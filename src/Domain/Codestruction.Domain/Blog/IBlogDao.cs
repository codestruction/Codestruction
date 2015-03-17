using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codestruction.Domain.Blog
{
    public interface IBlogDao
    {
        IList<IBlogPostOverview> GetLatestPosts(LatestPostsRequest request);
    }
}
