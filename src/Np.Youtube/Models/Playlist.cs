using System.Collections.Generic;

namespace Np.Youtube.Models
{
    public class Playlist
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ChannelId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<PlaylistItem> Items { get; set; }

        public long ItemCount { get; set; }

        public virtual ICollection<PlaylistThumbnail> Thumbnails{ get; set; }

        public long ThumbnailCount { get; set; }
    }
}
