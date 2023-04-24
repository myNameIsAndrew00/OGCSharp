using OGCSharp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    public class WmsDocument : WmsElement
    {
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            Version = node.Attribute(VersionAttributeNode)?.Value switch
            {
                "1.0.0" => WmsVersion.V1_1_0,
                "1.1.0" => WmsVersion.V1_0_0,
                "1.3.0" => WmsVersion.V1_3_0,
                _ => WmsVersion.V1_3_0
            };

            parsingContext.Version = Version;

            var serviceNode = node.GetWmsElement(ServiceNode, parsingContext);

            if(serviceNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.DOCUMENT_SERVICE_ELEM_M);
                return;
            }

            var capabilityNode = node.GetWmsElement(CapabilityNode, parsingContext);

            if (capabilityNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.DOCUMENT_CAPABILITY_ELEM_M);
                return;
            }

            Service.Parse(serviceNode, parsingContext);
            Capability.Parse(capabilityNode, parsingContext);
        }

        public WmsVersion Version { get; internal set; } 

        public WmsService Service { get; internal set; } = new WmsService();

        public WmsCapability Capability { get; internal set; } = new WmsCapability();

      
    }
}
