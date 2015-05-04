using System;
using Codestruction.Application.Contracts.Blog.Archive;

namespace Codestruction.Application.Context
{
    public interface IUrlManager
    {
        string BlogApiListing(int page, int pageSize);
        string BlogApiArchive(IBlogArchiveRequest archiveRequest);
        string BlogArchiveDate(DateTime date);
        string BlogArchiveTags(string tag);
    }
}
