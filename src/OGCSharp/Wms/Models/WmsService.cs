using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// The Wms Service Description stores metadata parameters for a WMS service
    /// </summary>
    internal class WmsService : WmsElement
    {
        public WmsService(XElement xmlNode) : base(xmlNode)
        {
        }

        /// <summary>
        /// Optional narrative description providing additional information
        /// </summary>
        public string Abstract;

        /// <summary>
        /// <para>The optional element "AccessConstraints" may be omitted if it do not apply to the server. If
        /// the element is present, the reserved word "none" (case-insensitive) shall be used if there are no
        /// access constraints, as follows: "none".</para>
        /// <para>When constraints are imposed, no precise syntax has been defined for the text content of these elements, but
        /// client applications may display the content for user information and action.</para>
        /// </summary>
        public string AccessConstraints;

        /// <summary>
        /// Optional WMS contact information
        /// </summary>
        public WmsContactInformation ContactInformation;

        /// <summary>
        /// The optional element "Fees" may be omitted if it do not apply to the server. If
        /// the element is present, the reserved word "none" (case-insensitive) shall be used if there are no
        /// fees, as follows: "none".
        /// </summary>
        public string Fees;

        /// <summary>
        /// Optional list of keywords or keyword phrases describing the server as a whole to help catalog searching
        /// </summary>
        public string[] Keywords;

        /// <summary>
        /// Maximum number of layers allowed (0=no restrictions)
        /// </summary>
        public uint LayerLimit;

        /// <summary>
        /// Maximum height allowed in pixels (0=no restrictions)
        /// </summary>
        public uint MaxHeight;

        /// <summary>
        /// Maximum width allowed in pixels (0=no restrictions)
        /// </summary>
        public uint MaxWidth;

        /// <summary>
        /// Mandatory Top-level web address of service or service provider.
        /// </summary>
        public string OnlineResource;

        /// <summary>
        /// Mandatory Human-readable title for pick lists
        /// </summary>
        public string Title;

        /// <summary>
        /// Public url to access the service in case service is hosted behind firewall
        /// </summary>
        public string PublicAccessURL;
 
    }
}
