using System;
using System.Collections.Generic;

namespace Codestruction.Domain.Blog
{
    public interface IBlogPostOverview
    {
        string Title { get; set; }
        string Teaser { get; set; }
         IList<string> Tags { get; set; }
         IList<string> Authors { get; set; }
         DateTime PublishDate { get; set; }
    }
}
