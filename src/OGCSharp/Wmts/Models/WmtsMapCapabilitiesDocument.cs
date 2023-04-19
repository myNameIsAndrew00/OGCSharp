using OGCSharp;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{

    /// <summary>
    /// Representsa a facade for an xelement which represents a wmpts map capabilities document
    /// </summary>
    internal class WmtsMapCapabilitiesDocument : WmtsElement
    {
        private IEnumerable<WmtsTileMatrixSet> tileMatrixSets;

        private IEnumerable<WmtsLayerNode> layers;

        private WmtsOperationMetadata operationMetadata;

        public WmtsMapCapabilitiesDocument(XElement documentXml) : base(documentXml)
        {
            tileMatrixSets = this.xmlNode.ElementUnprefixed(ContentsElement)
                            .ElementsUnprefixed(TileMatrixSetElement)
                            .Select(element => new WmtsTileMatrixSet(element));

            layers = this.xmlNode.ElementUnprefixed(ContentsElement)
                            .ElementsUnprefixed(LayerNode)
                            .Select(element => new WmtsLayerNode(element));

            operationMetadata = new WmtsOperationMetadata(this.xmlNode.ElementUnprefixed(OperationsMetadataNode));
            
        }

        public WmtsOperationMetadata Operation => operationMetadata;

        public IEnumerable<WmtsLayerNode> Layers => layers;

        public IEnumerable<WmtsTileMatrixSet> TileMatrixSets => tileMatrixSets;

    }




}
