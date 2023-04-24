using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Layers
{
    internal static class Utils
    {
        public static string AppendQueryString(this string uri, params (string Key, string Value)[] query)
        {
            StringBuilder sb = new StringBuilder(uri.Trim('&'));

            // If uri doesnt contain any '?' then it must be append to the end of it.
            if (!uri.Contains("?"))
            {
                sb.Append("?");
            }

            // Append query parameters and return result.
            sb.Append(string.Join('&', query.Select(pair => $"{pair.Key}={pair.Value}")));

            return sb.ToString();
        }
    }
}
