using System.Xml.Linq;

namespace OGCSharp.Wms.Models
{
    public abstract class WmsElement
    {
        public const string ServiceNode = "Service";
        public const string CapabilityNode = "Capability";
        public const string TitleNode = "Title";
        public const string OnlineResourceNode = "OnlineResource";
        public const string AbstractNode = "Abstract";
        public const string FeesNode = "Fees";
        public const string AccessConstraintsNode = "AccessConstraints";
        public const string KeywordListNode = "KeywordList";
        public const string KeywordNode = "Keyword";
        public const string ContactInformationNode = "ContactInformation";
        public const string ContactAddressNode = "ContactAddress";
        public const string ContactOrganizationNode = "ContactOrganization";
        public const string ContactPersonNode = "ContactPerson";
        public const string CityNode = "City";
        public const string CountryNode = "Country";
        public const string PostCodeNode = "PostCode";
        public const string ContactElectronicMailAddressNode = "ContactElectronicMailAddress";
        public const string ContactFacsimileTelephoneNode = "ContactFacsimileTelephone";
        public const string ContactPersonPrimaryNode = "ContactPersonPrimary";
        public const string ContactVoiceTelephoneNode = "ContactVoiceTelephone";
        public const string RequestNode = "Request";
        public const string LayerNode = "Layer";
        public const string ExceptionNode = "Exception";
        public const string VendorSpecificCapabilitiesNode = "VendorSpecificCapabilities";
        public const string FormatNode = "Format";
        public const string GetMapNode = "GetMap";
        public const string UserDefinedSymbolizationNode = "UserDefinedSymbolization";
        public const string GetCapabilitiesNode = "GetCapabilities";
        public const string GetFeatureInfoNode = "GetFeatureInfo";
        public const string DescribeLayerNode = "DescribeLayer";
        public const string GetLegendGraphicNode = "GetLegendGraphic";
        public const string GetStylesNode = "GetStyles";
        public const string PutStylesNode = "PutStyles";
        public const string DCPTypeNode = "DCPType";
        public const string HTTPNode = "HTTP";
        public const string HrefAttributeNode = "href";
        public const string NameNode = "Name";
        public const string SRSNode = "SRS";
        public const string CRSNode = "CRS";
        public const string StyleNode = "Style";
        public const string LegendUrlNode = "LegendUrl";
        public const string StyleSheetURLNode = "StyleSheetURL";
        public const string LatLonBoundingBoxNode = "LatLonBoundingBox";
        public const string EX_GeographicBoundingBoxNode = "EX_GeographicBoundingBox";
        public const string WestBoundLongitudeNode = "westBoundLongitude";
        public const string SouthBoundLatitudeNode = "southBoundLatitude";
        public const string EastBoundLongitudeNode = "eastBoundLongitude";
        public const string NorthBoundLatitudeNode = "northBoundLatitude";
        public const string BoundingBoxNode = "BoundingBox";
        public const string VersionAttributeNode = "version";
        public const string MinXAttributeNode = "minx";
        public const string MinYAttributeNode = "miny";
        public const string MaxXAttributeNode = "maxx";
        public const string MaxYAttributeNode = "maxy";
        public const string WidthAttributeNode = "width";
        public const string HeightAttributeNode = "height";
        public const string QueryableAttributeNode = "queryable";
        public const string CascadedAttributeNode = "cascaded";
        public const string OpaqueAttributeNode = "opaque";
        public const string NoSubsetsAttributeNode = "noSubsets";
        public const string FixedWidthAttributeNode = "fixedWidth";
        public const string FixedHeightAttributeNode = "fixedHeight";
        public const string SupportSLDAttributeNode = "SupportSLD";
        public const string UserLayerAttributeNode = "UserLayer";
        public const string UserStyleAttributeNode = "UserStyle";
        public const string RemoteWFSAttributeNode = "RemoteWFS";
        public const string RemoteWCSAttributeNode = "RemoteWCS";
        public const string InlineFeatureAttributeNode = "InlineFeature";
        public const string WestBoundLongitudeAttributeNode = "westBoundLongitude";
        public const string SouthBoundLongitudeAttributeNode = "southBoundLatitude";
        public const string EastBoundLongitudeAttributeNode = "eastBoundLongitude";
        public const string NorthBoundLongitudeAttributeNode = "northBoundLatitude";
        
        public const string NameAttributeNode = "name";
        public const string UnitsAttributeNode = "units";
        public const string UnitSymbolAttributeNode = "unitSymbol";
        public const string DefaultAttributeNode = "multipleValues";
        public const string MultipleAttributeNode = "nearestValue";
        public const string NearestAttributeNode = "current";
        public const string CurrentAttributeNode = "extent";

        public const string XLinkHrefAttributeNode = "href";
        public const string AddressNode = "Address";
        public const string AddressTypeNode = "AddressType";
        public const string MaxWidthNode = "MaxWidth";
        public const string MaxHeightNode = "MaxHeight";
        public const string DimensionNode = "Dimension";

        /// <summary>
        /// Try to parse a given node into current object.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parsingContext"></param>
        internal abstract void Parse(XElement node, WmsParsingContext parsingContext);

    }
}
