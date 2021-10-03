using System;
using System.Collections;
using System.Collections.Generic;

namespace Np.Youtube.Models
{
    public class PlaylistItem
    {
        public string Id { get; set; }

        public string ExternalId { get; set; }

        public string CreatorId { get; set; }

        public string Title { get; set; }

        public string Uri { get; set; }

        public string ETag { get; set; }

        public string Kind { get; set; }

        public long ExternalPosition { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }

        public long PlaylistCount { get; set; }

        public virtual ICollection<PlaylistItemThumbnail> Thumbnails { get; set; }

        public long ThumbnailCount { get; set; }
    }
}
