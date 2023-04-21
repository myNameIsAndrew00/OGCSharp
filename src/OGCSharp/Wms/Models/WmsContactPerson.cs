﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Information about a contact person for the service.
    /// </summary>
    internal class WmsContactPerson : WmsElement
    {
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            Organisation = node.GetWmsElement(ContactOrganizationNode, parsingContext)?.Value;
            Person = node.GetWmsElement(ContactPersonNode, parsingContext)?.Value;
        }

        /// <summary>
        /// Organisation of primary person
        /// </summary>
        public string? Organisation { get; internal set; }

        /// <summary>
        /// Primary contact person
        /// </summary>
        public string? Person { get; internal set; }

      
    }
}
