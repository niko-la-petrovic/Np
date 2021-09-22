using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Np.Windows.DllImports
{

    public class KeyboardEvent
    {
        // TODO import SendInput as well https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-keybd_event</remarks>
        [DllImport(Dlls.User32, CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        public enum KeyboardEventFlags : uint
        {
            KEYEVENTF_EXTENDEDKEY = 0x0001,
            KEYEVENTF_KEYUP = 0x0002
        }
    }
}
