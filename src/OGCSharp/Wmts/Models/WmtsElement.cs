using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsElement
    {
        public const string OperationsMetadataNode = "OperationsMetadata";
        public const string OperationNode = "Operation";
        public const string DcpNode = "DCP";
        public const string HttpNode = "HTTP";
        public const string GetNode = "Get";
        public const string LayerNode = "Layer";
        public const string DimensionNode = "Dimension";
        public const string IdentifierElement = "Identifier";
        public const string DefaultElement = "Default";
        public const string ValueElement = "Value";
        public const string ContentsElement = "Contents";
        public const string TitleElement = "Title";
        public const string TileMatrixSetLinkElement = "TileMatrixSetLink";
        public const string TileMatrixSetElement = "TileMatrixSet";
        public const string StyleElement = "Style";
        public const string ResourceURLElement = "ResourceURL";
        public const string ScaleDenominatorElement = "ScaleDenominator";
        public const string TopLeftCornerElement = "TopLeftCorner";
        public const string TileWidthElement = "TileWidth";
        public const string TileHeightElement = "TileHeight";
        public const string MatrixWidthElement = "MatrixWidth";
        public const string MatrixHeightElement = "MatrixHeight";
        public const string TileMatrixSetLimitsElement = "TileMatrixSetLimits";
        public const string TileMatrixLimitsElement = "TileMatrixLimits";
        public const string TileMatrixElement = "TileMatrix";
        public const string MinTileRowElement = "MinTileRow";
        public const string MaxTileRowElement = "MaxTileRow";
        public const string MinTileColElement = "MinTileCol";
        public const string MaxTileColElement = "MaxTileCol";
        public const string SupportedCRSElement = "SupportedCRS";
        public const string ConstraintElement = "Constraint";
        public const string AllowedValuesElement = "AllowedValues"; 

        public static readonly XNamespace OwsNamespace = "http://www.opengis.net/ows/1.1";
        public static readonly XNamespace XLinkNamespace = "http://www.w3.org/1999/xlink";



        protected XElement xmlNode;
        public WmtsElement(XElement xmlNode)
        {
            this.xmlNode = xmlNode;
        }
    }

}
