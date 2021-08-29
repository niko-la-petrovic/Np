using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Np.Windows.DllImports
{
    /// <summary>
    /// Imports related to the device context (DC).
    /// </summary>
    public class DeviceContext
    {
        // TODO
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowdc</remarks>
        [DllImport(Dlls.User32)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        // TODO
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasedc</remarks>
        [DllImport(Dlls.User32)]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
    }
}
