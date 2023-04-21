using OGCSharp.Geo;
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
    /// Represents a descriptor for wms online resources, found unde Capability/Request node.
    /// </summary>
    internal class WmsOnlineResourceDescriptor : WmsElement
    {
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            var nodeContent = node.ParseRequestTypeBlock(parsingContext);

            OutputFormats = nodeContent.OutputFormats;
            OnlineResources = nodeContent.OnlineResources;
        }

       
    
        public IReadOnlyCollection<string> OutputFormats { get; internal set; }

        public IReadOnlyCollection<WmsOnlineResource> OnlineResources { get; internal set; }

      
    }
}
