using System.Xml;
using System.Xml.Linq;
using OGCSharp.Wms;
using OGCSharp.Wms.Models;
using OGCSharp.Wmts;

namespace OGCSharp.Geo.Wmts
{
    public class WmtsCapabilitiesParser
    {
           
        public bool TryParse(string xml, out WmtsDocument? document) => TryParseInternal(XElement.Parse(xml), out document);


        public bool TryParse(XmlDocument xmlDocument, out WmtsDocument? document) => TryParseInternal(xmlDocument.ToXElement(), out document);


        private bool TryParseInternal(XElement? capabilityElement, out WmtsDocument? document)
        {
            document = null;

            try
            {
                document = ParseCapabilitiesInternal(capabilityElement);

                return document != null;
            }
            catch
            {
                return false;
            }
        }

        #region Private


        private WmtsDocument? ParseCapabilitiesInternal(XElement? capabilitiesElement)
        {
            if (capabilitiesElement is null)
            {
                return null;
            }

            // Parse the capabilities document from XElement node. 
            WmtsDocument capabilitiesDocument = new WmtsDocument();
            WmtsParsingContext parsingContext = new WmtsParsingContext();

            capabilitiesDocument.Parse(capabilitiesElement, parsingContext);

            return capabilitiesDocument;
        }


        #endregion
    }
}
