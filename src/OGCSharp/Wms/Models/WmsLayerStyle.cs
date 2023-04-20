
using GeoAPI.Geometries;
using System.Drawing;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for storing information about a WMS Layer Style
    /// </summary>
    internal class WmsLayerStyle : WmsElement
    {
        public WmsLayerStyle(XElement xmlNode) : base(xmlNode)
        {
            Name = xmlNode.ElementUnprefixed(NameNode)?.Value;
            Title = xmlNode.ElementUnprefixed(TitleNode)?.Value;
            Abstract = xmlNode.ElementUnprefixed(AbstractNode)?.Value;

            // Try to retrieve and parse legend and stylesheet nodes because they may be missing from layer.
            var legendNode = xmlNode.ElementUnprefixed(LegendUrlNode);
            var styleSheetNode = xmlNode.ElementUnprefixed(StyleSheetURLNode);
            
            if (legendNode != null)
            {
                LegendUrl = new WmsOnlineResource(legendNode, false);
                LegendSize = new Size(
                    legendNode.AttributeAsInt(WidthAttributeNode),
                    legendNode.AttributeAsInt(HeightAttributeNode)
                    );
            }
            if (styleSheetNode != null)
            {
                StyleSheetUrl = new WmsOnlineResource(styleSheetNode, false);
            }
        }

        /// <summary>
        /// Abstract
        /// </summary>
        public string Abstract { get; }

        /// <summary>
        /// Legend
        /// </summary>
        public WmsOnlineResource? LegendUrl { get; }

        public Size? LegendSize { get; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Style Sheet Url
        /// </summary>
        public WmsOnlineResource? StyleSheetUrl { get; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; }
    
        public Envelope? LatLonBoundingBox { get; }
    }
}
