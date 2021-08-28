using System.Runtime.InteropServices;

namespace Np.Windows.Structs
{
    /// <summary>
    /// Winuser.h tagMSLLHOOKSTRUCT.
    /// Contains information about a low-level mouse event used by LowLevelMouseProc.
    /// </summary>
    /// <remarks>https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-msllhookstruct</remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseLLHookStruct
    {
        /// <summary>
        /// The Point containing the mouse coordinates. 
        /// </summary>
        public Point pt;

        /// <summary>
        /// Contains mouse data about a mouse wheel or mouse button action.
        /// </summary>
        /// <remarks>
        /// If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta. 
        /// The low-order word is reserved.
        /// A positive value indicates that the wheel was rotated forward, away from the user.
        /// A negative value indicates that the wheel was rotated backward, toward the user. 
        /// One wheel click is defined as WHEEL_DELTA, which is 120.
        /// 
        /// If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP,
        /// or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released.
        /// The low-order word is reserved. This value can be one or more of the following values.
        /// XBUTTON1 - the first X button was pressed or released.
        /// XBUTTON2 - the second X button was pressed or released.
        /// 
        /// Otherwise, mouseData is not used. 
        /// </remarks>
        public uint mouseData;

        /// <summary>
        /// The event-injected mouse-related flag.
        /// </summary>
        /// <remarks>
        /// LLMHF_INJECTED (0x00000001) - test the event-injected (from any process) flag.
        /// LLMHF_LOWER_IL_INJECTED (0x00000002) - test the event-injected (from a process running at lower integrity level) flag.
        /// </remarks>
        public uint flags;

        /// <summary>
        /// The time stamp for this message.
        /// </summary>
        public uint time;

        /// <summary>
        /// Extra information associated with the message.
        /// </summary>
        public uint dwExtraInfo;
    }
}
