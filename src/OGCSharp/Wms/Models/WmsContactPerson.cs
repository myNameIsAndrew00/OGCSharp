using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Information about a contact person for the service.
    /// </summary>
    internal class WmsContactPerson : WmsElement
    {
        public WmsContactPerson(XElement xmlNode) : base(xmlNode)
        {
            Organisation = xmlNode.ElementUnprefixed(ContactOrganizationNode)?.Value;
            Person = xmlNode.ElementUnprefixed(ContactPersonNode)?.Value;
        }

        /// <summary>
        /// Organisation of primary person
        /// </summary>
        public string Organisation;

        /// <summary>
        /// Primary contact person
        /// </summary>
        public string Person;

     
    }
}
