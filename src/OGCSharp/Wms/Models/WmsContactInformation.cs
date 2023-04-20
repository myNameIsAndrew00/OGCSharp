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
        public WmsContactAddress Address;

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
        public WmsContactPerson PersonPrimary;

        /// <summary>
        /// Position of contact person
        /// </summary>
        public string Position;

        /// <summary>
        /// Telephone
        /// </summary>
        public string VoiceTelephone;
    }
}
