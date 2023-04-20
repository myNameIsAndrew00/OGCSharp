using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Abstractions
{
    public interface IOgcCapabilitiesParsersFactory
    {
        public IOgcCapabilitiesParser? Create(OgcServerType serverType);
    }
}
