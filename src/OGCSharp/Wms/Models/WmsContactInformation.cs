using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Stores contact metadata about WMS service
    /// </summary>
    internal class WmsContactInformation : WmsElement
    {
        public WmsContactInformation(XElement xmlNode) : base(xmlNode)
        {
            Address = new WmsContactAddress(xmlNode.ElementUnprefixed(ContactAddressNode));
            ElectronicMailAddress = xmlNode.ElementUnprefixed(ContactElectronicMailAddressNode)?.Value;
            FacsimileTelephone = xmlNode.ElementUnprefixed(ContactFacsimileTelephoneNode)?.Value;
            VoiceTelephone = xmlNode.ElementUnprefixed(ContactVoiceTelephoneNode)?.Value;
            PersonPrimary = new WmsContactPerson(xmlNode.ElementUnprefixed(ContactPersonPrimaryNode));
        }

        /// <summary>
        /// Address
        /// </summary>
        public WmsContactAddress Address { get; }

        /// <summary>
        /// Email address
        /// </summary>
        public string ElectronicMailAddress { get; }

        /// <summary>
        /// Fax number
        /// </summary>
        public string FacsimileTelephone { get; }

        /// <summary>
        /// Primary contact person
        /// </summary>
        public WmsContactPerson PersonPrimary { get; }

        /// <summary>
        /// Position of contact person
        /// </summary>
        public string Position { get; }

        /// <summary>
        /// Telephone
        /// </summary>
        public string VoiceTelephone { get; }


    }
}
