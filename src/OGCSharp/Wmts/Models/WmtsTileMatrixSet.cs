using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsTileMatrixSet : WmtsElement
    {

        private IEnumerable<WmtsTileMatrix> tileMatrixes;
        private string identifier;
        private string supportedCrs;

        public WmtsTileMatrixSet(XElement tileMatrixXml) : base(tileMatrixXml)
        {
            this.tileMatrixes = this._xmlNode.ElementsUnprefixed(TileMatrixElement).Select(element => new WmtsTileMatrix(element));
            this.identifier = this._xmlNode.ElementUnprefixed(IdentifierElement)?.Value;
            this.supportedCrs = this._xmlNode.ElementUnprefixed(SupportedCRSElement)?.Value;
        }

        public string Identifier => identifier;

        public string SupportedCRS => supportedCrs;

        public IEnumerable<WmtsTileMatrix> TileMatrix => tileMatrixes;

    }

}
