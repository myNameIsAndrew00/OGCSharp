using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCSharp.Wms
{
    public class WmsParsingResult
    {
        public ICollection<string> ParsingErrors { get; init; } = new List<string>();

        public bool FailedReading { get; internal set; } 

        public bool HasErrors => ParsingErrors.Count > 0 || FailedReading;
    }
}
