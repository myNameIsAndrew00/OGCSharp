using OGCSharp.Geo.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OGCSharp.Geo.Abstractions
{
    public interface IGeoCapabilitiesParser
    {
        /// <summary>
        /// Parse capabilities for the given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ICollection<ILayer>? ParseCapabilities(string url);

        /// <summary>
        /// Parse capabilities for the given xml document.
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        public ICollection<ILayer>? ParseCapabilities(XmlDocument xmlDocument);

        public OGCServerType Type { get; }
    }
}
