using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp.Wms;
using OGCSharp.Wms.Models;
using System.Xml.Linq;

namespace OGCSharp.Geo.WMS
{
    internal class WmsLayer : ILayer
    {
        internal WmsLayer(WmsServerLayer serverLayer, WmsDocument wmsDocument)
        {
            Title = serverLayer.Title;
            Name = serverLayer.Name;

            // Url will be build using url found under Capability->Request->GetMap and the layer
            string? url = wmsDocument.Capability
                                     .Request
                                     .GetMap
                                     .OnlineResources
                                     .FirstOrDefault(resource => resource.HttpMethod?.ToLower() == "get")
                                     ?.Url;

            if (url != null)
            {
                URL = url.AppendQueryString((Key: "LAYERS", Value: serverLayer.Name));
            }

            Options = new WmsOptions()
            {
                Abstract = serverLayer.Abstract,
                Queryable = serverLayer.Queryable
            };

        }

        public string? Title { get; set; }

        public string? Name { get; set; }

        public string? URL { get; set; }

        public WmsOptions Options { get; set; }

        public OgcServerType ServerType => OgcServerType.WMS;
    }
}
