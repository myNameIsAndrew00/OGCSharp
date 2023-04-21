using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// The Wms Service Description stores metadata parameters for a WMS service
    /// </summary>
    internal class WmsService : WmsElement
    {
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            Title = node.GetWmsElement(TitleNode, parsingContext)?.Value;
            OnlineResource = node.GetWmsElement(OnlineResourceNode, parsingContext)?.GetXLinkAttribute(HrefAttributeNode)?.Value;
            Abstract = node.GetWmsElement(AbstractNode, parsingContext)?.Value;
            Fees = node.GetWmsElement(FeesNode, parsingContext)?.Value;
            AccessConstraints = node.GetWmsElement(AccessConstraintsNode, parsingContext)?.Value;

            Keywords = node.GetWmsElement(KeywordListNode, parsingContext)
                           ?.GetWmsElements(KeywordNode, parsingContext).Select(keywordNode => keywordNode.Value).ToList()
                             ?? new List<string>();

            // According to 7.2.4.3, contact info SHOULD be included.
            var contactInformationNode = node.GetWmsElement(ContactInformationNode, parsingContext);

            if(contactInformationNode != null)
            {
                ContactInformation = new WmsContactInformation();
                ContactInformation.Parse(contactInformationNode, parsingContext);
            }

            MaxWidth = node.ValueAsInt(MaxWidthNode, parsingContext);
            MaxHeight = node.ValueAsInt(MaxHeightNode, parsingContext);
        }

        /// <summary>
        /// Optional narrative description providing additional information
        /// </summary>
        public string? Abstract { get; internal set; }

        /// <summary>
        /// <para>The optional element "AccessConstraints" may be omitted if it do not apply to the server. If
        /// the element is present, the reserved word "none" (case-insensitive) shall be used if there are no
        /// access constraints, as follows: "none".</para>
        /// <para>When constraints are imposed, no precise syntax has been defined for the text content of these elements, but
        /// client applications may display the content for user information and action.</para>
        /// </summary>
        public string? AccessConstraints { get; internal set; }

        /// <summary>
        /// Optional WMS contact information
        /// </summary>
        public WmsContactInformation? ContactInformation { get; internal set; }

        /// <summary>
        /// The optional element "Fees" may be omitted if it do not apply to the server. If
        /// the element is present, the reserved word "none" (case-insensitive) shall be used if there are no
        /// fees, as follows: "none".
        /// </summary>
        public string? Fees { get; internal set; }

        /// <summary>
        /// Optional list of keywords or keyword phrases describing the server as a whole to help catalog searching
        /// </summary>
        public IReadOnlyCollection<string> Keywords { get; internal set; } = null!;

        /// <summary>
        /// Maximum number of layers allowed (0=no restrictions)
        /// </summary>
        public uint LayerLimit { get; internal set; }

        /// <summary>
        /// Maximum height allowed in pixels (0=no restrictions)
        /// </summary>
        public int MaxHeight { get; internal set; }

        /// <summary>
        /// Maximum width allowed in pixels (0=no restrictions)
        /// </summary>
        public int MaxWidth { get; internal set; }

        /// <summary>
        /// Mandatory Top-level web address of service or service provider.
        /// </summary>
        public string? OnlineResource { get; internal set; }

        /// <summary>
        /// Mandatory Human-readable title for pick lists
        /// </summary>
        public string? Title { get; internal set; }

        /// <summary>
        /// Public url to access the service in case service is hosted behind firewall
        /// </summary>
        public string? PublicAccessURL { get; internal set; }

       
    }
}
