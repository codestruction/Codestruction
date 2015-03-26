using System;
using System.Collections.Generic;
using Codestruction.Application.Contracts.ViewModels;

namespace Codestruction.Application.Contracts.Blog
{
    public class BlogPostOverviewDto
    {
        public string Title { get; set; }
        public string Teaser { get; set; }
        public string Url { get; set; }
        public DateTime PublishDate { get; set; }
        public IList<AuthorVm> Authors { get; set; }
        public IList<TagVm> Tags { get; set; }
        public CommentsVm Comments { get; set; }


    }
}
