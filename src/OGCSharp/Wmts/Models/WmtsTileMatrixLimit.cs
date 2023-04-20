using OGCSharp;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsTileMatrixLimit : WmtsElement
    {
        public WmtsTileMatrixLimit(XElement xmlNode) : base(xmlNode)
        {            
        }

        public string TileMatrix => this._xmlNode.ElementUnprefixed(TileMatrixElement)?.Value;

        public int MinTileRow => Convert.ToInt32(this._xmlNode.ElementUnprefixed(MinTileRowElement)?.Value ?? "0");
        public int MaxTileRow => Convert.ToInt32(this._xmlNode.ElementUnprefixed(MaxTileRowElement)?.Value ?? "0");
        public int MinTileCol => Convert.ToInt32(this._xmlNode.ElementUnprefixed(MinTileColElement)?.Value ?? "0");
        public int MaxTileCol => Convert.ToInt32(this._xmlNode.ElementUnprefixed(MaxTileColElement)?.Value ?? "0");

    }
}