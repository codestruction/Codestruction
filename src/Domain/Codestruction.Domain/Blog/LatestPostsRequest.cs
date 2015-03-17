using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codestruction.Domain.Blog
{
    public class LatestPostsRequest
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
