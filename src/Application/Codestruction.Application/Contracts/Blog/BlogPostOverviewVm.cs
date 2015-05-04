using System;
using System.Collections.Generic;

namespace Codestruction.Application.Contracts.Blog
{
    public class BlogPostOverviewDto
    {
        public string Title { get; set; }
        public string Teaser { get; set; }
        public string Url { get; set; }
        public DateTime PublishDate { get; set; }
        public IList<AuthorDto> Authors { get; set; }
        public IList<TagDto> Tags { get; set; }
        public CommentsVm Comments { get; set; }

        
    }
}
