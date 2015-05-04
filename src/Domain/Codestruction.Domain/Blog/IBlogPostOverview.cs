using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Codestruction.Domain.Blog
{
    public interface IBlogPostOverview
    {
         string Title { get; set; }
         string Teaser { get; set; }
         IList<string> Tags { get; set; }
         IList<string> Authors { get; set; }
         DateTime PublishDate { get; set; }
         string Url { get; set; }
    }
}
