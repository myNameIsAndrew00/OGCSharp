namespace OGCSharp.Geo.WMS
{
    public class Dimension<TDataInterval,TDataResolution>
    {
        public string RawData { get; set; }

        public bool  IsInterval { get; set; }
        
        public TDataInterval Start { get; set; }
        
        public TDataInterval End { get; set; }

        public TDataResolution Resolution { get; set; }
    }
}
