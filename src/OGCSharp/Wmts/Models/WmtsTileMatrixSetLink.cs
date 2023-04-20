using OGCSharp;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsTileMatrixSetLink : WmtsElement
    {
        private IEnumerable<WmtsTileMatrixLimit> limits;

        public WmtsTileMatrixSetLink(XElement tileMatrixSetXml) : base(tileMatrixSetXml)
        {
            limits = this._xmlNode.ElementUnprefixed(TileMatrixSetLimitsElement)
                                 ?.ElementsUnprefixed(TileMatrixLimitsElement)
                                 .Select(element => new WmtsTileMatrixLimit(element));
        }

        public string TileMatrixSet => this._xmlNode.ElementUnprefixed(TileMatrixSetElement)?.Value;

        public IEnumerable<WmtsTileMatrixLimit> TileMatrixLimits => limits;

    }

}
