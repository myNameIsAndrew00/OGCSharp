using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp.Wms.Models;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OGCSharp.Geo.WMS
{
    /// <summary>
    /// This class should be used for parsing WMS Capabilities.
    /// Supported version is 1.30
    /// </summary>
    internal class WmsCapabilitiesParser : IOgcCapabilitiesParser
    {
        public OgcServerType Type => OgcServerType.WMS;

        public Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(XmlDocument xmlDocument)
        {
            throw new NotImplementedException();
        }
    }
}
