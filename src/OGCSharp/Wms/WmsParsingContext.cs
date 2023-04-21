using OGCSharp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms
{
    /// <summary>
    /// Represents an object used during document parsing.
    /// </summary>
    internal class WmsParsingContext
    {
        public WmsVersion Version { get; set; }

        public XNamespace ParsingNamespace => Version switch
        {
            WmsVersion.V1_0_0 => XNamespace.None,
            WmsVersion.V1_1_0 => XNamespace.None,
            WmsVersion.V1_3_0 => WmsConstants.Wms130,
            _ => XNamespace.None
        };
    }
}
