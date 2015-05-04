using System;
using System.Collections.Generic;
using System.Linq;
using Examine.SearchCriteria;
using Lucene.Net.Documents;

namespace Codestruction.Infrastructure.Umbraco
{
    public static class ExamineExtensions
    {
        public const string DateFormat = "dd-MM-yyyy";
        public const char Delimiter = ',';
        public const string EmptyValue = "NA";

        public static string ToIndex(this string value, bool useLuceneEmpty = false)
        {
            if (string.IsNullOrEmpty(value))
            {
                return useLuceneEmpty ? EmptyValue : string.Empty;
            }
            return value;
        }
        public static string ToIndex(this int? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString();
            }
            return string.Empty;
        }

        public static string ToIndex(this DateTime? value)
        {
            if (value.HasValue)
            {
                return ToIndex(value.Value);
            }
            return string.Empty;
        }
        public static string ToIndex(this DateTime value)
        {
            return DateTools.DateToString(value, DateTools.Resolution.MILLISECOND);//value.ToString(DateFormat));
        }


        public static DateTime? ToDateTime(this string value)
        {

            if (!string.IsNullOrEmpty(value))
            {
                var date = DateTools.StringToDate(value);
                if (!(date == DateTime.MinValue || date == DateTime.MaxValue))
                {
                    return date;
                }
                //DateTime dt = DateTime.MinValue;
                //if (DateTime.TryParse(value, out dt))
                //{
                //    return dt;
                //}
            }
            return null;
        }

        public static IList<int> ToIntList(this string value)
        {
            var intList = new List<int>();

            if (!string.IsNullOrEmpty(value))
            {
                intList = value.Split(Delimiter).ToList().Select(int.Parse).ToList();
            }

            return intList;
        }
            public static IList<string> ToStrList(this string value)
        {
            var intList = new List<string>();

            if (!string.IsNullOrEmpty(value))
            {
                intList = value.Split(Delimiter).ToList().ToList();
            }

            return intList;
        }
        public static int? ToInt(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int returnValue = 0;
                if (int.TryParse(value, out returnValue))
                {
                    return returnValue;
                }
            }
            return null;
        }
        public static string ToIndex(this IList<int> ids)
        {
            if (ids == null)
                return string.Empty;

            return string.Join(Delimiter.ToString(), ids);
        }
        public static string ToIndex(this Guid? id)
        {
            if (id.HasValue)
            {
                return id.Value.ToString();
            }
            return string.Empty;
        }
        public static ISearchCriteria AddRawQueries(this IBooleanOperation booleanOperation, IEnumerable<string> customQueries)
        {
            var criteria = booleanOperation.Compile();
            foreach (var customQuery in customQueries)
            {
                if (!string.IsNullOrEmpty(customQuery))
                {
                    criteria = criteria.RawQuery(customQuery);
                }
            }
            return criteria;
        }
    }
}
