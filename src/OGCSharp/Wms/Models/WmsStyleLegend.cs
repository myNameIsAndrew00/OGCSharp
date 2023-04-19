using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for storing WMS Legend information
    /// </summary>
    public struct WmsStyleLegend
    {
        /// <summary>
        /// Online resource for legend style 
        /// </summary>
        public WmsOnlineResource OnlineResource;

        /// <summary>
        /// Size of legend
        /// </summary>
        public Size Size;
    }
}
