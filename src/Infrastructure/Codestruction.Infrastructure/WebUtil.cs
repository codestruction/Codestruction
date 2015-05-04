using System.Collections.Generic;
using System.Linq;

namespace Codestruction.Infrastructure
{
    public static class WebUtil
    {
        private static readonly Dictionary<string, string> UrlReplace = new Dictionary<string, string>()
        {
            {" ", "-"},
            {":", string.Empty},
            {",", string.Empty},
            {".", string.Empty},
            {"&", "and"}
        };
        private static readonly Dictionary<string, string> IndexReplace = new Dictionary<string, string>()
        {
            {" ", "-"},
            {":", string.Empty},
            {".", string.Empty},
            {"&", "and"}
        }; 

        public static string Tokenize(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.ToLower();
                text=UrlReplace.Aggregate(text,
                    (current, dictionaryItem) => current.Replace(dictionaryItem.Key, dictionaryItem.Value));

                return text;
            }

            return string.Empty;
        }

        public static string TokenizeIndex(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.ToLower();
                text = IndexReplace.Aggregate(text,
                    (current, dictionaryItem) => current.Replace(dictionaryItem.Key, dictionaryItem.Value));

                return text;
            }

            return string.Empty;
        }
    }
}
