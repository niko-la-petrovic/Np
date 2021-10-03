using System;
using System.Collections.Generic;
using System.Text;

namespace Np.Youtube.Models
{
    public class Thumbnail
    {
        public string Id { get; set; }

        public string Uri { get; set; }

        public int Width{ get; set; }

        public int Height { get; set; }

        public string SizeDescriptor { get; set; }
    }
}
