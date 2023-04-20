using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp.Geo.Wmts;
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

            // Parse the capabilities document from XElement node. 
            WmsDocument capabilitiesDocument = new WmsDocument(capabilitiesElement);

            List<WmsLayer> layers = new List<WmsLayer>();

            // Create layers based on document and inner layers.
            ParseRecursive(
                layer: capabilitiesDocument.Capability.LayerGroup,
                wmsDocument: capabilitiesDocument,
                wmsLayers: ref layers);

            return layers;
        }

        private void ParseRecursive(WmsServerLayer layer, WmsDocument wmsDocument, ref List<WmsLayer> wmsLayers)
        {
            try
            {
                // Add layer from current level to the result list.
                wmsLayers.Add(new WmsLayer(layer, wmsDocument));

                // Iterate through child layers and extract all inner layers.
                foreach (var innerLayer in layer.ChildLayers)
                {
                    ParseRecursive(innerLayer, wmsDocument, ref wmsLayers);
                }
            }
            catch
            {
            }
        }

    }
}
