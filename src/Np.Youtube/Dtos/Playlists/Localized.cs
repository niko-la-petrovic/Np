using System.Text.Json.Serialization;

namespace Np.Youtube.Dtos.Playlists
{
    public class Localized
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
