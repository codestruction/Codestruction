using System;
using System.Collections.Generic;
using Codestruction.Domain.Blog;
using Examine;
using Umbraco.Web;

namespace Codestruction.Infrastructure.Umbraco
{
    public class BlogPostFactory : IBlogPostFactory
    {
        public IBlogPostOverview BuildOverview(SearchResult searchResult)
        {
            var item = UmbracoContext.Current.ContentCache.GetById(searchResult.Id);

            return new BlogPost()
            {
                Title = searchResult.GetValue<string>(Consts.ContentIndexFields.Title),
                Teaser = searchResult.GetValue<string>(Consts.ContentIndexFields.Teaser),
                Content = searchResult.GetValue<string>(Consts.ContentIndexFields.Content),
                Authors = searchResult.GetValue<IList<string>>(Consts.ContentIndexFields.Authors),
                Tags = searchResult.GetValue<IList<string>>(Consts.ContentIndexFields.Tags),
                PublishDate = searchResult.GetValue<DateTime>(Consts.ContentIndexFields.PublishDate),
                Url = item != null ? item.Url : String.Empty//csearchResult.GetValue<string>(Consts.ContentIndexFields.Url),
            };
        }

    }
}
