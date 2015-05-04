using System;
using Codestruction.Application.Contracts.Blog.Archive;
using Codestruction.Infrastructure;

namespace Codestruction.Application.Context
{
 

    public class UrlManager : IUrlManager
    {
        public string BlogApiListing(int page, int pageSize)
        {
            return string.Format("/umbraco/codestruction/blogapi/getlisting?page={0}&pageSize={1}", page, pageSize);
        }

        public string BlogApiArchive(IBlogArchiveRequest archiveRequest)
        {
            return ("/umbraco/codestruction/blogapi/getarchive").BuildFromClass(archiveRequest);
        }

        public string BlogArchiveDate(DateTime date)
        {
            return "/blog/archive/date/" + WebUtil.Tokenize(date.ToMonthYear());
        }

        public string BlogArchiveTags(string tag)
        {
            return "/blog/archive/tag/" + WebUtil.Tokenize(tag);
        }
    }
}
