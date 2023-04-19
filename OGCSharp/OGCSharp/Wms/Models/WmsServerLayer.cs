using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for holding information about a WMS Layer 
    /// </summary>
    public struct WmsServerLayer
    {
        /// <summary>
        /// Abstract
        /// </summary>
        public string Abstract;

        /// <summary>
        /// Collection of child layers
        /// </summary>
        public WmsServerLayer[] ChildLayers;

        /// <summary>
        /// Coordinate Reference Systems supported by layer
        /// </summary>
        public string[] CRS;

        /// <summary>
        /// Keywords
        /// </summary>
        public string[] Keywords;

        /// <summary>
        /// Latitudal/longitudal extent of this layer
        /// </summary>
        public Envelope LatLonBoundingBox;

        /// <summary>
        /// Extent of this layer in spatial reference system
        /// </summary>
        public List<WmsSpatialReferencedBoundingBox> SRIDBoundingBoxes;

        /// <summary>
        /// Unique name of this layer used for requesting layer
        /// </summary>
        public string Name;

        /// <summary>
        /// Specifies whether this layer is queryable using GetFeatureInfo requests
        /// </summary>
        public bool Queryable;

        /// <summary>
        /// List of styles supported by layer
        /// </summary>
        public WmsLayerStyle[] Style;

        /// <summary>
        /// Layer title
        /// </summary>
        public string Title;
    }
}
