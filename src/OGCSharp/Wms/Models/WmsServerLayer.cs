using GeoAPI.Geometries;
using OGCSharp.Geo;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for holding information about a WMS Layer 
    /// </summary>
    public class WmsServerLayer : WmsElement
    {
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            var titleNode = node.GetWmsElement(TitleNode, parsingContext);

            if (titleNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.LAYER_TITLE_ELEM_M);
                return;
            }


            Title = titleNode.Value;
            Name = node.GetWmsElement(NameNode, parsingContext)?.Value;
            Abstract = node.GetWmsElement(AbstractNode, parsingContext)?.Value;
            Queryable = node.AttributeAsInt(QueryableAttributeNode) == 1;
            Opaque = node.AttributeAsInt(OpaqueAttributeNode) == 1;
            NoSubsets = node.AttributeAsInt(NoSubsetsAttributeNode) == 1;
            Cascaded = node.AttributeAsInt(CascadedAttributeNode);
            FixedWidth = node.AttributeAsInt(FixedWidthAttributeNode);
            FixedHeight = node.AttributeAsInt(FixedHeightAttributeNode);

            SRIDBoundingBoxes = node.GetWmsElements(BoundingBoxNode, parsingContext).Select(boundingBoxNode =>
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

            Keywords = node.GetWmsElement(KeywordListNode, parsingContext)
                           ?.GetWmsElements(KeywordNode, parsingContext).Select(keywordNode => keywordNode.Value).ToList()
                             ?? new List<string>();

            CRS = node.GetWmsElements(CRSNode, parsingContext).Select(crsNode => crsNode.Value).ToList() ?? new List<string>();

            // Try to set bounding box.
            var boundingBoxNode = node.GetWmsElement(LatLonBoundingBoxNode, parsingContext) ?? node.GetWmsElement(EX_GeographicBoundingBoxNode, parsingContext);
            if (boundingBoxNode != null)
            {
                LatLonBoundingBox = new Envelope(
                    x1: boundingBoxNode.ValueAsDouble(WestBoundLongitudeNode, parsingContext),
                    x2: boundingBoxNode.ValueAsDouble(SouthBoundLatitudeNode, parsingContext),
                    y1: boundingBoxNode.ValueAsDouble(EastBoundLongitudeNode, parsingContext),
                    y2: boundingBoxNode.ValueAsDouble(NorthBoundLatitudeNode, parsingContext));
            }

            ChildLayers = node.GetWmsElements(LayerNode, parsingContext).Select(layerNode =>
            {
                var layer = new WmsServerLayer()!;

                layer.Parse(layerNode, parsingContext);

                return layer;
            }).ToList();

            Dimensions = node.GetWmsElements(DimensionNode, parsingContext).Select(dimensionNode =>
            {
                var dimension = new WmsDimension();

                dimension.Parse(dimensionNode, parsingContext);

                return dimension;
            }).ToList();    
        }

        /// <summary>
        /// Abstract
        /// </summary>
        public string? Abstract { get; internal set; }

        public IReadOnlyCollection<WmsDimension>? Dimensions { get; internal set; }

        /// <summary>
        /// Collection of child layers
        /// </summary>
        public IReadOnlyCollection<WmsServerLayer>? ChildLayers { get; internal set; }

        /// <summary>
        /// Coordinate Reference Systems supported by layer
        /// </summary>
        public IReadOnlyCollection<string> CRS { get; internal set; } = null!;

        /// <summary>
        /// Keywords
        /// </summary>
        public IReadOnlyCollection<string>? Keywords { get; internal set; }

        /// <summary>
        /// Latitudal/longitudal extent of this layer
        /// </summary>
        public Envelope? LatLonBoundingBox { get; internal set; }

        /// <summary>
        /// Extent of this layer in spatial reference system
        /// </summary>
        public IReadOnlyCollection<WmsSpatialReferencedBoundingBox> SRIDBoundingBoxes { get; internal set; } = null!;

        /// <summary>
        /// Unique name of this layer used for requesting layer
        /// </summary>
        public string? Name { get; internal set; }

        /// <summary>
        /// Specifies whether this layer is queryable using GetFeatureInfo requests
        /// </summary>
        public bool Queryable { get; internal set; }

        public int Cascaded { get; internal set; }

        public bool Opaque { get; internal set; }

        public bool NoSubsets { get; internal set; }

        public int FixedWidth { get; internal set; }

        public int FixedHeight { get; internal set; }  

        /// <summary>
        /// List of styles supported by layer
        /// </summary>
        public IReadOnlyCollection<WmsLayerStyle>? Style { get; internal set; }

        /// <summary>
        /// Layer title
        /// </summary>
        public string Title { get; internal set; } = null!;


    }
}
