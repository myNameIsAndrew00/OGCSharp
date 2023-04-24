using System.Xml.Linq;
using OGCSharp.Wms;
using OGCSharp.Wmts;

namespace OGCSharp.Geo.Wmts
{
    public class WmtsTileMatrix : WmtsElement
    {
        internal override void Parse(XElement node, WmtsParsingContext parsingContext)
        {
            Identifier = node.ElementUnprefixed(IdentifierElement).Value;
            ScaleDenominator = node.ElementUnprefixed(ScaleDenominatorElement).Value;
            TopLeftCorner = node.ElementUnprefixed(TopLeftCornerElement).Value;
            TileHeight = Convert.ToInt32(node.ElementUnprefixed(TileHeightElement).Value);
            TileWidth = Convert.ToInt32(node.ElementUnprefixed(TileWidthElement).Value);
            MatrixWidth = Convert.ToInt32(node.ElementUnprefixed(MatrixWidthElement).Value);
            MatrixHeight = Convert.ToInt32(node.ElementUnprefixed(MatrixHeightElement).Value);
        }

        public string Identifier { get; internal set; }

        public string ScaleDenominator { get; internal set; }  

        public string TopLeftCorner { get; internal set; } 

        public int TileHeight { get; internal set; }

        public int TileWidth { get; internal set; }

        public int MatrixWidth { get; internal set; }

        public int MatrixHeight { get; internal set; }


    }

}
