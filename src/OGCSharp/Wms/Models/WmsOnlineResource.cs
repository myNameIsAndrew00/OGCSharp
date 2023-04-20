
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for storing info on an Online Resource (DCPType node data).
    /// </summary>
    internal class WmsOnlineResource : WmsElement
    {
        public WmsOnlineResource(XElement xmlNode, bool selfContained = true) : base(xmlNode)
        {
            // If element in selfcontained, then url is the first child.
            if (selfContained)
            {
                HttpMethod = xmlNode.Name.LocalName;
                Url = xmlNode.Elements()?.FirstOrDefault()?.Attribute("xlink:href")?.Value;
            }
            else
            {
                Format = xmlNode.ElementUnprefixed(OnlineResourceNode)?.Attribute($"xlink:{HrefAttributeNode}")?.Value;
                Format = xmlNode.ElementUnprefixed(FormatNode)?.Value;
            }
        }

        /// <summary>
        /// URI of online resource
        /// </summary>
        public string? Url { get; }

        /// <summary>
        /// Type of online resource (Ex. request method 'Get' or 'Post')
        /// </summary>
        public string? HttpMethod { get; }

        public string? Format { get; }
    }
}
