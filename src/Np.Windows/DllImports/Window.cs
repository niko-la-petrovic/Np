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
    /// Imports related to windows.
    /// </summary>
    public class Window
    {
        // TODO
        /// <summary>Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of which other windows are painted.</summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdesktopwindow</remarks>
        [DllImport(Dlls.User32)]
        public static extern IntPtr GetDesktopWindow();

        // TODO
        /// <summary></summary>
        /// <returns>Nonzero if successful, otherwise zero.</returns>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrect</remarks>
        [DllImport(Dlls.User32)]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
    }
}
