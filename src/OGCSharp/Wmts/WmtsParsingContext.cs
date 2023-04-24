using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wmts
{
    internal class WmtsParsingContext
    {
        public XNamespace ParsingNamespace { get; set; } = WmtsConstants.Wmts1;
    }
}
