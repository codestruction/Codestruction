using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examine;

namespace Codestruction.Infrastructure.Umbraco
{
    public static class SearchResultExtensions
    {
        private static IDictionary<Type, Func<object>> Actions(string value)
        {
            return new Dictionary<Type, Func<object>>
            {
                {
                    typeof (DateTime?), () => value.ToDateTime()
                },
                {
                    typeof (DateTime), () => value.ToDateTime()
                },
                {
                    typeof (string), () => value.ToString()
                },
                {
                    typeof (IList<int>), value.ToIntList
                },
                {
                    typeof (IList<string>), value.ToStrList
                },
                {
                    typeof (int?), () => value.ToInt()
                },
                {
                    typeof (int), () => value.ToInt()
                }
            };

        }

        public static T GetValue<T>(this SearchResult sarchResult, string fieldName)
        {
            if (sarchResult.Fields.ContainsKey(fieldName))
            {
                return (T) Actions(sarchResult.Fields[fieldName])[typeof (T)].Invoke();
            }
            return default(T);
        }
    }
}
