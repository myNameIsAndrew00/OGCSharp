using System.Xml.Linq;
using OGCSharp;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsTileMatrix : WmtsElement
    {
        public WmtsTileMatrix(XElement tileMatrixXml) : base(tileMatrixXml)
        {
        }

        public string Identifier => this.xmlNode.ElementUnprefixed(IdentifierElement).Value;

        public string ScaleDenominator => this.xmlNode.ElementUnprefixed(ScaleDenominatorElement).Value;

        public string TopLeftCorner => this.xmlNode.ElementUnprefixed(TopLeftCornerElement).Value;

        public int TileHeight => Convert.ToInt32(this.xmlNode.ElementUnprefixed(TileHeightElement).Value);

        public int TileWidth => Convert.ToInt32(this.xmlNode.ElementUnprefixed(TileWidthElement).Value);

        public int MatrixWidth => Convert.ToInt32(this.xmlNode.ElementUnprefixed(MatrixWidthElement).Value);

        public int MatrixHeight => Convert.ToInt32(this.xmlNode.ElementUnprefixed(MatrixHeightElement).Value);

    }

}
