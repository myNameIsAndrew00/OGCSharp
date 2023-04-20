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
            this.tileMatrixSetLinkFacade = new WmtsTileMatrixSetLink(this._xmlNode.ElementUnprefixed(TileMatrixSetLinkElement));
        }

        public List<XElement> Dimensions => this._xmlNode.ElementsUnprefixed(DimensionNode).ToList();

        public string Title => this._xmlNode.ElementUnprefixed(TitleElement)?.Value;

        public string Identifier => this._xmlNode.ElementUnprefixed(IdentifierElement)?.Value;

        public WmtsTileMatrixSetLink TileMatrixSetLink => this.tileMatrixSetLinkFacade;

        public List<XElement> Styles => this._xmlNode.ElementsUnprefixed(StyleElement).ToList();

        public List<XElement> ResourceUrls => this._xmlNode.ElementsUnprefixed(ResourceURLElement).ToList();

    }


}
