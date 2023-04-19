using OGCSharp;
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
        private WmtsTileMatrixSetLink tileMatrixSetLinkFacade;

        public WmtsLayerNode(XElement layerXml) : base(layerXml)
        {
            this.tileMatrixSetLinkFacade = new WmtsTileMatrixSetLink(this.xmlNode.ElementUnprefixed(TileMatrixSetLinkElement));
        }

        public List<XElement> Dimensions => this.xmlNode.ElementsUnprefixed(DimensionNode).ToList();

        public XElement Title => this.xmlNode.ElementUnprefixed(TitleElement);

        public XElement Identifier => this.xmlNode.ElementUnprefixed(IdentifierElement);

        public WmtsTileMatrixSetLink TileMatrixSetLink => this.tileMatrixSetLinkFacade;

        public List<XElement> Styles => this.xmlNode.ElementsUnprefixed(StyleElement).ToList();

        public List<XElement> ResourceUrls => this.xmlNode.ElementsUnprefixed(ResourceURLElement).ToList();

    }


}
