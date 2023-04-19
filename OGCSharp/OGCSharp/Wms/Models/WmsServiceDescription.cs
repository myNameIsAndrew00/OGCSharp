using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// The Wms Service Description stores metadata parameters for a WMS service
    /// </summary>
    public struct WmsServiceDescription
    {
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


        /// <summary>
        /// Initializes a WmsServiceDescription object
        /// </summary>
        /// <param name="title">Mandatory Human-readable title for pick lists</param>
        /// <param name="onlineResource">Top-level web address of service or service provider.</param>
        public WmsServiceDescription(string title, string onlineResource)
            : this(title, onlineResource, null)
        {
        }

        /// <summary>
        /// Initializes a WmsServiceDescription object
        /// </summary>
        /// <param name="title">Mandatory Human-readable title for pick lists</param>
        /// <param name="onlineResource">Top-level web address of service or service provider.</param>
        /// <param name="publicWMSAccessUrl">Public URL to use when accessing the service in case it is hosted behind a firewall</param>
        public WmsServiceDescription(string title, string onlineResource, string publicWMSAccessUrl)
        {
            Title = title;
            OnlineResource = onlineResource;
            Keywords = new string[0];
            Abstract = "";
            ContactInformation = new WmsContactInformation();
            Fees = "";
            AccessConstraints = "";
            LayerLimit = 0;
            MaxWidth = 0;
            MaxHeight = 0;
            PublicAccessURL = publicWMSAccessUrl;
        }
    }
}
