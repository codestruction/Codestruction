namespace Codestruction.Infrastructure.Umbraco
{
    public class Consts
    {
        public class DocumentTypes
        {
            public static string BlogDetailsPage = "BlogDetailsPage";
        }
        public static class ContentIndexFields
        {
            public static string DocumentType = "nodeTypeAlias";
            public static string Tags = "tags";
            public static string TagsTokenized = "tags_tokenized";
            public static string AuthorsTokenized = "authors_tokenized";
            public static string Authors = "authors";
            public static string Teaser = "teaser";
            public static string PublishDate = "publishdate";
            public static string Url = "url";
            public static string Title = "title";
            public static string Content = "__Raw_content";

        }

        public static class TagGroups
        {
            public static string Blog = "BlogTags";
        }
        public static string ContentSearcher = "ContentSearcher";
    }
}
