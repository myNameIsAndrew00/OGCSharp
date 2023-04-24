using OGCSharp.Geo.Types;
using OGCSharp.Geo.Wmts;
using OGCSharp.Layers.Abstractions;
using System.Xml;

namespace OGCSharp.Layers.Wmts
{
    internal class WmtsLayersProvider : IOgcProvider
    {
        public OgcServerType Type => OgcServerType.WMTS;

        private WmtsCapabilitiesParser _parser;

        public WmtsLayersProvider()
        {
            _parser = new WmtsCapabilitiesParser();
        }

        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(string url) => GetLayersInternal(await _parser.ParseCapabilitiesAsync(url));


        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(XmlDocument xmlDocument) => GetLayersInternal(await _parser.ParseCapabilitiesAsync(xmlDocument));       


        private IReadOnlyCollection<ILayer>? GetLayersInternal(WmtsDocument? document)
        {
            if(document == null)
            {
                return null;
            }

            // Create layers based on document and inner layers.
            return document.Layers.Select(layerNode => new WmtsLayer(document, layerNode))
                                              .ToList();
        }
    }
}
