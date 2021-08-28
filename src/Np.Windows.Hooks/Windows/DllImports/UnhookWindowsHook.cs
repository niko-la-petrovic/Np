using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Np.Windows.DllImports
{
    /// <summary>
    /// Imports related to unhooking Windows hooks.
    /// </summary>
    public class UnhookWindowsHook
    {
        /// <summary>
        /// The UnhookWindowsHookEx function removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// <param name="hhk">Handle to the hook to be removed.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-unhookwindowshookex</remarks>
        [DllImport(dllName: Dlls.User32, CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
    }
}
