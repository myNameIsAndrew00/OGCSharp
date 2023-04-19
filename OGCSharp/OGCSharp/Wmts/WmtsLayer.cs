using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
 

namespace OGCSharp.Geo.Wmts
{
    /// <summary>
    /// Represents a domain model for maps retrieved from WMTS
    /// </summary>
    internal class WmtsLayer : ILayer
    {
        public WmtsOptions Options { get; set; } = new WmtsOptions();
        
        public string? Title { get; set; }
        
        public string? Name { get; set; }
   
        public string? URL { get; set; }

        public OGCServerType ServerType => OGCServerType.WMTS;
    }
}
