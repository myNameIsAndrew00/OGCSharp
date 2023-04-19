using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OGCSharp.Geo.WMS
{
    /// <summary>
    /// This class should be used for parsing WMS Capabilities.
    /// Supported version is 1.30
    /// </summary>
    internal class WMSCapabilitiesParser : IGeoCapabilitiesParser
    {
        private const int maxLevel = 1000;

        public OGCServerType Type => OGCServerType.WMS;

        public ICollection<ILayer>? ParseCapabilities(string url)
        {
            try
            {
                // Get xml document.
                XmlDocument xmlDocument = DownloadCapabilites(url);

                return ParseMapCapabilitiesInternal(xmlDocument);
            }
            catch
            {
                return null;
            }
        }

        public ICollection<ILayer>? ParseCapabilities(XmlDocument xmlDocument) => ParseMapCapabilitiesInternal(xmlDocument);


        #region private 

        public static List<ILayer> ParseMapCapabilitiesInternal(XmlDocument xmlDocument)
        {
            try
            {
                List<WMSLayer> layers = null;

                string baseMapUrl = GetBaseMapUrl(xmlDocument);

                // Create navigator for layer node.
                var layerElement = xmlDocument.GetElementsByTagName("Layer")?[0];

                // Get layers.
                layers = GetLayers(0, layerElement);

                // Remove if it is the last ? symbol.
                baseMapUrl = baseMapUrl.Trim('?');

                var querySymbol = baseMapUrl.Contains("?") ? "&" : "?";

                // Construct url for each layer.
                layers.ForEach(p => p.URL = p.Name != null ? $"{baseMapUrl}{querySymbol}LAYERS={p.Name}" : null);


                // Filter layers.
                layers = layers.Where(p => p.URL != null).ToList();

                return layers.Cast<ILayer>().ToList();
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Downloads capabilities and returns them as an XmlDocument.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static XmlDocument DownloadCapabilites(string url)
        {
            //bypass certificate authentification
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = ((sender, cert, chain, errors) => true);

            XmlDocument xmlDocument = new XmlDocument();

            //download capabilities content
            using (HttpClient client = new HttpClient(clientHandler))
            {
                using (HttpResponseMessage responseMessage = client.GetAsync(url).Result)
                {
                    using (Stream stream = responseMessage.Content.ReadAsStreamAsync().Result)
                    {
                        //create XmlDocument
                        xmlDocument.Load(stream);
                    }
                }
            }

            return xmlDocument;
        }

        /// <summary>
        /// Gets baseMap url.
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        private static string GetBaseMapUrl(XmlDocument xmlDocument)
        {
            var mapElement = xmlDocument.GetElementsByTagName("GetMap")?[0];
            var onlineResourceElement = Navigate(mapElement, "OnlineResource");

            return onlineResourceElement?.Attributes["xlink:href"]?.Value;
        }

        /// <summary>
        /// Navigate through the given navigator for looking the first node with the given nodeName.
        /// </summary>
        /// <param name="navigator"></param>
        /// <param name="nodeName"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private static XmlNode Navigate(XmlNode rootNode, string nodeName, int level = 0)
        {
            if (level > maxLevel)
                return null;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == nodeName)
                    return node;

                var currentnode = Navigate(node, nodeName, level + 1);

                if (currentnode != null)
                    return currentnode;
            }

            return null;
        }

        /// <summary>
        /// Gets all child nodes with the specified nodeName.
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <param name="nodeName"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private static List<XmlNode> GetXmlNodes(XmlNode xmlNode, string nodeName)
        {
            var nodes = new List<XmlNode>();
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name == nodeName)
                {
                    nodes.Add(node);
                }
            }

            return nodes;
        }

        /// <summary>
        /// Get a list containing all layers
        /// </summary>
        /// <param name="level"></param>
        /// <param name="navigator"></param>
        /// <returns></returns>
        private static List<WMSLayer> GetLayers(int level, XmlNode currentNode)
        {
            if (level > maxLevel || currentNode == null)
                return null;

            // List of layers for return.
            List<WMSLayer> layers = new List<WMSLayer>();
            var currentLayer = new WMSLayer();

            // First element in list is the current layer.
            layers.Add(currentLayer);

            currentLayer.Children = new List<WMSLayer>();
            currentLayer.Title = currentNode["Title"]?.InnerText;
            currentLayer.Name = currentNode["Name"]?.InnerText;

            // Parse Dimensions.
            try
            {
                var dimensions = GetXmlNodes(currentNode, "Dimension");
                var extents = GetXmlNodes(currentNode, "Extent");

                // Parse Time Dimension.
                currentLayer.TimeDimensions = ParseTimeDimension(dimensions.FirstOrDefault(x => x.Attributes["name"]?.Value == "time"));

                // Parse elevations.
                currentLayer.Elevations = ParseElevation(dimensions.FirstOrDefault(x => x.Attributes["name"]?.Value == "elevation"),
                                                         extents.FirstOrDefault(x => x.Attributes["name"]?.Value == "elevation"));
            }
            catch { }

            // Get and parse Child Layers.
            var childNodesLayers = GetXmlNodes(currentNode, "Layer");
            foreach (var layer in childNodesLayers)
            {
                var childLayers = GetLayers(level + 1, layer);
                if (childLayers != null)
                {
                    currentLayer.Children.Add(childLayers[0]);
                    layers.AddRange(childLayers);
                }
            }

            return layers.Any() ? layers : null;
        }

        /// <summary>
        /// Parses Time Dimensions.
        /// </summary>
        /// <param name="timeNode"></param>
        /// <returns></returns>
        private static List<Dimension<DateTime, TimeSpan>> ParseTimeDimension(XmlNode timeNode)
        {
            if (timeNode == null)
            {
                return null;
            }

            // Extract Units.
            var units = timeNode.Attributes["units"].InnerText;
            if (units == null)
            {
                return null;
            }

            var dimensions = new List<Dimension<DateTime, TimeSpan>>();

            // Get the list of values.
            var lines = timeNode.InnerText.Replace(" ", string.Empty).Split(",");

            foreach (var line in lines)
            {
                var tokens = line.Split('/');
                if (tokens.Length == 3)
                {
                    dimensions.Add(new Dimension<DateTime, TimeSpan>
                    {
                        RawData = line,
                        Start = DateTime.Parse(tokens[0]),
                        End = DateTime.Parse(tokens[1]),
                        Resolution = XmlConvert.ToTimeSpan(tokens[2]),
                        IsInterval = true
                    });
                }
                else
                {
                    dimensions.Add(new Dimension<DateTime, TimeSpan>
                    {
                        RawData = line,
                        IsInterval = false
                    });
                }
            }

            return dimensions;
        }

        private static List<Dimension<decimal, decimal>> ParseElevation(XmlNode elevationNode, XmlNode extentNode)
        {
            if (elevationNode == null)
            {
                return null;
            }
            var dimensions = new List<Dimension<decimal, decimal>>();

            string[] lines;
            // Get the list of values.
            if (extentNode == null)
            {
                lines = elevationNode.InnerText.Replace(" ", string.Empty).Split(",");
            }
            else
            {
                lines = extentNode.InnerText.Replace(" ", string.Empty).Split(",");
            }

            foreach (var line in lines)
            {
                var tokens = line.Split('/');
                if (tokens.Length == 3)
                {
                    dimensions.Add(new Dimension<decimal, decimal>
                    {
                        RawData = line,
                        Start = decimal.Parse(tokens[0]),
                        End = decimal.Parse(tokens[1]),
                        Resolution = int.Parse(tokens[2]),
                        IsInterval = true
                    });
                }
                else
                {
                    dimensions.Add(new Dimension<decimal, decimal>
                    {
                        RawData = line,
                        IsInterval = false
                    });
                }
            }

            // Remove interval elevation. This lione should be removed.
            dimensions = dimensions.Where(x => !x.IsInterval).ToList();

            return dimensions;


        }

    
    }

    #endregion
}
