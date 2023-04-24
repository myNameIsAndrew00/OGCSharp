using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    public class WmsUserDefinedSymbolization : WmsElement
    {
        
        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            SupportSLD = node.AttributeAsInt(SupportSLDAttributeNode) == 1;
            UserLayer = node.AttributeAsInt(UserLayerAttributeNode) == 1;
            UserStyle = node.AttributeAsInt(UserStyleAttributeNode) == 1;
            RemoteWfs = node.AttributeAsInt(RemoteWFSAttributeNode) == 1;
            InlineFeature = node.AttributeAsInt(InlineFeatureAttributeNode) == 1;
            RemoteWcs = node.AttributeAsInt(SupportSLDAttributeNode) == 1;
        }

        public bool SupportSLD { get; set; }

        public bool UserLayer { get; set; } 

        public bool UserStyle { get; set; }

        public bool RemoteWfs { get; set; }

        public bool InlineFeature { get; set; } 

        public bool RemoteWcs { get; set; }
    
    }
}
