using OGCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsOperationMetadata : WmsElement
    {
        private XElement? getTileNode;

        public WmtsOperationMetadata(XElement xmlNode) : base(xmlNode)
        {
            IEnumerable<XElement>? getTileNodes = this.xmlNode
                .ElementsUnprefixed(OperationNode).Where(element => element.Attributes().Where(attribute => attribute.Name.LocalName == "name"
                                                                        && attribute.Value == "GetTile").Count() > 0).FirstOrDefault()?
                .ElementUnprefixed(DcpNode)
                .ElementUnprefixed(HttpNode)
                .ElementsUnprefixed(GetNode);

            // search for a endpoint which supports kvp query mode for tiles.
            getTileNode = getTileNodes?.FirstOrDefault(node =>
            {
                var constraints = node.ElementsUnprefixed(ConstraintElement).Where(
                    item => item.Attributes().Any(attribute => attribute.Name.LocalName == "name" && attribute.Value == "GetEncoding"));

                return constraints.Any(constraint =>
                    constraint.ElementUnprefixed(AllowedValuesElement).ElementUnprefixed(ValueElement).Value == "KVP");
            });
        }

        public string? TileHref => getTileNode?.Attribute(WmsElement.XLinkNamespace + "href")?.Value;

        // for now, only kvp tile nodes are supported to be parsed.
        public string? TileEncoding => getTileNode == null ? null : "KVP";

    }
}
