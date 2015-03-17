using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codestruction.Domain.Blog
{
    public interface IBlogPostOverview
    {
        string Title { get; set; }
        string Content { get; set; }
    }
}
