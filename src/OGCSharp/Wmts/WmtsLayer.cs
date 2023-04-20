using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp.Wmts.Elements;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    /// <summary>
    /// Represents a domain model for maps retrieved from WMTS
    /// </summary>
    internal class WmtsLayer : ILayer
    {
        /// <summary>
        /// Use this constructor to create a wmts layer based on wmts map capabilities and wmts layer node.
        /// </summary>
        /// <param name="documentNode"></param>
        /// <param name="layerNode"></param>
        internal WmtsLayer(WmtsDocument documentNode, WmtsLayerNode layerNode)
        {
            Init(documentNode, layerNode);
        }

        public WmtsOptions Options { get; set; } = new WmtsOptions();
        
        public string? Title { get; set; }
        
        public string? Name { get; set; }
   
        public string? URL { get; set; }

        public OgcServerType ServerType => OgcServerType.WMTS;


        private void Init(WmtsDocument documentNode, WmtsLayerNode layerNode)
        {
            layerNode.Dimensions.ForEach(dimensionXml =>
            {
                XElement identifier = dimensionXml.ElementUnprefixed(WmtsElement.IdentifierElement);
                XElement value = dimensionXml.ElementUnprefixed(WmtsElement.DefaultElement) ?? dimensionXml.ElementUnprefixed(WmtsElement.ValueElement);

                this.Options.Dimensions.Add(new(identifier.Value, value.Value));
            });

            this.Name = layerNode.Identifier;
            this.Title = layerNode.Title;

            this.Options.Layer = this.Name;
            this.Options.MatrixSet = layerNode.TileMatrixSetLink.TileMatrixSet;
            this.Options.Style = layerNode.Styles.Where(styleXml => styleXml.Attribute("isDefault")?.Value == "true").FirstOrDefault()
                                        ?.ElementUnprefixed(WmtsElement.IdentifierElement)?.Value;

            this.Options.TileGrid =
                 new WmtsTileGrid()
                 {
                     TileMatrixLimits = layerNode.TileMatrixSetLink.TileMatrixLimits,
                     TileMatrixSet = documentNode.TileMatrixSets.Where(tileMatrixSet => tileMatrixSet.Identifier == this.Options.MatrixSet)
                                                                         .FirstOrDefault()
                 };

            layerNode.ResourceUrls.Where(url => url.Attribute("resourceType")?.Value == "tile").ToList()
                .ForEach(url =>
                {
                    this.Options.Urls.Add(url.Attribute("template").Value);
                    this.Options.Format = url.Attribute("format").Value;
                });

            // Get only KVP href. Rest endpoint is not supported for now.
            this.URL = documentNode.Operation.TileHref;
            this.Options.Encoding = documentNode.Operation.TileEncoding;
            this.Options.Urls.Add(URL);
        }
    }
}
