using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp.Wms;
using OGCSharp.Wms.Models;
using System.Xml.Linq;

namespace OGCSharp.Geo.WMS
{
    internal class WmsLayer : ILayer
    {
        public string? Title { get; set; }

        public string? Name { get; set; }
        
        public string? URL { get; set; }
    
        public WmsOptions Options { get; set; } 

        public OgcServerType ServerType => OgcServerType.WMS;
    }
}
