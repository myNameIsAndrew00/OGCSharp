using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Information about a contact address for the service.
    /// </summary>
    public struct WmsContactAddress
    {
        /// <summary>
        /// Contact address
        /// </summary>
        public string Address;

        /// <summary>
        /// Type of address (usually "postal").
        /// </summary>
        public string AddressType;

        /// <summary>
        /// Contact City
        /// </summary>
        public string City;

        /// <summary>
        /// Country of contact address
        /// </summary>
        public string Country;

        /// <summary>
        /// Zipcode of contact
        /// </summary>
        public string PostCode;

        /// <summary>
        /// State or province of contact
        /// </summary>
        public string StateOrProvince;
    }
}
