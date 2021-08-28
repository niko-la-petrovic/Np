using System.Runtime.InteropServices;

namespace Np.Windows.Structs
{
    /// <summary>
    /// Windef.h POINT structure.
    /// </summary>
    /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/windef/ns-windef-point</remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        /// <summary>
        /// X-coordinate.
        /// </summary>
        public int x;
        /// <summary>
        /// Y-coordinate.
        /// </summary>
        public int y;
    }
}
