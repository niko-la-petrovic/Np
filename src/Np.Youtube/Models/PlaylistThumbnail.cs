using System;
using System.Collections.Generic;
using System.Text;

namespace Np.Youtube.Models
{
    public class PlaylistThumbnail : Thumbnail
    {
        public string PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
