using OGCSharp.Wms;
using OGCSharp.Wmts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal abstract class WmtsElement
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

        /// <summary>
        /// Try to parse a given node into current object.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parsingContext"></param>
        internal abstract void Parse(XElement node, WmtsParsingContext parsingContext);
    }

}
