using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp;
using OGCSharp.Wmts.Elements;
using System.Xml;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsCapabilitiesParser : IGeoCapabilitiesParser
    {

        public OGCServerType Type => OGCServerType.WMTS;

        public WmtsCapabilitiesParser()
        {
        }

        public ICollection<ILayer>? ParseCapabilities(string url)
        {
            string? capabilities = Utils.DownloadCapabilites(url);
        
            if(capabilities is not null)
            {
                return ParseCapabilitiesInternal(XElement.Parse(capabilities));
            }

            return null;
        }

        public ICollection<ILayer>? ParseCapabilities(XmlDocument xmlDocument)
        {
            if (xmlDocument is null)
                return null;

            XDocument document = XDocument.Load(xmlDocument.CreateNavigator().ReadSubtree());

            return ParseCapabilitiesInternal(document.Root);
        }


        #region Private


        private List<ILayer>? ParseCapabilitiesInternal(XElement? capabilitiesElement)
        {
            if (capabilitiesElement is null)
                return null;

            WmtsMapCapabilitiesDocument capabilitiesDocument = new WmtsMapCapabilitiesDocument(capabilitiesElement);

            return capabilitiesDocument.Layers.Select(layerXelement =>
            {
                WmtsLayer layer = CreateLayer(layerXelement, capabilitiesDocument.TileMatrixSets);

                // Get only KVP href. Rest endpoint is not supported for now.
                layer.URL = capabilitiesDocument.Operation.TileHref;
                layer.Options.Encoding = capabilitiesDocument.Operation.TileEncoding;
                layer.Options.Urls.Add(layer.URL);

                return layer as ILayer;
            }).ToList();
        }

        private WmtsLayer CreateLayer( WmtsLayerNode layer, IEnumerable<WmtsTileMatrixSet> tileMatrixSets)
        {
            WmtsLayer result = new WmtsLayer();

            layer.Dimensions.ForEach(dimensionXml =>
            {
                XElement identifier = dimensionXml.ElementUnprefixed(WmsElement.IdentifierElement);
                XElement value = dimensionXml.ElementUnprefixed(WmsElement.DefaultElement) ?? dimensionXml.ElementUnprefixed(WmsElement.ValueElement);

                result.Options.Dimensions.Add(new (identifier.Value, value.Value));
            });

            result.Name = layer.Identifier?.Value;
            result.Title = layer.Title?.Value;

            result.Options.Layer = result.Name;
            result.Options.MatrixSet = layer.TileMatrixSetLink.TileMatrixSet;
            result.Options.Style = layer.Styles.Where(styleXml => styleXml.Attribute("isDefault")?.Value == "true").FirstOrDefault()
                                        ?.ElementUnprefixed(WmsElement.IdentifierElement)?.Value;

            result.Options.TileGrid = BuildTileGrid(layer, tileMatrixSets.Where(tileMatrixSet => tileMatrixSet.Identifier == result.Options.MatrixSet)
                                                                         .FirstOrDefault());

            layer.ResourceUrls.Where(url => url.Attribute("resourceType")?.Value == "tile").ToList()
                .ForEach(url =>
               {
                   result.Options.Urls.Add(url.Attribute("template").Value);
                   result.Options.Format = url.Attribute("format").Value;
               });

            return result;
        }

        private WmtsTileGrid BuildTileGrid( WmtsLayerNode layer, WmtsTileMatrixSet tileMatrixSet)
        {
            return new WmtsTileGrid()
            {
                TileMatrixLimits = layer.TileMatrixSetLink.TileMatrixLimits,
                TileMatrixSet = tileMatrixSet
            };
        }

       



        #endregion
    }
}
