using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Information about a contact address for the service.
    /// </summary>
    internal class WmsContactAddress : WmsElement
    {
    
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            Address = node.GetWmsElement(AddressNode, parsingContext)?.Value;
            AddressType = node.GetWmsElement(AddressTypeNode, parsingContext)?.Value;
            City = node.GetWmsElement(CityNode, parsingContext)?.Value;
            Country = node.GetWmsElement(CountryNode, parsingContext)?.Value;
            PostCode = node.GetWmsElement(PostCodeNode, parsingContext)?.Value;
        }

        /// <summary>
        /// Contact address
        /// </summary>
        public string? Address { get; internal set; }

        /// <summary>
        /// Type of address (usually "postal").
        /// </summary>
        public string? AddressType { get; internal set; }

        /// <summary>
        /// Contact City
        /// </summary>
        public string? City { get; internal set; }

        /// <summary>
        /// Country of contact address
        /// </summary>
        public string? Country { get; internal set; }

        /// <summary>
        /// Zipcode of contact
        /// </summary>
        public string? PostCode { get; internal set; }

        /// <summary>
        /// State or province of contact
        /// </summary>
        public string? StateOrProvince { get; internal set; }

      
    }
}
