using System.Collections.Generic;

namespace Codestruction.Application.Contracts.Shared
{
    public class ListingResponse<T>
    {
        public IList<T> Data { get; set; }
        public string DataUrl { get; set; }

        public ListingResponse()
        {
            Data = new List<T>();
        }

    }
}
