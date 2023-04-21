using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms
{
    /// <summary>
    /// Contains useful constants for parsing wms capabilities and service description.
    /// </summary>
    internal class WmsConstants
    {
        public static XNamespace Wms130 = "http://www.opengis.net/wms";
        public static XNamespace Sld = "http://www.opengis.net/sld";
        public static XNamespace XLink = "http://www.w3.org/1999/xlink";
        public static XNamespace MapServer = "http://mapserver.gis.umn.edu/mapserver";
    }
}
