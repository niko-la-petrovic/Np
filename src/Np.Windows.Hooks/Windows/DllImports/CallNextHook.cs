using System;
using System.Runtime.InteropServices;

namespace Np.Windows.DllImports
{
    /// <summary>
    /// Imports related to calling the next hook in the hook chain.
    /// </summary>
    public class CallNextHook
    {
        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain.
        /// </summary>
        /// <param name="hhk">Ignored.</param>
        /// <param name="nCode">The hook code passed to the current hook procedure.</param>
        /// <param name="wParam">The wParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with the current hook chain.</param>
        /// <param name="lParam">The lParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with the current hook chain.</param>
        /// <returns>
        /// This value is returned by the next hook procedure in the chain. 
        /// The current hook procedure must also return this value. The meaning of the return value depends on the hook type. 
        /// For more information, see the descriptions of the individual hook procedures.
        /// </returns>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-callnexthookex</remarks>
        [DllImport(Dlls.User32, CharSet = CharSet.Auto,
             CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);
    }
}
