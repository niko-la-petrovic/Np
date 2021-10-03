using System;
using System.Text.Json.Serialization;

namespace Np.Youtube.Dtos.Playlists
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

        [JsonPropertyName("defaultLanguage")]
        public string DefaultLanguage { get; set; }

        [JsonPropertyName("localized")]
        public Localized Localized { get; set; }
    }
}
