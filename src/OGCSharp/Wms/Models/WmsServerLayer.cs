using GeoAPI.Geometries;
using OGCSharp.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for holding information about a WMS Layer 
    /// </summary>
    internal class WmsServerLayer : WmsElement
    {
        public WmsServerLayer(XElement xmlNode) : base(xmlNode)
        {
            Name = xmlNode.ElementUnprefixed(NameNode).Value;
            Title = xmlNode.ElementUnprefixed(TitleNode).Value;
            Abstract = xmlNode.ElementUnprefixed(AbstractNode).Value;
            Queryable = xmlNode.AttributeAsBool(QueryableAttributeNode);

            SRIDBoundingBoxes = xmlNode.ElementsUnprefixed(BoundingBoxNode).Select(boundingBoxNode =>
            {
                int? epsg = boundingBoxNode.GetEpsg();

                if (epsg.HasValue)
                {
                    return new WmsSpatialReferencedBoundingBox(
                        minX: boundingBoxNode.AttributeAsInt(MinXAttributeNode),
                        minY: boundingBoxNode.AttributeAsInt(MinYAttributeNode),
                        maxX: boundingBoxNode.AttributeAsInt(MaxXAttributeNode),
                        maxY: boundingBoxNode.AttributeAsInt(MaxYAttributeNode),
                        epsg.Value);
                }
                else return null;
            }).Where(boundingBox => boundingBox != null)
              .Cast<WmsSpatialReferencedBoundingBox>()
              .ToList();

            Keywords = xmlNode.ElementUnprefixed(KeywordListNode)
                              .ElementsUnprefixed(KeywordNode).Select(keywordNode => keywordNode.Value).ToList()
                             ?? new List<string>();

            CRS = xmlNode.ElementsUnprefixed(CRSNode).Select(crsNode => crsNode.Value).ToList() ?? new List<string>();

            // Try to set bounding box.
            var boundingBoxNode = xmlNode.ElementUnprefixed(LatLonBoundingBoxNode) ?? xmlNode.ElementUnprefixed(EX_GeographicBoundingBoxNode);

            if (boundingBoxNode != null)
            {
                LatLonBoundingBox = new Envelope(
                    x1: boundingBoxNode.AttributeAsDouble(WestBoundLongitudeAttributeNode) ?? -180.0,
                    x2: boundingBoxNode.AttributeAsDouble(WestBoundLongitudeAttributeNode) ?? -90.0,
                    y1: boundingBoxNode.AttributeAsDouble(WestBoundLongitudeAttributeNode) ?? 180.0,
                    y2: boundingBoxNode.AttributeAsDouble(WestBoundLongitudeAttributeNode) ?? 90.0);
            }

            ChildLayers = xmlNode.ElementsUnprefixed(LayerNode).Select(layerNode => new WmsServerLayer(layerNode)).ToArray();
        }

        /// <summary>
        /// Abstract
        /// </summary>
        public string Abstract { get; }

        /// <summary>
        /// Collection of child layers
        /// </summary>
        public WmsServerLayer[] ChildLayers { get; }

        /// <summary>
        /// Coordinate Reference Systems supported by layer
        /// </summary>
        public IReadOnlyCollection<string> CRS { get; }

        /// <summary>
        /// Keywords
        /// </summary>
        public IReadOnlyCollection<string> Keywords { get; }

        /// <summary>
        /// Latitudal/longitudal extent of this layer
        /// </summary>
        public Envelope? LatLonBoundingBox { get; }

        /// <summary>
        /// Extent of this layer in spatial reference system
        /// </summary>
        public List<WmsSpatialReferencedBoundingBox> SRIDBoundingBoxes { get; }

        /// <summary>
        /// Unique name of this layer used for requesting layer
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Specifies whether this layer is queryable using GetFeatureInfo requests
        /// </summary>
        public bool Queryable { get; }

        /// <summary>
        /// List of styles supported by layer
        /// </summary>
        public WmsLayerStyle[] Style { get; }

        /// <summary>
        /// Layer title
        /// </summary>
        public string Title { get; }

    }
}
