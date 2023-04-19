using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Stores contact metadata about WMS service
    /// </summary>
    public struct WmsContactInformation
    {
        /// <summary>
        /// Address
        /// </summary>
        public ContactAddress Address;

        /// <summary>
        /// Email address
        /// </summary>
        public string ElectronicMailAddress;

        /// <summary>
        /// Fax number
        /// </summary>
        public string FacsimileTelephone;

        /// <summary>
        /// Primary contact person
        /// </summary>
        public ContactPerson PersonPrimary;

        /// <summary>
        /// Position of contact person
        /// </summary>
        public string Position;

        /// <summary>
        /// Telephone
        /// </summary>
        public string VoiceTelephone;

        #region Nested type: ContactAddress

        /// <summary>
        /// Information about a contact address for the service.
        /// </summary>
        public struct ContactAddress
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

        #endregion

        #region Nested type: ContactPerson

        /// <summary>
        /// Information about a contact person for the service.
        /// </summary>
        public struct ContactPerson
        {
            /// <summary>
            /// Organisation of primary person
            /// </summary>
            public string Organisation;

            /// <summary>
            /// Primary contact person
            /// </summary>
            public string Person;
        }

        #endregion
    }
}
