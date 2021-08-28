using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Np.Windows.DllImports
{
    /// <summary>
    /// Winuser.h HOOKPROC callback function.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="wParam">
    /// Specifies whether the message is sent by the current process.
    /// If the message is sent by the current process, it is nonzero; otherwise, it is NULL.</param>
    /// <param name="lParam">
    /// A pointer to a CWPRETSTRUCT structure that contains details about the message.
    /// </param>
    /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-hookproc</remarks>
    public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);
}
