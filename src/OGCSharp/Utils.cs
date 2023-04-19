using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Geo
{
    internal static class Utils
    {

        /// <summary>
        /// Downloads capabilities and returns them as an string.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string? DownloadCapabilites(string url)
        {
            //bypass certificate authentification
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = ((sender, cert, chain, errors) => true);

            //download capabilities content
            using (HttpClient client = new HttpClient(clientHandler))
            {
                using (HttpResponseMessage responseMessage = client.GetAsync(url).Result)
                {
                    return responseMessage.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
