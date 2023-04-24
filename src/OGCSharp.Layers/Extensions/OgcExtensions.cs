using Microsoft.Extensions.DependencyInjection;
using OGCSharp.Layers;
using OGCSharp.Layers.Abstractions;

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
        public static IServiceCollection AddOgc(this IServiceCollection serviceDescriptors)
        {
            // Add capabilities parsers to services.
            return serviceDescriptors
                .AddSingleton<IOgcProvidersFactory, OgcProvidersFactory>();
        }
 
    }
}
