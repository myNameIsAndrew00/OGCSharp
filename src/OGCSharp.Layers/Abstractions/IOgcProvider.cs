using OGCSharp.Geo.Types;
using System.Xml;

namespace OGCSharp.Layers.Abstractions
{
    public interface IOgcProvider
    {
        /// <summary>
        /// Parse capabilities for the given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(string url);

        /// <summary>
        /// Parse capabilities for the given xml document.
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        public Task<IReadOnlyCollection<ILayer>?> GetLayersAsync(XmlDocument xmlDocument);

        public OgcServerType Type { get; }
    }
}
