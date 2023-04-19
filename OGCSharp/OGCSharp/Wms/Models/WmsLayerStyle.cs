
namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for storing information about a WMS Layer Style
    /// </summary>
    public struct WmsLayerStyle
    {
        /// <summary>
        /// Abstract
        /// </summary>
        public string Abstract;

        /// <summary>
        /// Legend
        /// </summary>
        public WmsStyleLegend LegendUrl;

        /// <summary>
        /// Name
        /// </summary>
        public string Name;

        /// <summary>
        /// Style Sheet Url
        /// </summary>
        public WmsOnlineResource StyleSheetUrl;

        /// <summary>
        /// Title
        /// </summary>
        public string Title;
    }
}
