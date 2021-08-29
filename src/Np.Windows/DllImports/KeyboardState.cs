using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Np.Windows.DllImports
{
    /// <summary>
    /// Imports related to getting the keyboard state.
    /// </summary>
    public class KeyboardState
    {
        /// <summary>Copies the status of the 256 virtual keys to the specified buffer.</summary>
        /// <param name="lpKeyState">Pointer to the 256-byte array that receives the status data for each virtual key.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. 
        /// </returns>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeyboardstate</remarks>
        [DllImport(Dlls.User32)]
        public static extern bool GetKeyboardState(byte[] lpKeyState);
    }
}
