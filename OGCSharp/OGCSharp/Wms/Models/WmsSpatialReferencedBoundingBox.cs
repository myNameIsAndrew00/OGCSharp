using GeoAPI.Geometries;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Spatial referenced boundingbox
    /// </summary>
    /// <remarks>
    /// The spatial referenced boundingbox is used to communicate boundingboxes of WMS layers together 
    /// with their spatial reference system in which they are specified
    /// </remarks>
    public class WmsSpatialReferencedBoundingBox : Envelope
    {
        /// <summary>
        /// Initializes a new SpatialReferencedBoundingBox which stores a boundingbox together with the SRID
        /// </summary>
        /// <remarks>This class is used to communicate all the boundingboxes of a WMS server between client.cs and wmslayer.cs</remarks>
        /// <param name="minX">The minimum x-ordinate value</param>
        /// <param name="maxX">The maximum x-ordinate value</param>
        /// <param name="minY">The minimum y-ordinate value</param>
        /// <param name="maxY">The maximum y-ordinate value</param>
        /// <param name="srid">Spatial Reference ID</param>
        public WmsSpatialReferencedBoundingBox(double minX, double minY, double maxX, double maxY, int srid)
            : base(minX, maxX, minY, maxY)
        {
            SRID = srid;
        }

        /// <summary>
        /// Initializes a new SpatialReferencedBoundingBox which stores a boundingbox together with the SRID
        /// </summary>
        /// <remarks>This class is used to communicate all the boundingboxes of a WMS server between client.cs and wmslayer.cs</remarks>
        /// <param name="boundingBox">BoundingBox</param>
        /// <param name="srid">Spatial Reference ID</param>
        public WmsSpatialReferencedBoundingBox(Envelope boundingBox, int srid)
            : base(boundingBox.MinX, boundingBox.MaxX, boundingBox.MinY, boundingBox.MaxY)
        {
            SRID = srid;
        }

        /// <summary>
        /// The spatial reference ID (CRS)
        /// </summary>
        public int SRID { get; set; }
    }
}
