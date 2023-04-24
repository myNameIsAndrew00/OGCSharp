using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// This element is defined according to section 6.3 from WMS Implementation specification.
    /// </summary>
    public class WmsRequest : WmsElement
    {

        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            // Get map node and get capabilities node are mandatory.
            var getMapNode = node.GetWmsElement(GetMapNode, parsingContext);

            if(getMapNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.REQUEST_GETMAP_ELEM_M);
                return;
            }

            var getCapabilitiesNode = node.GetWmsElement(GetCapabilitiesNode, parsingContext);

            if(getCapabilitiesNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.REQUEST_GETCAPABILITIES_ELEM_M);
                return;
            }

            GetMap.Parse(getMapNode, parsingContext);
            GetCapabilities.Parse(getCapabilitiesNode, parsingContext);


            var featureInfoNode = node.GetWmsElement(GetFeatureInfoNode, parsingContext);
            if (featureInfoNode != null)
            {
                GetFeatureInfo = new WmsOnlineResourceDescriptor();
                GetFeatureInfo.Parse(featureInfoNode, parsingContext);
            }

            var describeLayerNode = node.Element(WmsNamespaces.Sld + DescribeLayerNode);
            if (describeLayerNode != null)
            {
                DescribeLayer = new WmsOnlineResourceDescriptor();
                DescribeLayer.Parse(describeLayerNode, parsingContext);
            }

            var legendGraphicNode = node.Element(WmsNamespaces.Sld + GetLegendGraphicNode);
            if (legendGraphicNode != null)
            {
                GetLegendGraphic = new WmsOnlineResourceDescriptor();
                GetLegendGraphic.Parse(legendGraphicNode, parsingContext);
            }

            var getStylesNode = node.Element(WmsNamespaces.MapServer + GetStylesNode);
            if (getStylesNode != null)
            {
                GetStyles = new WmsOnlineResourceDescriptor();
                GetStyles.Parse(getStylesNode, parsingContext);
            }

            var putStylesNode = node.Element(WmsNamespaces.MapServer + PutStylesNode);
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
