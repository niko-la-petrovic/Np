using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Np.Youtube.Dtos.Playlists
{
    public class PlaylistsResponse
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        [JsonPropertyName("pageInfo")]
        public PageInfo PageInfo { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}
