using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codestruction.Domain.Blog
{
    public class BlogPost: IBlogPostOverview
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Teaser { get; set; }
        public IList<string> Tags { get; set; }
        public IList<string> Authors { get; set; }
        public DateTime PublishDate { get; set; }
        public string Url { get; set; }
        public BlogPost()
        {
            Tags = new List<string>();
            Authors = new List<string>();
        }

    }
}
