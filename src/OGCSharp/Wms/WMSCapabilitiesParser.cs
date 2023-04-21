using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp.Geo.Wmts;
using OGCSharp.Wms;
using OGCSharp.Wms.Models;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OGCSharp.Geo.WMS
{
    /// <summary>
    /// This class should be used for parsing WMS Capabilities.
    /// </summary>
    internal class WmsCapabilitiesParser : IOgcCapabilitiesParser
    {
        public OgcServerType Type => OgcServerType.WMS;

        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(string url) => ParseCapabilitiesInternal(await Utils.DownloadCapabilitesAsync(url))?.Cast<ILayer>().ToList();


        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(XmlDocument xmlDocument) => ParseCapabilitiesInternal(xmlDocument.ToXElement())?.Cast<ILayer>().ToList();


        private List<WmsLayer>? ParseCapabilitiesInternal(XElement? capabilitiesElement)
        {
            if (capabilitiesElement is null)
            {
                return null;
            }

            // Parse the capabilities document from XElement node using a new context.
            // Context is a mechanism to share data between nodes.
            WmsDocument capabilitiesDocument = new WmsDocument();
            WmsParsingContext parsingContext = new WmsParsingContext();

            capabilitiesDocument.Parse(capabilitiesElement, parsingContext);

            List<WmsLayer> layers = new List<WmsLayer>();

            // Create layers based on document and inner layers.
            ParseRecursive(
                layer: capabilitiesDocument.Capability.LayerGroup,
                wmsDocument: capabilitiesDocument,
                parentLayer: null,
                wmsLayers: ref layers);

            return layers;
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
