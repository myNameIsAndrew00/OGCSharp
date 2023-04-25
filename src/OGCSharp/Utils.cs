using OGCSharp.Wms;
using OGCSharp.Wms.Models;
using System.Xml;
using System.Xml.Linq;


namespace OGCSharp.Geo
{
    internal static class Utils
    {

      

        /// <summary>
        /// Use this method to extract type information from types.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static (IReadOnlyCollection<string> OutputFormats, IReadOnlyCollection<WmsOnlineResource> OnlineResources) ParseRequestTypeBlock(this XElement node, WmsParsingContext parsingContext)
        {
            XElement? dctType = node.GetWmsElement(WmsElement.DCPTypeNode, parsingContext)
                                   ?.GetWmsElement(WmsElement.HTTPNode, parsingContext);

            // Retrieve online resources under http node.
            var onlineResources = dctType?.Elements().Select(xElement =>
            {
                var resource = new WmsOnlineResource();
                resource.Parse(xElement, parsingContext);

                return resource;
            }).ToList() ?? new List<WmsOnlineResource>();

            // Retrieve output formats (format node).
            var outputFormats = node.GetWmsElements(WmsElement.FormatNode, parsingContext).Select(xElement => xElement.Value).ToList() ?? new List<string>();

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


        public static XElement? ToXElement(this XmlDocument xmlDocument)
        {
            if (xmlDocument is null)
            {
                return null;
            }

            XDocument document = XDocument.Load(xmlDocument.CreateNavigator().ReadSubtree());

            return document.Root;
        }

    }
}
