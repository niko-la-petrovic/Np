using System;
using System.Text.Json.Serialization;

namespace Np.Youtube.Dtos.PlaylistItems
{
    public class Thumbnail
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }
    }
}
