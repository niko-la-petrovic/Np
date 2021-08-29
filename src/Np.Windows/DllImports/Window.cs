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
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdesktopwindow</remarks>
        [DllImport(Dlls.User32)]
        public static extern IntPtr GetDesktopWindow();

        // TODO
        /// <summary></summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrect</remarks>
        [DllImport(Dlls.User32)]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
    }
}
