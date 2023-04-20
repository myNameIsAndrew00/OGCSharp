using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    internal class WmsUserDefinedSymbolization : WmsElement
    {
        public WmsUserDefinedSymbolization(XElement xmlNode) : base(xmlNode)
        {
            SupportSLD = xmlNode.AttributeAsBool(SupportSLDAttributeNode);
            UserLayer = xmlNode.AttributeAsBool(UserLayerAttributeNode); 
            UserStyle = xmlNode.AttributeAsBool(UserStyleAttributeNode); 
            RemoteWfs = xmlNode.AttributeAsBool(RemoteWFSAttributeNode); 
            InlineFeature = xmlNode.AttributeAsBool(InlineFeatureAttributeNode);
            RemoteWcs = xmlNode.AttributeAsBool(SupportSLDAttributeNode); 
        }

         public bool SupportSLD { get; set; }

        public bool UserLayer { get; set; } 

        public bool UserStyle { get; set; }

        public bool RemoteWfs { get; set; }

        public bool InlineFeature { get; set; } 

        public bool RemoteWcs { get; set; }
        
    }
}
