using System;
using System.Collections.Generic;

namespace Np.Imaging
{
    public class Image
    {
        public static class Extension
        {
            public static readonly List<string> Extensions = new()
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".bmp",
                ".tif",
                ".tiff",
                ".gif",
                ".eps",
                ".raw"
            };

            public static bool IsValidExtension(string extension)
            {
                string extensionToCheck = extension.StartsWith('.') ? extension : $".{extension}";
                extensionToCheck = extensionToCheck.ToLower();

                return Extensions.Contains(extensionToCheck);
            }
        }
    }
}
