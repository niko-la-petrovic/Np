﻿using System.Text.Json.Serialization;

namespace Np.Youtube.Dtos.Playlists
{
    public class PageInfo
    {
        [JsonPropertyName("totalResults")]
        public long TotalResults { get; set; }

        [JsonPropertyName("resultsPerPage")]
        public long ResultsPerPage { get; set; }
    }
}
