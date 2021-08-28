using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Np.Windows.DllImports;

namespace Np.Windows.DllImports
{
    /// <summary>
    /// ASCII-related imports.
    /// </summary>
    public class Ascii
    {
        /// <summary>
        /// Winuser.h ToAscii function.
        /// The ToAscii function translates the specified virtual-key code and keyboard state to the corresponding character or characters.
        /// </summary>
        /// <param name="uVirtKey">The virtual-key code to be translated - https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes</param>
        /// <param name="uScanCode">The hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed).</param>
        /// <param name="lpKeyState">
        /// A pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of one key.
        /// If the high-order bit of a byte is set, the key is down (pressed).
        /// </param>
        /// <param name="lpChar">The buffer that receives the translated character or characters.</param>
        /// <param name="uFlags">This parameter must be 1 if a menu is active, or 0 otherwise.</param>
        /// <returns>
        /// 0 - the specified virtual key has no translation for the current state of the keyboard.
        /// 1 - one character was copied to the buffer.
        /// 2 - two characters were copied to the buffer.This usually happens when a dead-key character (accent or diacritic) stored in the keyboard layout cannot be composed with the specified virtual key to form a single character.
        /// </returns>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-toascii</remarks>
        [DllImport(Dlls.User32)]
        public static extern int ToAscii(
            Keys uVirtKey,
            uint uScanCode,
            in byte[] lpKeyState,
            byte[] lpChar,
            uint uFlags);
    }
}
