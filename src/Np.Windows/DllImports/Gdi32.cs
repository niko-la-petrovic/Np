using Np.Windows.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Np.Windows.DllImports
{
    /// <summary>
    /// GDI32-related imports.
    /// </summary>
    public class Gdi32
    {
        // TODO
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-bitblt</remarks>
        [DllImport(Dlls.Gdi32)]
        public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hdcSrc,
            int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        // TODO
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createcompatiblebitmap</remarks>
        [DllImport(Dlls.Gdi32)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
            int nHeight);

        // TODO
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createcompatibledc</remarks>
        [DllImport(Dlls.Gdi32)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        // TODO
        [DllImport(Dlls.Gdi32)]
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deletedc</remarks>
        public static extern bool DeleteDC(IntPtr hDC);

        // TODO
        [DllImport(Dlls.Gdi32)]
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deleteobject</remarks>
        public static extern bool DeleteObject(IntPtr hObject);

        // TODO
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectobject</remarks>
        [DllImport(Dlls.Gdi32)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hgdiobj);
    }
}
