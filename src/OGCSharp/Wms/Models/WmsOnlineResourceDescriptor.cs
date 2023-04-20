using OGCSharp.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Represents a descriptor for wms online resources, found unde Capability/Request node.
    /// </summary>
    internal class WmsOnlineResourceDescriptor : WmsElement
    {
        public WmsOnlineResourceDescriptor(XElement xmlNode) : base(xmlNode)
        {
            var nodeContent = xmlNode.ParseRequestTypeBlock();

            OutputFormats = nodeContent.OutputFormats;
            OnlineResources = nodeContent.OnlineResources;
        }
    
        public IReadOnlyCollection<string> OutputFormats { get; }

        public IReadOnlyCollection<WmsOnlineResource> OnlineResources { get; }
    
    }
}
