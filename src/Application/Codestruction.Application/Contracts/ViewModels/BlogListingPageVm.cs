using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codestruction.Application.Contracts.ViewModels
{
    public class BlogListingPageVm
    {
        public IList<BlogPostOverviewDto> BlogPosts { get; set; } 
    }
}
