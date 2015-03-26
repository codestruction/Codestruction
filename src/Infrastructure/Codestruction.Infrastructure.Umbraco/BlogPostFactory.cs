using System;
using System.Collections.Generic;
using Codestruction.Domain.Blog;
using Examine;

namespace Codestruction.Infrastructure.Umbraco
{
    public class BlogPostFactory : IBlogPostFactory
    {
        public IBlogPostOverview BuildOverview(SearchResult searchResult)
        {
            return new BlogPost()
            {
                Title = searchResult.GetValue<string>(Consts.BlogFields.Title),
                Teaser = searchResult.GetValue<string>(Consts.BlogFields.Teaser),
                Content = searchResult.GetValue<string>(Consts.BlogFields.Content),
                Authors = searchResult.GetValue<IList<string>>(Consts.BlogFields.Authors),
                Tags = searchResult.GetValue<IList<string>>(Consts.BlogFields.Tags),
                PublishDate = searchResult.GetValue<DateTime>(Consts.BlogFields.PublishDate),
            };
        }
    }
}
