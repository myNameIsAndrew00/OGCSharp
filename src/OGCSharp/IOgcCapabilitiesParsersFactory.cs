using OGCSharp.Abstractions;
using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp.Geo.WMS;
using OGCSharp.Geo.Wmts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp
{
    internal class OgcCapabilitiesParsersFactory : IOgcCapabilitiesParsersFactory
    {
        public IOgcCapabilitiesParser? Create(OgcServerType serverType) => serverType switch
        {
            OgcServerType.WMS => new WmsCapabilitiesParser(),
            OgcServerType.WMTS => new WmtsCapabilitiesParser(),
            _ => null
        };
    }
}
