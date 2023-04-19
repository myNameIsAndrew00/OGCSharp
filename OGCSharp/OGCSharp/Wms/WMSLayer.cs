using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;

namespace OGCSharp.Geo.WMS
{
    internal class WMSLayer : ILayer
    {
        public string? Title { get; set; }

        public string? Name { get; set; }
        
        public string? URL { get; set; }
        
        public List<Dimension<DateTime, TimeSpan>>? TimeDimensions { get; set; }
        
        public List<Dimension<decimal, decimal>>? Elevations { get; set; }

        public List<WMSLayer>? Children { get; set; }

        public OGCServerType ServerType => OGCServerType.WMS;
    }
}
