using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for storing info on an Online Resource (DCPType node data).
    /// </summary>
    public class WmsOnlineResource : WmsElement
    {
        private bool _selfContained;

        public WmsOnlineResource(bool selfContained = true)
        {
            _selfContained = selfContained;
          
        }
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            // If element in selfcontained, then url is the first child.
            if (_selfContained)
            {
                HttpMethod = node.Name.LocalName;
                Url = node.Elements()?.FirstOrDefault()?.GetXLinkAttribute(HrefAttributeNode)?.Value;
            }
            else
            {
                Format = node.GetWmsElement(OnlineResourceNode, parsingContext)?.GetXLinkAttribute(HrefAttributeNode)?.Value;
                Format = node.GetWmsElement(FormatNode, parsingContext)?.Value;
            }
        }

        /// <summary>
        /// URI of online resource
        /// </summary>
        public string? Url { get; internal set; }

        /// <summary>
        /// Type of online resource (Ex. request method 'Get' or 'Post')
        /// </summary>
        public string? HttpMethod { get; internal set; }

        public string? Format { get; internal set; }

     
    }
}
