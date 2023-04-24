using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms
{
    /// <remarks>
    /// Naming conventions for mandatory names: <NODE_NAME>_<MISSING_ELEMENT_NAME>_<<MISSING_ELEMENT_TYPE>>_M
    /// </remarks>
    internal static class WmsParsingMessages
    {
        public const string CAPABILITY_REQUEST_ELEM_M = "Element 'Request' is mandatory for capability node.";
        public const string CAPABILITY_LAYER_ELEM_M = "Element 'Layer' is mandatory for capability node.";
        public const string DIMENSION_UNITS_ATTR_M = "Attribute 'units' is mandatory for dimension node.";
        public const string DIMENSION_NAME_ATTR_M = "Attribute 'name' is mandatory for dimension node.";
        public const string DOCUMENT_CAPABILITY_ELEM_M = "Element 'Capability' is mandatory for document node.";
        public const string DOCUMENT_SERVICE_ELEM_M = "Element 'Service' is mandatory for document node.";
        public const string LAYER_TITLE_ELEM_M = "Element 'Title' is mandatory for layer node.";
        public const string LAYERSTYLE_NAME_ELEM_M = "Element 'Name' is mandatory for layer style node.";
        public const string LAYERSTYLE_TITLE_ELEM_M = "Element 'Title' is mandatory for layer style node.";
        public const string REQUEST_GETMAP_ELEM_M = "Element 'GetMap' is mandatory for request node.";
        public const string REQUEST_GETCAPABILITIES_ELEM_M = "Element 'GetCapabilities' is mandatory for request node.";

    }
}
