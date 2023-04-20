using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Information about a contact person for the service.
    /// </summary>
    public struct WmsContactPerson
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
}
