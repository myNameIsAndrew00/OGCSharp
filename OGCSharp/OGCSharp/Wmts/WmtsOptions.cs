using OGCSharp.Wmts.Elements;

namespace OGCSharp.Geo.Wmts
{
    public class WmtsOptions
    {
        public string? Layer { get; set; }

        public string? Format { get; set; }

        public string? Style { get; set; }

        public List<string> Urls { get; set; } = new List<string>();

         internal List<WmtsDimension> Dimensions { get; set; } = null!;

        internal WmtsTileGrid TileGrid { get; set; } = null!;

        public bool WrapX { get; set; }

        public string? MatrixSet { get; set; }

        public string? Encoding { get; set; }
    }

}
