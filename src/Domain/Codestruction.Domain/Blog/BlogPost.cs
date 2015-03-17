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
        public IList<Tag> Tags { get; set; }
        public IList<Author> Authors { get; set; }
        public DateTime PublishDate { get; set; }


    }
}
