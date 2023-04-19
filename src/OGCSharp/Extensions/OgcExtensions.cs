using OGCSharp.Geo.Abstractions;
using OGCSharp.Geo.WMS;
using OGCSharp.Geo.Wmts;
using Microsoft.Extensions.DependencyInjection;

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
                .AddScoped<IOgcCapabilitiesParser, WmtsCapabilitiesParser>()
                .AddScoped<IOgcCapabilitiesParser, WmsCapabilitiesParser>();
        }
 
    }
}
