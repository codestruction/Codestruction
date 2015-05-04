namespace Codestruction.Infrastructure.Umbraco
{
    public static class LuceneExtensions
    {
        public static string RightWildcard(this string query)
        {
            return query + "*";
        }
    }
}
