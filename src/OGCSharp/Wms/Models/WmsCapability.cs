using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    public class WmsCapability : WmsElement
    {

        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            var requestNode = node.GetWmsElement(RequestNode, parsingContext);

            if(requestNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.CAPABILITY_REQUEST_ELEM_M);
                return;
            }


            // Capability element represent the actual operations that are supported by the server.
            // According to 7.2.4.4, layers, request are mandatory to be defined.
            Request.Parse(requestNode, parsingContext);
            ExceptionsFormats = node.GetWmsElement(ExceptionNode, parsingContext)
                                    ?.GetWmsElements(FormatNode, parsingContext)
                                    ?.Select(formatNode => formatNode.Value)
                                    ?.ToList() ?? new List<string>();

            var usedDefinedSymbolization = node.Element(WmsNamespaces.Sld + UserDefinedSymbolizationNode);
            if (usedDefinedSymbolization != null) {
                UserDefinedSymbolization = new WmsUserDefinedSymbolization();

                UserDefinedSymbolization.Parse(usedDefinedSymbolization, parsingContext);
            }

            var layerNode = node.GetWmsElement(LayerNode, parsingContext);
            if (layerNode == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.CAPABILITY_LAYER_ELEM_M);
                return;
            }

            LayerGroup.Parse(layerNode, parsingContext);
        }

        public WmsRequest Request { get; internal set; } = new WmsRequest();

        public IReadOnlyCollection<string> ExceptionsFormats { get; internal set; } = null!;

        public WmsUserDefinedSymbolization? UserDefinedSymbolization { get; internal set; }

        public WmsServerLayer LayerGroup { get; internal set; } = new WmsServerLayer();

    }
}
