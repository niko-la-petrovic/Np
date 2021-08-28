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
    /// Imports related to setting Windows hooks.
    /// </summary>
    public class SetWindowsHook
    {
        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain.
        /// <remarks>
        /// <returns>The handle to the hook.</returns>
        /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexa</remarks>
        [DllImport(Dlls.User32, CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(
            HookId idHook,
            HookProc lpfn,
            IntPtr hMod,
            uint dwThreadId);
    }
}
