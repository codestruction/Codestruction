using System;
using System.Collections.Generic;
using System.Web;

namespace Codestruction.Infrastructure
{
    public static class HttpExtensions
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return uri;
            }
            var ub = new UriBuilder(uri);

            // decodes urlencoded pairs from uri.Query to HttpValueCollection
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);

            httpValueCollection.Add(name, value);

            // urlencodes the whole HttpValueCollection
            ub.Query = httpValueCollection.ToString();

            return ub.Uri;
        }

        public static string AddQuery(this string url, string name, string value)
        {
            //if (string.IsNullOrEmpty(value))
            //{
            //    return url;
            //}

            var query = string.Empty;
            var rawUrl = url;


            var questionMarkIndex = url.IndexOf("?", System.StringComparison.Ordinal);
            if (questionMarkIndex != -1)
            {
                query = url.Substring(questionMarkIndex + 1);
                rawUrl = url.Substring(0, questionMarkIndex);
            }

            // decodes urlencoded pairs from uri.Query to HttpValueCollection
            var httpValueCollection = HttpUtility.ParseQueryString(query);

            httpValueCollection.Add(name, value);

            return rawUrl + "?" + httpValueCollection.ToString();
        }
        public static string BuildFromClass<T>(this string url, T parameters)
        {
            var uri = url;

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var queryParameterName = property.Name.ToLower();

                if (property.PropertyType == typeof(IList<string>))
                {
                    var values = property.GetValue(parameters) as IList<string>;
                    if (values != null)
                    {
                        foreach (var v in values)
                        {
                            uri = uri.AddQuery(queryParameterName, v);
                        }
                    }
                }

                if (property.PropertyType == typeof(IList<int>))
                {
                    var values = property.GetValue(parameters) as List<int>;
                    if (values != null)
                    {
                        foreach (var v in values)
                        {
                            uri = uri.AddQuery(queryParameterName, v.ToString());
                        }
                    }
                }
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(parameters) as string;
                    if (!string.IsNullOrEmpty(value))
                    {
                        var valArray = value.Split('&');
                        foreach (var val in valArray)
                        {
                            if (!string.IsNullOrEmpty(val))
                            {
                                uri = uri.AddQuery(queryParameterName, val);
                            }
                        }
                    }
                }
                if (property.PropertyType == typeof(int?))
                {
                    var value = property.GetValue(parameters) as int?;
                    if (value.HasValue)
                    {
                        uri = uri.AddQuery(queryParameterName, value.Value.ToString());
                    }
                }
                if (property.PropertyType == typeof(int))
                {
                    var value = property.GetValue(parameters);
                    if (value != null)
                    {
                        uri = uri.AddQuery(queryParameterName, ((int)value).ToString());
                    }
                }
            }

            return uri.ToString();


        }

    }

}
