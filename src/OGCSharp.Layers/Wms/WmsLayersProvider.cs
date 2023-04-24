using OGCSharp.Geo.Types;
using OGCSharp.Geo.WMS;
using OGCSharp.Layers.Abstractions;
using OGCSharp.Wms.Models;
using System.Xml;

namespace OGCSharp.Layers.Wms
{
    internal class WmsLayersProvider : IOgcProvider
    {
        private WmsCapabilitiesParser _parser;

        public WmsLayersProvider()
        {
            _parser = new WmsCapabilitiesParser();
        }

        public OgcServerType Type => OgcServerType.WMS;

        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(string url) => GetLayersInternal(await _parser.ParseCapabilitiesAsync(url));

        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(XmlDocument xmlDocument) => GetLayersInternal(await _parser.ParseCapabilitiesAsync(xmlDocument));    


        private IReadOnlyCollection<ILayer>? GetLayersInternal(WmsDocument? document)
        {
            if(document == null)
            {
                return null;
            }

            try
            {
                List<WmsLayer> layers = new List<WmsLayer>();

                // Create layers based on document and inner layers.
                ParseRecursive(
                    layer: document.Capability.LayerGroup,
                    wmsDocument: document,
                    parentLayer: null,
                    wmsLayers: ref layers);

                return layers.Cast<ILayer>().ToList();
            }
            catch
            {
            }

            return null;
        }

        private void ParseRecursive(WmsServerLayer layer, WmsDocument wmsDocument, WmsLayer? parentLayer, ref List<WmsLayer> wmsLayers)
        {
            try
            {
                // Add layer from current level to the result list.
                var wmsLayer = new WmsLayer(layer, wmsDocument, parentLayer);
                wmsLayers.Add(wmsLayer);

                if (layer.ChildLayers != null)
                {
                    // Iterate through child layers and extract all inner layers.
                    foreach (var innerLayer in layer.ChildLayers)
                    {
                        ParseRecursive(innerLayer, wmsDocument, wmsLayer, ref wmsLayers);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
