
namespace OGCSharp.Wms.Models
{
    /// <summary>
    /// Structure for storing info on an Online Resource
    /// </summary>
    public struct WmsOnlineResource
    {
        /// <summary>
        /// URI of online resource
        /// </summary>
        public string OnlineResource;

        /// <summary>
        /// Type of online resource (Ex. request method 'Get' or 'Post')
        /// </summary>
        public string Type;
    }
}
