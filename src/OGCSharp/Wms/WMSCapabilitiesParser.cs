using OGCSharp.Wms;
using OGCSharp.Wms.Models;
using System.Xml;
using System.Xml.Linq;

namespace OGCSharp.Geo.WMS
{
    /// <summary>
    /// This class should be used for parsing WMS Capabilities.
    /// </summary>
    public class WmsCapabilitiesParser
    {

        public bool TryParse(string xml, out WmsDocument? wmsDocument) => TryParse(XElement.Parse(xml), out wmsDocument);


        public bool TryParse(XmlDocument xmlDocument, out WmsDocument? wmsDocument) => TryParse(xmlDocument.ToXElement(), out wmsDocument);


        private bool TryParse(XElement? capabilityElement, out WmsDocument? wmsDocument)
        { 
            var capabilitiesData = ParseCapabilitiesInternal(capabilityElement);

            // Check if document was created by internal method.
            // If not, that means an error ocurred during xml iteration. 
            if (capabilitiesData.Document == null)
            {
                wmsDocument = null;

                return false;
            }

            wmsDocument = capabilitiesData.Document;

            return capabilitiesData.ParsingContext != null && !capabilitiesData.ParsingContext.ParsingErrors.Any();
        }


        private (WmsDocument? Document, WmsParsingContext? ParsingContext) ParseCapabilitiesInternal(XElement? capabilitiesElement)
        {
            if (capabilitiesElement is null)
            {
                return (null, null);
            }

            WmsParsingContext parsingContext = new WmsParsingContext();
            WmsDocument capabilitiesDocument = new WmsDocument();

            // Parse the capabilities document from XElement node using a new context.
            // Context is a mechanism to share data between nodes.
            try
            {
                capabilitiesDocument.Parse(capabilitiesElement, parsingContext);


                return (capabilitiesDocument, parsingContext);
            }
            catch
            {
                return (null, parsingContext);
            }
        }



    }
}
