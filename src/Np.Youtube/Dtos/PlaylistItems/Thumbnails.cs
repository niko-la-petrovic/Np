using System.Text.Json.Serialization;

namespace Np.Youtube.Dtos.PlaylistItems
{
    public class Thumbnails
    {
        [JsonPropertyName("default")]
        public Thumbnail Default { get; set; }

        [JsonPropertyName("medium")]
        public Thumbnail Medium { get; set; }

        [JsonPropertyName("high")]
        public Thumbnail High { get; set; }

        [JsonPropertyName("standard")]
        public Thumbnail Standard { get; set; }

        [JsonPropertyName("maxres")]
        public Thumbnail Maxres { get; set; }
    }
}
