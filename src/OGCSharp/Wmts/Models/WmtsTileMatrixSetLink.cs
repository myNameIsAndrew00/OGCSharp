using OGCSharp;
using OGCSharp.Wmts;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsTileMatrixSetLink : WmtsElement
    {
        private IEnumerable<WmtsTileMatrixLimit> limits;


        internal override void Parse(XElement node, WmtsParsingContext parsingContext)
        {
            limits = node.ElementUnprefixed(TileMatrixSetLimitsElement)
                                 ?.ElementsUnprefixed(TileMatrixLimitsElement)
                                 .Select(element =>
                                 {
                                     var tileMatrixLimit = new WmtsTileMatrixLimit();

                                     tileMatrixLimit.Parse(element, parsingContext);

                                     return tileMatrixLimit;
                                 });

            TileMatrixSet = node.ElementUnprefixed(TileMatrixSetElement)?.Value;
        }


        public string TileMatrixSet { get; internal set; }

        public IEnumerable<WmtsTileMatrixLimit> TileMatrixLimits => limits;


    }

}
