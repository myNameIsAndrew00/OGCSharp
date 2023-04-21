using GeoAPI.Geometries;
using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.Types;
using OGCSharp.Types;
using OGCSharp.Wms;
using OGCSharp.Wms.Models;

namespace OGCSharp.Geo.WMS
{
    internal class WmsLayer : ILayer
    {
        internal WmsLayer(WmsServerLayer serverLayer, WmsDocument wmsDocument, WmsLayer? parentServerLayer)
        {
            Initialise(serverLayer, wmsDocument, parentServerLayer);
        }

        public string? Title { get; set; }

        public string? Name { get; set; }

        public string? URL { get; set; }

        public WmsOptions Options { get; set; } = null!;

        public OgcServerType ServerType => OgcServerType.WMS;

        #region Private 

        private void Initialise(WmsServerLayer serverLayer, WmsDocument wmsDocument, WmsLayer? parentServerLayer)
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

            // Server layer may be null for 'container' layers.
            if (url != null && !string.IsNullOrEmpty(serverLayer.Name))
            {
                URL = url.AppendQueryString(query: (Key: "LAYERS", Value: serverLayer.Name));
            }

            Options = new WmsOptions()
            {
                Abstract = serverLayer.Abstract,
                // According to section 7.2.4.6.3, a layer is queryable for layer if and only if Name is present in the server description.
                // If layer name is not present, then layer is just a group which doesn't holds any data (only inner layers).
                ContainsData = serverLayer.Name != null,
                HasFeatureInfo = serverLayer.Queryable,
                ReferencedLayerName = parentServerLayer?.Name,
                WmsVersion = wmsDocument.Version,
                Dimensions = serverLayer.Dimensions != null ? ParseDimension(serverLayer.Dimensions) : null
            };
        }

        private List<DimensionData> ParseDimension(IReadOnlyCollection<WmsDimension> wmsDimensions)
        {
            var result = new List<DimensionData>();
            // Iterate thorugh wms dimensions and try to parse into a dimension data object,
            // Dimensions can be classified in 'interval' and 'unit' dimensions or sets of .
            foreach (var wmsDimension in wmsDimensions)
            {
                // For the moment only time and elevation types are supported.
                var dimensionType = wmsDimension.Name == "time" ? WmsLayerDimensionType.Time : WmsLayerDimensionType.Elevation;

                try
                {
                    var innerItems = wmsDimension.Extent?.Replace(" ", string.Empty)
                                                         .Replace("\t", string.Empty)
                                                         .Replace("\n", string.Empty).Split(',');

                    if (innerItems is null)
                    {
                        continue;
                    }

                    foreach (var innerItem in innerItems)
                    {
                        var tokens = innerItem.Split('/');
                        if (tokens.Length == 3)
                        {
                            result.Add(new DimensionData(
                                Type: dimensionType,
                                Raw: innerItem,
                                Start: tokens[0],
                                End: tokens[1],
                                Resolution: tokens[2],
                                UnitsStandard: wmsDimension.Units,
                                IsInterval: true));
                        }
                        else
                        {
                            result.Add(new DimensionData(
                                Type: dimensionType,
                                Raw: innerItem,
                                Start: null,
                                End: null,
                                Resolution: null,
                                UnitsStandard: wmsDimension.Units,
                                IsInterval: false));
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }

            return result;
        }
        #endregion

    }
}
