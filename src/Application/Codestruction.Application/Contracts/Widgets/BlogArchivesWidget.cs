using System.Collections.Generic;

namespace Codestruction.Application.Contracts.Widgets
{
    public class BlogArchivesWidget
    {
        public string Title { get; set; }
        public IList<LinkVm> Links { get; set; } 
    }
}
