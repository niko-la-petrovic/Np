using System;
using System.Text.Json.Serialization;

namespace Np.Youtube.Dtos.PlaylistItems
{
    public class Snippet
    {
        [JsonPropertyName("publishedAt")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("thumbnails")]
        public Thumbnails Thumbnails { get; set; }

        [JsonPropertyName("channelTitle")]
        public string ChannelTitle { get; set; }

        [JsonPropertyName("playlistId")]
        public string PlaylistId { get; set; }

        [JsonPropertyName("position")]
        public long Position { get; set; }

        [JsonPropertyName("resourceId")]
        public ResourceId ResourceId { get; set; }
    }
}
