using Np.Youtube.Dtos.PlaylistItems;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Np.Youtube.Dtos.PlaylistItems
{
    public class PlaylistItemsResponse
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        [JsonPropertyName("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonPropertyName("pageInfo")]
        public PageInfo PageInfo { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}
