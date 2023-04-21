using OGCSharp.Geo.WMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    internal class WmsCapability : WmsElement
    {

        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            // Capability element represent the actual operations that are supported by the server.
            // According to 7.2.4.4, layers, request are mandatory to be defined.
            Request.Parse(node.GetWmsElement(RequestNode, parsingContext)!, parsingContext);
            ExceptionsFormats = node.GetWmsElement(ExceptionNode, parsingContext)
                                    ?.GetWmsElements(FormatNode, parsingContext)
                                    ?.Select(formatNode => formatNode.Value)
                                    ?.ToList() ?? new List<string>();

            var usedDefinedSymbolization = node.Element(WmsConstants.Sld + UserDefinedSymbolizationNode);
            if (usedDefinedSymbolization != null) {
                UserDefinedSymbolization = new WmsUserDefinedSymbolization();

                UserDefinedSymbolization.Parse(usedDefinedSymbolization, parsingContext);
            }

            LayerGroup.Parse(node.GetWmsElement(LayerNode, parsingContext)!, parsingContext);
        }

        public WmsRequest Request { get; internal set; } = new WmsRequest();

        public IReadOnlyCollection<string> ExceptionsFormats { get; internal set; } = null!;

        public WmsUserDefinedSymbolization? UserDefinedSymbolization { get; internal set; }

        public WmsServerLayer LayerGroup { get; internal set; } = new WmsServerLayer();

    }
}
