
using GeoAPI.Geometries;
using System.Drawing;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for storing information about a WMS Layer Style
    /// </summary>
    public class WmsLayerStyle : WmsElement
    {
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            // According to 7.2.4.6.5, a style must have a title and a name, abstract and other inner elements are optional.
            var nameNode = node.GetWmsElement(NameNode, parsingContext);

            if (nameNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.LAYERSTYLE_NAME_ELEM_M);
                return;
            }

            var titleNode = node.GetWmsElement(TitleNode, parsingContext);

            if (titleNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.LAYERSTYLE_TITLE_ELEM_M);
                return;
            }


            Name = nameNode.Value;
            Title = titleNode.Value;
            Abstract = node.GetWmsElement(AbstractNode, parsingContext)?.Value;

            // Try to retrieve and parse legend and stylesheet nodes because they may be missing from layer.
            var legendNode = node.GetWmsElement(LegendUrlNode, parsingContext);
            var styleSheetNode = node.GetWmsElement(StyleSheetURLNode, parsingContext);

            if (legendNode != null)
            {
                LegendUrl = new WmsOnlineResource(false);
                LegendUrl.Parse(legendNode, parsingContext);

                LegendSize = new Size(
                    legendNode.AttributeAsInt(WidthAttributeNode),
                    legendNode.AttributeAsInt(HeightAttributeNode)
                    );
            }
            if (styleSheetNode != null)
            {
                StyleSheetUrl = new WmsOnlineResource(false);
                StyleSheetUrl.Parse(styleSheetNode, parsingContext);
            }
        }

        /// <summary>
        /// Abstract
        /// </summary>
        public string? Abstract { get; internal set; }

        /// <summary>
        /// Legend
        /// </summary>
        public WmsOnlineResource? LegendUrl { get; internal set; }

        public Size? LegendSize { get; internal set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; internal set; } = null!;

        /// <summary>
        /// Style Sheet Url
        /// </summary>
        public WmsOnlineResource? StyleSheetUrl { get; internal set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; internal set; } = null!;

        public Envelope? LatLonBoundingBox { get; internal set; }


    }
}
