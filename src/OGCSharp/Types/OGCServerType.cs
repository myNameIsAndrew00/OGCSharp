using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Geo.Types
{
    /// <summary>
    /// Contains all available types of servers capabilities which are exposed by geo library.
    /// </summary>
    public enum OgcServerType
    {
        WMS = 0,
        WMTS = 1,
        WCS = 2,
        WFS = 3
    }
}
