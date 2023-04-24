using OGCSharp.Types;
using System.Xml.Linq;

namespace OGCSharp.Wms
{
    /// <summary>
    /// Represents an object used during document parsing.
    /// </summary>
    internal class WmsParsingContext
    {
        public WmsVersion Version { get; set; }

        public XNamespace ParsingNamespace => Version switch
        {
            WmsVersion.V1_0_0 => XNamespace.None,
            WmsVersion.V1_1_0 => XNamespace.None,
            WmsVersion.V1_3_0 => WmsNamespaces.Wms130,
            _ => XNamespace.None
        };

        public ICollection<string> ParsingErrors { get; } = new List<string>();

        public WmsParsingResult ToParsingResult() => new WmsParsingResult()
        {
            ParsingErrors = ParsingErrors
        };

    }
}
