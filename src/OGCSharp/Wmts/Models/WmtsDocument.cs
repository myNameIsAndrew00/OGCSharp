using OGCSharp.Wms;
using OGCSharp.Wmts;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{

    /// <summary>
    /// Representsa a facade for an xelement which represents a wmpts map capabilities document
    /// </summary>
    public class WmtsDocument : WmtsElement
    {
        private IEnumerable<WmtsTileMatrixSet> _tileMatrixSets;

        private IEnumerable<WmtsLayerNode> _layers;

        private WmtsOperationMetadata _operationMetadata;

        internal override void Parse(XElement node, WmtsParsingContext parsingContext)
        {
            _tileMatrixSets = node.ElementUnprefixed(ContentsElement)
                            .ElementsUnprefixed(TileMatrixSetElement)
                            .Select(element => {
                                var matrixSet = new WmtsTileMatrixSet();

                                matrixSet.Parse(element, parsingContext);

                                return matrixSet;
                                });

            _layers = node.ElementUnprefixed(ContentsElement)
                            .ElementsUnprefixed(LayerNode)
                            .Select(element => {
                                var layer = new WmtsLayerNode();

                                layer.Parse(element, parsingContext);   

                                return layer;
                                });

            _operationMetadata = new WmtsOperationMetadata();
            _operationMetadata.Parse(node.ElementUnprefixed(OperationsMetadataNode), parsingContext);
        }


        public WmtsOperationMetadata Operation => _operationMetadata;

        public IEnumerable<WmtsLayerNode> Layers => _layers;

        public IEnumerable<WmtsTileMatrixSet> TileMatrixSets => _tileMatrixSets;

    
    }




}
