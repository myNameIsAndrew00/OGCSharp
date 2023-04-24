using OGCSharp.Wms;
using OGCSharp.Wmts;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    public class WmtsTileMatrixSet : WmtsElement
    {
        private IEnumerable<WmtsTileMatrix> tileMatrixes;
        private string identifier;
        private string supportedCrs;

        internal override void Parse(XElement node, WmtsParsingContext parsingContext)
        {
            this.tileMatrixes = node.ElementsUnprefixed(TileMatrixElement).Select(element =>
            {
                var tileMatrix = new WmtsTileMatrix();

                tileMatrix.Parse(element, parsingContext);

                return tileMatrix;
            });
            this.identifier = node.ElementUnprefixed(IdentifierElement)?.Value;
            this.supportedCrs = node.ElementUnprefixed(SupportedCRSElement)?.Value;
        }

        public string Identifier => identifier;

        public string SupportedCRS => supportedCrs;

        public IEnumerable<WmtsTileMatrix> TileMatrix => tileMatrixes;

    }

}
