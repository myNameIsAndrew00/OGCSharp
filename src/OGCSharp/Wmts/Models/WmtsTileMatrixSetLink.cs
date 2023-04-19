using OGCSharp;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsTileMatrixSetLink : WmsElement
    {
        private IEnumerable<WmtsTileMatrixLimit> limits;

        public WmtsTileMatrixSetLink(XElement tileMatrixSetXml) : base(tileMatrixSetXml)
        {
            limits = this.xmlNode.ElementUnprefixed(TileMatrixSetLimitsElement)
                                 ?.ElementsUnprefixed(TileMatrixLimitsElement)
                                 .Select(element => new WmtsTileMatrixLimit(element));
        }

        public string TileMatrixSet => this.xmlNode.ElementUnprefixed(TileMatrixSetElement)?.Value;

        public IEnumerable<WmtsTileMatrixLimit> TileMatrixLimits => limits;

    }

}
