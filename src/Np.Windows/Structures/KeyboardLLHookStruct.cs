using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Np.Windows.Structs
{
    /// <summary>
    /// Winuser.h KBDLLHOOKSTRUCT structure.
    /// Contains information about a low-level keyboard message used by LowLevelKeyboardProc.
    /// </summary>
    /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-kbdllhookstruct</remarks>
    [StructLayout(LayoutKind.Sequential)]
    public class KeyboardLLHookStruct
    {
        /// <summary>
        /// The virtual-key code (1-254).
        /// </summary>
        public Keys vkCode;

        /// <summary>
        /// The hardware scan code for the key. 
        /// </summary>
        public uint scanCode;

        /// <summary>
        /// The extended-key flag, event-injected flags, context code, and transition-state flag.
        /// Testing individual bits reveals information about the hook.
        /// </summary>
        /// <remarks>If treated as a bit field, the bits can be tested.
        /// Bit|Information
        /// 0	Specifies whether the key is an extended key, such as a function key or a key on the numeric keypad. The value is 1 if the key is an extended key; otherwise, it is 0.
        /// 1	Specifies whether the event was injected from a process running at lower integrity level.The value is 1 if that is the case; otherwise, it is 0. Note that bit 4 is also set whenever bit 1 is set.
        /// 2-3	Reserved.
        /// 4	Specifies whether the event was injected.The value is 1 if that is the case; otherwise, it is 0. Note that bit 1 is not necessarily set when bit 4 is set.
        /// 5	The context code.The value is 1 if the ALT key is pressed; otherwise, it is 0.
        /// 6	Reserved.
        /// 7	The transition state.The value is 0 if the key is pressed and 1 if it is being released.
        ///</remarks>
        public uint flags;

        /// <summary>
        /// Specifies the time stamp for this message. Value obtained through GetMessageTime.
        /// </summary>
        /// <remarks>https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmessagetime</remarks>
        public uint time;

        /// <summary>
        /// Specifies extra information associated with the message. 
        /// </summary>
        public uint dwExtraInfo;
    }
}