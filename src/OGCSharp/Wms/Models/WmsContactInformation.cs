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
    /// Stores contact metadata about WMS service
    /// </summary>
    internal class WmsContactInformation : WmsElement
    {
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            var contactAddressNode = node.GetWmsElement(ContactAddressNode, parsingContext);
            if (contactAddressNode != null)
            {
                Address = new();
                Address.Parse(contactAddressNode, parsingContext);
            }

            var electronicMailAddress = node.GetWmsElement(ContactElectronicMailAddressNode, parsingContext);
            if (electronicMailAddress != null)
            {
                ElectronicMailAddress = electronicMailAddress?.Value;
            }

            var facsimileTelephone = node.GetWmsElement(ContactFacsimileTelephoneNode, parsingContext);
            if (facsimileTelephone != null)
            {
                FacsimileTelephone = facsimileTelephone?.Value;
            }

            var contactVoice = node.GetWmsElement(ContactVoiceTelephoneNode, parsingContext);
            if (contactVoice != null)
            {
                VoiceTelephone = contactVoice?.Value;
            }

            var contactPersonPrimary = node.GetWmsElement(ContactPersonPrimaryNode, parsingContext);
            if (contactPersonPrimary != null)
            {
                PersonPrimary = new();
                PersonPrimary.Parse(contactPersonPrimary, parsingContext);
            }
        }

        /// <summary>
        /// Address
        /// </summary>
        public WmsContactAddress? Address { get; internal set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string? ElectronicMailAddress { get; internal set; }

        /// <summary>
        /// Fax number
        /// </summary>
        public string? FacsimileTelephone { get; internal set; }

        /// <summary>
        /// Primary contact person
        /// </summary>
        public WmsContactPerson? PersonPrimary { get; internal set; }

        /// <summary>
        /// Position of contact person
        /// </summary>
        public string? Position { get; internal set; }

        /// <summary>
        /// Telephone
        /// </summary>
        public string? VoiceTelephone { get; internal set; }

    }
}
