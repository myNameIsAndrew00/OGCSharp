using OGCSharp.Geo;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Represents a descriptor for wms online resources, found unde Capability/Request node.
    /// </summary>
    public class WmsOnlineResourceDescriptor : WmsElement
    {
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            var nodeContent = node.ParseRequestTypeBlock(parsingContext);

            OutputFormats = nodeContent.OutputFormats;
            OnlineResources = nodeContent.OnlineResources;
        }

       
    
        public IReadOnlyCollection<string>? OutputFormats { get; internal set; }

        public IReadOnlyCollection<WmsOnlineResource>? OnlineResources { get; internal set; }

      
    }
}
