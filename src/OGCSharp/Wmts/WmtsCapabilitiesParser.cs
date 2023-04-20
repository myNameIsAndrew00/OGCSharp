using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp;
using OGCSharp.Wmts.Elements;
using System.Xml;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsCapabilitiesParser : IOgcCapabilitiesParser
    {

        public OgcServerType Type => OgcServerType.WMTS;

        public WmtsCapabilitiesParser()
        {
        }

        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(string url) => ParseCapabilitiesInternal(await Utils.DownloadCapabilitesAsync(url))?.Cast<ILayer>().ToList();
        

        public async Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(XmlDocument xmlDocument)
        {
            if (xmlDocument is null)
            {
                return null;
            }

            XDocument document = XDocument.Load(xmlDocument.CreateNavigator().ReadSubtree());

            return ParseCapabilitiesInternal(document.Root)?.Cast<ILayer>().ToList();
        }


        #region Private


        private List<WmtsLayer>? ParseCapabilitiesInternal(XElement? capabilitiesElement)
        {
            if (capabilitiesElement is null)
            {
                return null;
            }

            // Parse the capabilities document from XElement node. 
            WmtsMapDocument capabilitiesDocument = new WmtsMapDocument(capabilitiesElement);

            // Create layers based on document and inner layers.
            return capabilitiesDocument.Layers.Select(layerNode => new WmtsLayer(capabilitiesDocument, layerNode))
                                              .ToList();
        }
 

        #endregion
    }
}
