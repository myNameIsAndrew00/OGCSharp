using OGCSharp;
using OGCSharp.Wmts;
using OGCSharp.Wmts.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp.Geo.Wmts
{

    internal class WmtsLayerNode : WmtsElement
    {
        private WmtsTileMatrixSetLink _tileMatrixSetLinkFacade;

        internal override void Parse(XElement node, WmtsParsingContext parsingContext)
        {
            this._tileMatrixSetLinkFacade = new WmtsTileMatrixSetLink();
            this._tileMatrixSetLinkFacade.Parse(node.ElementUnprefixed(TileMatrixSetLinkElement), parsingContext);

            Dimensions = node.ElementsUnprefixed(DimensionNode).Select(
                dimensionXml =>
                {
                    XElement identifier = dimensionXml.ElementUnprefixed(WmtsElement.IdentifierElement);
                    XElement value = dimensionXml.ElementUnprefixed(WmtsElement.DefaultElement) ?? dimensionXml.ElementUnprefixed(WmtsElement.ValueElement);

                    return new WmtsDimension(identifier.Value, value.Value);
                }).ToList();


            Title = node.ElementUnprefixed(TitleElement)?.Value;
            Identifier = node.ElementUnprefixed(IdentifierElement)?.Value;
            Styles = node.ElementsUnprefixed(StyleElement).ToList();
            ResourceUrls = node.ElementsUnprefixed(ResourceURLElement).ToList();
        }

        public List<WmtsDimension> Dimensions { get; internal set; }

        public string Title { get; internal set; }

        public string Identifier { get; internal set; }

        public WmtsTileMatrixSetLink TileMatrixSetLink => this._tileMatrixSetLinkFacade;

        // todo: change to strongly typed.
        public List<XElement> Styles { get; internal set; }

        // todo: change to strongly typed.
        public List<XElement> ResourceUrls { get; internal set; }


    }


}
