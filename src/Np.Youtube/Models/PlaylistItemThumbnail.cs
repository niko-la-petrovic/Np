using System;
using System.Collections.Generic;
using System.Text;

namespace Np.Youtube.Models
{
    public class PlaylistItemThumbnail : Thumbnail
    {
        public string PlaylistItemId { get; set; }

        public virtual PlaylistItem PlaylistItem { get; set; }
    }
}
