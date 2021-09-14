using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Np.Windows.DllImports
{
    public class MouseEvent
    {
        // TODO use SendInput instead https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mouse_event</remarks>
        [DllImport(Dlls.User32, CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        public enum MouseEventFlags : uint
        {
            MOUSEEVENTF_LEFTDOWN = 0x02,
            MOUSEEVENTF_LEFTUP = 0x04,
            MOUSEEVENTF_RIGHTDOWN = 0x08,
            MOUSEEVENTF_RIGHTUP = 0x10
        }
    }
}
