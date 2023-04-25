using OGCSharp.Geo.Types;
using OGCSharp.Geo.WMS;
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

        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(string url)
        {
            var content = await Utils.DownloadCapabilitesAsync(url);

            return GetLayersInternal(content);
        }

        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(XmlDocument xmlDocument) => GetLayersInternal(xmlDocument);

        #region Private

        private IReadOnlyCollection<ILayer>? GetLayersInternal(XmlDocument? xmlDocument)
        {
            if (xmlDocument != null)
            {
                if (_parser.TryParse(xmlDocument, out var document))
                {
                    if (document == null)
                    {
                        return null;
                    }

                    try
                    {
                        // Create layers based on document and inner layers.
                        return document.Layers.Select(layerNode => new WmtsLayer(document, layerNode))
                                                          .Cast<ILayer>()
                                                          .ToList();
                    }
                    catch
                    {
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
