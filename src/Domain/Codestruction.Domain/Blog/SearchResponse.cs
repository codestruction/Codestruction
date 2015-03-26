using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codestruction.Domain.Blog
{
    public class SearchResponse<TResponseType>
    {
        public IList<TResponseType> Data;

        public int Count;

        public bool HasMoreResults { get; set; }

        public SearchResponse()
        {
            Data = new List<TResponseType>();
        }

    }
}
