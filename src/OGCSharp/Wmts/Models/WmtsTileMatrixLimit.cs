using OGCSharp.Wms;
using OGCSharp.Wmts;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    public class WmtsTileMatrixLimit : WmtsElement
    {
        internal override void Parse(XElement node, WmtsParsingContext parsingContext)
        {
            TileMatrix = node.ElementUnprefixed(TileMatrixElement)?.Value;
            MinTileRow = Convert.ToInt32(node.ElementUnprefixed(MinTileRowElement)?.Value ?? "0");
            MaxTileRow = Convert.ToInt32(node.ElementUnprefixed(MaxTileRowElement)?.Value ?? "0");
            MinTileCol = Convert.ToInt32(node.ElementUnprefixed(MinTileColElement)?.Value ?? "0");
            MaxTileCol = Convert.ToInt32(node.ElementUnprefixed(MaxTileColElement)?.Value ?? "0");
        }

        public string TileMatrix { get; internal set; }

        public int MinTileRow { get; internal set; }
        public int MaxTileRow { get; internal set; }
        public int MinTileCol { get; internal set; }
        public int MaxTileCol { get; internal set; }


    }      
}          