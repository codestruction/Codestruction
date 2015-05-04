using Codestruction.Application.Contracts.Blog;
using Codestruction.Infrastructure;

namespace Codestruction.Application.Factories
{
    public class BlogFactory
    {
        public AuthorDto BuildAuthor(string author)
        {
            return new AuthorDto()
            {
                Name = author,
                Url = "/blog/archive/author/" + WebUtil.Tokenize(author)
            };
        }

        public TagDto BuildTag(string tag)
        {
            return new TagDto()
            {
                Name = tag,
                Url = "/blog/archive/tag/" + WebUtil.Tokenize(tag)
            };
        }
    }
}
