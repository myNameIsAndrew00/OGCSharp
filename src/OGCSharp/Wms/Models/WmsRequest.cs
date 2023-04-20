using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// This element is defined according to section 6.3 from WMS Implementation specification.
    /// </summary>
    internal class WmsRequest : WmsElement
    {
        public WmsRequest(XElement xmlNode) : base(xmlNode)
        {
            GetMap = new WmsOnlineResourceDescriptor(xmlNode.ElementUnprefixed(GetMapNode));
            GetCapabilities = new WmsOnlineResourceDescriptor(xmlNode.ElementUnprefixed(GetCapabilitiesNode));
            GetFeatureInfo = new WmsOnlineResourceDescriptor(xmlNode.ElementUnprefixed(GetFeatureInfoNode));
            DescribeLayer = new WmsOnlineResourceDescriptor(xmlNode.ElementUnprefixed(DescribeLayerNode));
            GetLegendGraphic = new WmsOnlineResourceDescriptor(xmlNode.ElementUnprefixed(GetLegendGraphicNode));
            GetStyles = new WmsOnlineResourceDescriptor(xmlNode.ElementUnprefixed(GetStylesNode));
            PutStyles = new WmsOnlineResourceDescriptor(xmlNode.ElementUnprefixed(PutStylesNode));
        }

        public WmsOnlineResourceDescriptor GetMap { get; }

        public WmsOnlineResourceDescriptor GetCapabilities { get; } 

        public WmsOnlineResourceDescriptor GetFeatureInfo { get; }

        public WmsOnlineResourceDescriptor DescribeLayer { get; }   

        public WmsOnlineResourceDescriptor GetLegendGraphic { get; }

        public WmsOnlineResourceDescriptor GetStyles { get; }

        public WmsOnlineResourceDescriptor PutStyles { get; }
    }
}
