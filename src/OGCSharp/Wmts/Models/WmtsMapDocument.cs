using OGCSharp;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{

    /// <summary>
    /// Representsa a facade for an xelement which represents a wmpts map capabilities document
    /// </summary>
    internal class WmtsMapDocument : WmtsElement
    {
        private IEnumerable<WmtsTileMatrixSet> _tileMatrixSets;

        private IEnumerable<WmtsLayerNode> _layers;

        private WmtsOperationMetadata _operationMetadata;

        public WmtsMapDocument(XElement documentXml) : base(documentXml)
        {
            _tileMatrixSets = this._xmlNode.ElementUnprefixed(ContentsElement)
                            .ElementsUnprefixed(TileMatrixSetElement)
                            .Select(element => new WmtsTileMatrixSet(element));

            _layers = this._xmlNode.ElementUnprefixed(ContentsElement)
                            .ElementsUnprefixed(LayerNode)
                            .Select(element => new WmtsLayerNode(element));

            _operationMetadata = new WmtsOperationMetadata(this._xmlNode.ElementUnprefixed(OperationsMetadataNode));
            
        }

        public WmtsOperationMetadata Operation => _operationMetadata;

        public IEnumerable<WmtsLayerNode> Layers => _layers;

        public IEnumerable<WmtsTileMatrixSet> TileMatrixSets => _tileMatrixSets;

    }




}
