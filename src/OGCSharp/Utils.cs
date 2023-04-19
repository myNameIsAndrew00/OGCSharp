using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
