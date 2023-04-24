using OGCSharp.Wmts.Elements;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsOptions
    {
        public string? Layer { get; set; }

        public string? Format { get; set; }

        public string? Style { get; set; }

        public List<string> Urls { get; set; } = new List<string>();

        public List<WmtsDimension> Dimensions { get; set; } = null!;

        public WmtsTileGrid TileGrid { get; set; } = null!;

        public bool WrapX { get; set; }

        public string? MatrixSet { get; set; }

        public string? Encoding { get; set; }
    }

}
