using OGCSharp.Geo.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Geo.Abstractions
{
    /// <summary>
    /// Provides a common interface for layers consumed by a OGC service.
    /// </summary>
    public interface ILayer
    {
        string? Title { get; set; }

        string? Name { get; set; }

        string? URL { get; set; }

        OgcServerType ServerType { get; }
    }
}
