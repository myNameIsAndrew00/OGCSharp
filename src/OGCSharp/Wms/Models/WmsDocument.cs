using OGCSharp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    internal class WmsDocument : WmsElement
    {
        public WmsDocument(XElement xmlNode) : base(xmlNode)
        {
            Service = new WmsService(xmlNode.ElementUnprefixed(ServiceNode)!);
            Capability = new WmsCapability(xmlNode.ElementUnprefixed(CapabilityNode)!);
        }

        public string? Version => _xmlNode.Attribute(VersionAttributeNode)?.Value;

        public WmsService Service { get; }

        public WmsCapability Capability { get; }

    }
}
