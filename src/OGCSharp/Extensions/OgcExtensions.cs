using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.WMS;
using OGCSharp.Geo.Wmts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Geo.Extensions
{
    /// <summary>
    /// Contains methods extensions provided by geo library.
    /// </summary>
    public static class OgcExtensions
    {
        /// <summary>
        /// Provides geo parsing objects in the service collection. 
        /// </summary>
        /// <param name="serviceDescriptors"></param>
        /// <returns></returns>
        public static IServiceCollection AddGeo(this IServiceCollection serviceDescriptors)
        {
            // Add capabilities parsers to services.
            return serviceDescriptors
                .AddScoped<IGeoCapabilitiesParser, WmtsCapabilitiesParser>()
                .AddScoped<IGeoCapabilitiesParser, WMSCapabilitiesParser>();
        }

        /// <summary>
        /// Try to get the time dimensions for the given layer.
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static List<Dimension<DateTime, TimeSpan>>? GetWmsTimeDimensions(this ILayer layer) 
        {
            if(layer is WMSLayer wmsLayer)
            {
                return wmsLayer.TimeDimensions;
            }

            return null;
        }

        /// <summary>
        /// Try to get elevations for the given layer.
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static List<Dimension<decimal, decimal>>? GetWmsElevations(this ILayer layer)
        {
            if (layer is WMSLayer wmsLayer)
            {
                return wmsLayer.Elevations;
            }

            return null;
        }

        /// <summary>
        /// Try to return options for the given layer (wmts only).
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static WmtsOptions? GetWmtsLayerOptions(this ILayer layer)
        {
            if(layer is WmtsLayer wmtsLayer)
            {
                return wmtsLayer.Options;
            }

            return null;
        }
    }
}
