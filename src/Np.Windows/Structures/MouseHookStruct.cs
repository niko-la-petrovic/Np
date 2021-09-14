using System.Runtime.InteropServices;

namespace Np.Windows.Structures
{
    /// <summary>
    /// Winuser.h MOUSEHOOKSTRUCT structure.
    /// Contains information about a mouse event passed to a WH_MOUSE hook procedure.
    /// </summary>
    /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mousehookstruct</remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseHookStruct
    {
        /// <summary>
        /// A Point containing the mouse coordinates. 
        /// </summary>
        public Point pt;

        /// <summary>
        /// Handle to the window that will receive the mouse message corresponding to the mouse event. 
        /// </summary>
        public int hwnd;

        /// <summary>
        /// Hit-test code - determines which part of the window the given coordinate corresponds to.
        /// WM_NCHITTEST
        /// </summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest</remarks>
        public uint wHitTestCode;

        /// <summary>
        /// Extra information associated with the message.
        /// </summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput</remarks>
        public uint dwExtraInfo;
    }
}
