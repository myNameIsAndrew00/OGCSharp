using OGCSharp.Geo.Types;
using OGCSharp.Layers.Abstractions;
using OGCSharp.Layers.Wms;
using OGCSharp.Layers.Wmts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Layers
{
    internal class OgcProvidersFactory : IOgcProvidersFactory
    {
        public IOgcProvider? Create(OgcServerType serverType) => serverType switch
        {
            OgcServerType.WMS => new WmsLayersProvider(),
            OgcServerType.WMTS => new WmtsLayersProvider(),
            _ => null
        };
        
    }
}
