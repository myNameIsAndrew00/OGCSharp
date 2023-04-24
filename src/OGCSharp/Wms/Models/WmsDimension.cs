using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    public class WmsDimension : WmsElement
    {


        internal override void Parse(XElement node, WmsParsingContext parsingContext)
        {
            var nameAttribute = node.Attribute(NameAttributeNode);

            if (nameAttribute == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.DIMENSION_NAME_ATTR_M);
                return;
            }

            var unitsAttribute = node.Attribute(UnitsAttributeNode);

            if (unitsAttribute == null)
            {
                parsingContext.ParsingErrors.Add(WmsParsingMessages.DIMENSION_UNITS_ATTR_M);
                return;
            }

            Name = nameAttribute.Value;
            Units = unitsAttribute.Value;
            UnitSymbol = node.Attribute(UnitSymbolAttributeNode)?.Value;
            Default = node.Attribute(DefaultAttributeNode)?.Value;
            MultipleValues = node.AttributeAsInt(MultipleAttributeNode) == 1;
            NearestValue = node.AttributeAsInt(NearestAttributeNode) == 1;
            Current = node.AttributeAsInt(CurrentAttributeNode) == 1;
            Extent = node.Value;
        }

        public string Name { get; internal set; } = null!;

        public string Units { get; internal set; } = null!;

        public string? UnitSymbol { get; internal set; }

        public string? Default { get; internal set; }

        public bool? MultipleValues { get; internal set; }

        public bool? NearestValue { get; internal set; }

        public bool? Current { get; internal set; }

        public string? Extent { get; internal set; }
    }
}
