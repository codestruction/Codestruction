using System.Collections.Generic;

namespace Codestruction.Application.Contracts.Widgets
{
    public class BlogTagsWidget
    {
        public IList<TagVm> Tags { get; set; }

        public BlogTagsWidget()
        {
            Tags = new List<TagVm>();
        }
    }
}
