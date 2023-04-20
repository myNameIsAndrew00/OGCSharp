using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// The Wms Service Description stores metadata parameters for a WMS service
    /// </summary>
    internal class WmsService : WmsElement
    {
        public WmsService(XElement xmlNode) : base(xmlNode)
        {
            Title = xmlNode.ElementUnprefixed(TitleNode)?.Value;
            OnlineResource = xmlNode.ElementUnprefixed(OnlineResourceNode)?.Attribute(XLinkHrefAttributeNode).Value;
            Abstract = xmlNode.ElementUnprefixed(AbstractNode)?.Value;
            Fees = xmlNode.ElementUnprefixed(FeesNode)?.Value;
            AccessConstraints = xmlNode.ElementUnprefixed(AccessConstraints)?.Value;

            Keywords = xmlNode.ElementUnprefixed(KeywordListNode)
                              .ElementsUnprefixed(KeywordNode).Select(keywordNode => keywordNode.Value).ToList()
                             ?? new List<string>();

            ContactInformation = new WmsContactInformation(xmlNode.ElementUnprefixed(ContactInformationNode));
            MaxWidth = xmlNode.ValueAsInt(MaxWidthNode);
            MaxHeight = xmlNode.ValueAsInt(MaxHeightNode);
        }

        /// <summary>
        /// Optional narrative description providing additional information
        /// </summary>
        public string Abstract { get; }

        /// <summary>
        /// <para>The optional element "AccessConstraints" may be omitted if it do not apply to the server. If
        /// the element is present, the reserved word "none" (case-insensitive) shall be used if there are no
        /// access constraints, as follows: "none".</para>
        /// <para>When constraints are imposed, no precise syntax has been defined for the text content of these elements, but
        /// client applications may display the content for user information and action.</para>
        /// </summary>
        public string AccessConstraints { get; }

        /// <summary>
        /// Optional WMS contact information
        /// </summary>
        public WmsContactInformation ContactInformation { get; }

        /// <summary>
        /// The optional element "Fees" may be omitted if it do not apply to the server. If
        /// the element is present, the reserved word "none" (case-insensitive) shall be used if there are no
        /// fees, as follows: "none".
        /// </summary>
        public string Fees { get; }

        /// <summary>
        /// Optional list of keywords or keyword phrases describing the server as a whole to help catalog searching
        /// </summary>
        public IReadOnlyCollection<string> Keywords { get; }

        /// <summary>
        /// Maximum number of layers allowed (0=no restrictions)
        /// </summary>
        public uint LayerLimit { get; }

        /// <summary>
        /// Maximum height allowed in pixels (0=no restrictions)
        /// </summary>
        public int MaxHeight { get; }

        /// <summary>
        /// Maximum width allowed in pixels (0=no restrictions)
        /// </summary>
        public int MaxWidth { get; }

        /// <summary>
        /// Mandatory Top-level web address of service or service provider.
        /// </summary>
        public string OnlineResource { get; }

        /// <summary>
        /// Mandatory Human-readable title for pick lists
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Public url to access the service in case service is hosted behind firewall
        /// </summary>
        public string PublicAccessURL { get; }
 
    }
}
