using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Information about a contact address for the service.
    /// </summary>
    internal class WmsContactAddress : WmsElement
    {
        public WmsContactAddress(XElement xmlNode) : base(xmlNode)
        {
            Address = xmlNode.ElementUnprefixed(AddressNode)?.Value;
            AddressType = xmlNode.ElementUnprefixed(AddressTypeNode)?.Value;
            City = xmlNode.ElementUnprefixed(CityNode)?.Value;
            Country = xmlNode.ElementUnprefixed(CountryNode)?.Value;
            PostCode = xmlNode.ElementUnprefixed(PostCodeNode)?.Value;
        }

        /// <summary>
        /// Contact address
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Type of address (usually "postal").
        /// </summary>
        public string AddressType { get; }

        /// <summary>
        /// Contact City
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Country of contact address
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Zipcode of contact
        /// </summary>
        public string PostCode { get; }

        /// <summary>
        /// State or province of contact
        /// </summary>
        public string StateOrProvince { get; }

     
    }
}
