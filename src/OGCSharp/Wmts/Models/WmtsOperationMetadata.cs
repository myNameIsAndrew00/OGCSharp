using OGCSharp;
using OGCSharp.Wmts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{
    internal class WmtsOperationMetadata : WmtsElement
    { 
        internal override void Parse(XElement node, WmtsParsingContext parsingContext)
        {
            IEnumerable<XElement>? getTileNodes = node
                .ElementsUnprefixed(OperationNode).Where(element => element.Attributes().Where(attribute => attribute.Name.LocalName == "name"
                                                                        && attribute.Value == "GetTile").Count() > 0).FirstOrDefault()?
                .ElementUnprefixed(DcpNode)
                .ElementUnprefixed(HttpNode)
                .ElementsUnprefixed(GetNode);

            // search for a endpoint which supports kvp query mode for tiles.
            var getTileNode = getTileNodes?.FirstOrDefault(node =>
            {
                var constraints = node.ElementsUnprefixed(ConstraintElement).Where(
                    item => item.Attributes().Any(attribute => attribute.Name.LocalName == "name" && attribute.Value == "GetEncoding"));

                return constraints.Any(constraint =>
                    constraint.ElementUnprefixed(AllowedValuesElement).ElementUnprefixed(ValueElement).Value == "KVP");
            });


            TileHref = getTileNode?.Attribute(WmtsConstants.XLinkNamespace + "href")?.Value;
            TileEncoding = getTileNode == null ? null : "KVP";
        }

        public string? TileHref { get; internal set; }

        // for now, only kvp tile nodes are supported to be parsed.
        public string? TileEncoding { get; set; }

    }
}
