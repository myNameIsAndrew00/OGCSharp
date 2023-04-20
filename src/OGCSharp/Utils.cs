using OGCSharp.Wms.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace OGCSharp.Geo
{
    internal static class Utils
    {

        /// <summary>
        /// Downloads capabilities and returns them as an string.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<XElement?> DownloadCapabilitesAsync(string url)
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
                        string? rawResponse = await responseMessage.Content.ReadAsStringAsync();

                        if (rawResponse != null)
                        {
                            return XElement.Parse(rawResponse);
                        }
                    }
                }
            }
            catch
            {
                // If any exception occurs during processing, fallback result is null.
            }

            return null;
        }

        /// <summary>
        /// Use this method to extract type information from types.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static (IReadOnlyCollection<string> OutputFormats, IReadOnlyCollection<WmsOnlineResource> OnlineResources) ParseRequestTypeBlock(this XElement node)
        {
            XElement? dctType = node.ElementUnprefixed(WmsElement.DCPTypeNode)
                                   ?.ElementUnprefixed(WmsElement.HTTPNode);

            // Retrieve online resources under http node.
            var onlineResources = dctType?.Elements().Select(xElement => new WmsOnlineResource(xElement)).ToList() ?? new List<WmsOnlineResource>();

            // Retrieve output formats (format node).
            var outputFormats = node.ElementsUnprefixed(WmsElement.FormatNode).Select(xElement => xElement.Value).ToList() ?? new List<string>();

            return (outputFormats, onlineResources);
        }


        /// <summary>
        /// Try to retrieve epsg value from a bounding box node.
        /// </summary>
        /// <param name="bbox"></param>
        /// <returns></returns>
        public static int? GetEpsg(this XElement bbox)
        {
            // Retrieve the attribute which contains epsg information.
            XAttribute? epsgNode = ((bbox.Attribute("srs") ?? bbox.Attribute("crs")) ?? bbox.Attribute("SRS")) ?? bbox.Attribute("CRS");

            if (epsgNode == null)
            {
                return null;
            }

            // Try to parse epsg string to decimal representation and return.
            const string prefix = "EPSG:";
            string epsgString = epsgNode.Value;

            int index = epsgString.IndexOf(prefix, StringComparison.InvariantCulture);

            if (index < 0)
            {
                return null;
            }

            return Int32.TryParse(epsgString.Substring(index + prefix.Length), out int epsg)
                ? epsg : null;
        }

        public static string AppendQueryString(this string uri, params (string Key, string Value)[] query)
        {
            StringBuilder sb = new StringBuilder(uri);

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
