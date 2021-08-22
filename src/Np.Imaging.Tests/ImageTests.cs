using System;
using Xunit;

namespace Np.Imaging.Tests
{
    public class ImageTests
    {
        [Fact]
        public void IsValidExtension_Passes()
        {
            Assert.True(Image.Extension.IsValidExtension("png"));
            Assert.True(Image.Extension.IsValidExtension(".png"));
            Assert.True(Image.Extension.IsValidExtension("PNG"));
            Assert.True(Image.Extension.IsValidExtension(".PNG"));
        }
    }
}
