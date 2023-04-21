using OGCSharp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms
{
    internal class WmsOptions
    {
        public string? ReferencedLayerName { get; set; }

        public string? Abstract { get; set; }  

        public bool ContainsData { get; set; } 

        public bool HasFeatureInfo { get; set; } 

        public WmsVersion WmsVersion { get; set; }

        public IReadOnlyCollection<DimensionData>? Dimensions { get; set; }
    }

    /// <summary>
    /// Encapsulates relevant information from wms dimensions.
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="Raw"></param>
    /// <param name="Start"></param>
    /// <param name="End"></param>
    /// <param name="Resolution"></param>
    /// <param name="IsInterval"></param>
    internal record DimensionData(
        WmsLayerDimensionType Type, 
        string Raw, 
        string? Start, 
        string? End, 
        string? Resolution, 
        string UnitsStandard,
        bool IsInterval);
}
