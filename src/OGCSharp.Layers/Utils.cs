using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OGCSharp.Layers
{
    internal static class Utils
    {
        /// <summary>
        /// Downloads capabilities and returns them as an string.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<XmlDocument?> DownloadCapabilitesAsync(string url)
        {
            // Bypass certificate authentification
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = ((sender, cert, chain, errors) => true);

            try
            {
                // Download capabilities content then parse it to a XElement.
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                    {
                        var result = new XmlDocument();

                        result.Load(await responseMessage.Content.ReadAsStreamAsync());

                        return result;
                    }
                }
            }
            catch
            {
                // If any exception occurs during processing, fallback result is null.
            }

            return null;
        }

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
