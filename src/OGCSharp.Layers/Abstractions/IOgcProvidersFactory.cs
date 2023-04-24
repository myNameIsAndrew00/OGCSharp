using OGCSharp.Geo.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Layers.Abstractions
{
    public interface IOgcProvidersFactory
    {
        IOgcProvider? Create(OgcServerType serverType);
    }
}
