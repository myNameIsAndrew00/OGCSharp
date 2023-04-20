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

        public bool Queryable { get; set; } 
    }
}
