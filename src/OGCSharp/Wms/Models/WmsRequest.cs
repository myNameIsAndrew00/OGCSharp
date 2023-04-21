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
    /// This element is defined according to section 6.3 from WMS Implementation specification.
    /// </summary>
    internal class WmsRequest : WmsElement
    {

        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            GetMap.Parse(node.GetWmsElement(GetMapNode, parsingContext), parsingContext);
            GetCapabilities.Parse(node.GetWmsElement(GetCapabilitiesNode, parsingContext), parsingContext);


            var featureInfoNode = node.GetWmsElement(GetFeatureInfoNode, parsingContext);
            if (featureInfoNode != null)
            {
                GetFeatureInfo = new WmsOnlineResourceDescriptor();
                GetFeatureInfo.Parse(featureInfoNode, parsingContext);
            }

            var describeLayerNode = node.Element(WmsConstants.Sld + DescribeLayerNode);
            if (describeLayerNode != null)
            {
                DescribeLayer = new WmsOnlineResourceDescriptor();
                DescribeLayer.Parse(describeLayerNode, parsingContext);
            }

            var legendGraphicNode = node.Element(WmsConstants.Sld + GetLegendGraphicNode);
            if (legendGraphicNode != null)
            {
                GetLegendGraphic = new WmsOnlineResourceDescriptor();
                GetLegendGraphic.Parse(legendGraphicNode, parsingContext);
            }

            var getStylesNode = node.Element(WmsConstants.MapServer + GetStylesNode);
            if (getStylesNode != null)
            {
                GetStyles = new WmsOnlineResourceDescriptor();
                GetStyles.Parse(getStylesNode, parsingContext);
            }

            var putStylesNode = node.Element(WmsConstants.MapServer + PutStylesNode);
            if (putStylesNode != null)
            {
                PutStyles = new WmsOnlineResourceDescriptor();
                PutStyles.Parse(putStylesNode, parsingContext);
            }
        }

        public WmsOnlineResourceDescriptor GetMap { get; internal set; } = new WmsOnlineResourceDescriptor();

        public WmsOnlineResourceDescriptor GetCapabilities { get; internal set; } = new WmsOnlineResourceDescriptor();

        public WmsOnlineResourceDescriptor? GetFeatureInfo { get; internal set; }

        public WmsOnlineResourceDescriptor? DescribeLayer { get; internal set; }

        public WmsOnlineResourceDescriptor? GetLegendGraphic { get; internal set; }

        public WmsOnlineResourceDescriptor? GetStyles { get; internal set; }

        public WmsOnlineResourceDescriptor? PutStyles { get; internal set; }


    }
}
