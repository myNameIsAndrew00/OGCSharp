using OGCSharp.Geo.WMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    internal class WmsCapability : WmsElement
    {
        public WmsCapability(XElement xmlNode) : base(xmlNode)
        {
            Request = new WmsRequest(xmlNode.ElementUnprefixed(RequestNode));
            ExceptionsFormats = xmlNode.ElementUnprefixed(ExceptionNode)?.ElementsUnprefixed(FormatNode)
                                                                        ?.Select(formatNode => formatNode.Value)
                                                                        ?.ToList() ?? new List<string>();
            UserDefinedSymbolization = new WmsUserDefinedSymbolization(xmlNode.ElementUnprefixed(UserDefinedSymbolizationNode));
            LayerGroup = new WmsServerLayer(xmlNode.ElementUnprefixed(LayerNode));
        }

        public WmsRequest Request { get; }

        public IReadOnlyCollection<string> ExceptionsFormats { get; }

        public WmsUserDefinedSymbolization UserDefinedSymbolization { get; }

        public WmsServerLayer LayerGroup { get; }
    }
}
