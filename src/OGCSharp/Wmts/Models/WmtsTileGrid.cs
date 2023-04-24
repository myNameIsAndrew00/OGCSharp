using OGCSharp.Geo.Wmts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wmts.Elements
{
    public class WmtsTileGrid
    {
        public IEnumerable<WmtsTileMatrixLimit> TileMatrixLimits { get; set; } = null!;

        public WmtsTileMatrixSet TileMatrixSet { get; set; } = null!;
    }
}
