using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Np.Windows.Structures;

namespace Np.Windows.DllImports
{
    /// <summary>
    /// Imports related to key states.
    /// </summary>
    public class KeyState
    {
        /// <summary>
        /// Retrieves the status of the specified virtual key. The status specifies whether the key is up, down, or toggled (on, off—alternating each time the key is pressed).</summary>
        /// <param name="nVirtKey">
        /// A virtual key. If the desired virtual key is a letter or digit (A through Z, a through z, or 0 through 9), nVirtKey must be set to the ASCII value of that character. For other keys, it must be a virtual-key code.
        /// If a non-English keyboard layout is used, virtual keys with values in the range ASCII A through Z and 0 through 9 are used to specify most of the character keys.For example, for the German keyboard layout, the virtual key of value ASCII O(0x4F) refers to the "o" key, whereas VK_OEM_1 refers to the "o with umlaut" key.
        ///</param>
        /// <returns>
        /// The return value specifies the status of the specified virtual key, as follows:
        /// If the high-order bit (MSb) is 1, the key is down; otherwise, it is up.
        /// If the low-order bit (LSb) is 1, the key is toggled. A key, such as the CAPS LOCK key, is toggled if it is turned on.The key is off and untoggled if the low-order bit is 0. A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
        ///</returns>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeystate</remarks>
        [DllImport(Dlls.User32, CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short GetKeyState(VirtualKeyState nVirtKey);

    }
}
