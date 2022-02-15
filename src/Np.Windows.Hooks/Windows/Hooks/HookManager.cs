using System;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using Np.Windows.Structures;
using Np.Windows.DllImports;
using System.Collections.Generic;

namespace Np.Windows.Hooks
{
    /// <summary>
    /// Hook manager for Windows.
    /// </summary>
    public class HookManager
    {
        /// <summary>
        /// Occurs when the user moves the mouse, presses any mouse button or scrolls the wheel
        /// </summary>
        public event MouseEventHandler MouseAction;

        /// <summary>
        /// Occurs when the user presses a key
        /// </summary>
        public event KeyEventHandler KeyDown;

        /// <summary>
        /// Occurs when the user presses and releases 
        /// </summary>
        public event KeyPressEventHandler KeyPress;

        /// <summary>
        /// Occurs when the user releases a key
        /// </summary>
        public event KeyEventHandler KeyUp;

        /// <summary>
        /// Whether HookManager should throw exceptions or swallow them.
        /// </summary>
        public bool ShouldThrow { get; set; } = false;

        /// <summary>
        /// Last Win32 error code.
        /// </summary>
        public int LastErrorCode { get; set; }

        /// <summary>
        /// List of WindowsMessage that may be used to trigger the mouse hook procedure.
        /// </summary>
        public List<WindowsMessage> MouseHookProcTriggers { get; set; }
            = new List<WindowsMessage> { WindowsMessage.LBUTTONDOWN, WindowsMessage.RBUTTONDOWN, WindowsMessage.MOUSEWHEEL, WindowsMessage.XBUTTONDOWN };

        /// <summary>
        /// List of WindowsMessage that may be used to trigger the keyboard hook procedure.
        /// </summary>
        public List<WindowsMessage> KeyboardHookProcTriggers { get; set; }
            = new List<WindowsMessage> { WindowsMessage.KEYDOWN, WindowsMessage.SYSKEYDOWN, WindowsMessage.SYSKEYUP };

        /// <summary>
        /// Dereferences the lParam pointer as a corresponding struct and unsets the flags field if it indicates an event from
        /// an process.
        /// </summary>
        /// <value>True by default.</value>
        public bool UnsetInjectedFlag { get; set; } = false;

        /// <summary>
        /// Handle of the mouse hook procedure.
        /// </summary>
        private IntPtr mouseHookHandle = IntPtr.Zero;

        /// <summary>
        /// Handle of the keyboard hook procedure.
        /// </summary>
        private IntPtr keyboardHookHandle = IntPtr.Zero;

        /// <summary>
        /// Declare MouseHookProcedure as HookProc type.
        /// </summary>
        protected HookProc mouseHookProcedure;

        /// <summary>
        /// Declare KeyboardHookProcedure as HookProc type.
        /// </summary>
        protected HookProc keyboardHookProcedure;

        private readonly Module executingModule;

        private readonly IntPtr executingModuleHandle;

        ~HookManager()
        {
            ShouldThrow = false;
            UnhookAllHooks();
        }

        /// <summary>
        /// Creates a new instance of HookManager with default hook procedures.
        /// </summary>
        /// <param name="executingModule">The module to install the hook into.</param>
        public HookManager(Module executingModule)
        {
            mouseHookProcedure = MouseHookProc;
            keyboardHookProcedure = KeyboardHookProc;
            this.executingModule = executingModule ?? throw new ArgumentNullException(nameof(executingModule));
            executingModuleHandle = Marshal.GetHINSTANCE(executingModule);
        }

        public HookManager(IntPtr executingModuleHandle)
        {
            if (executingModuleHandle == IntPtr.Zero)
                throw new ArgumentNullException(nameof(executingModuleHandle));

            this.executingModuleHandle = executingModuleHandle;
        }

        /// <summary>
        /// Creates a new instance of HookManager with provided hook procedures.
        /// </summary>
        /// <param name="mouseHookProcedure">The HookProc for the mouse.</param>
        /// <param name="keyboardHookProcedure">The HookProc for the keyboard.</param>
        public HookManager(HookProc mouseHookProcedure, HookProc keyboardHookProcedure)
        {
            this.mouseHookProcedure = mouseHookProcedure;
            this.keyboardHookProcedure = keyboardHookProcedure;
        }

        /// <summary>
        /// Sets mouse hook.
        /// </summary>
        /// <returns>True if hooked successfully, false otherwise.</returns>
        public bool SetMouseHook()
        {
            if (mouseHookHandle != IntPtr.Zero)
                return true;

            mouseHookHandle = SetWindowsHook.SetWindowsHookEx(
                HookId.WH_MOUSE_LL,
                mouseHookProcedure,
                executingModuleHandle,
                0);

            if (mouseHookHandle == IntPtr.Zero)
            {
                LastErrorCode = Marshal.GetLastWin32Error();
                bool unhooked = UnhookMouseHook();
                if (unhooked && ShouldThrow)
                    throw new Win32Exception(LastErrorCode);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sets keyboard hook.
        /// </summary>
        /// <returns>True if hooked successfully, false otherwise.</returns>
        public bool SetKeyboardHook()
        {
            if (keyboardHookHandle != IntPtr.Zero)
                return true;

            keyboardHookHandle = SetWindowsHook.SetWindowsHookEx(
                HookId.WH_KEYBOARD_LL,
                keyboardHookProcedure,
                executingModuleHandle,
                0);

            if (keyboardHookHandle == IntPtr.Zero)
            {
                LastErrorCode = Marshal.GetLastWin32Error();
                bool unhooked = UnhookKeyboardHook();
                if (!unhooked && ShouldThrow)
                    throw new Win32Exception(LastErrorCode);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Removes mouse hook.
        /// </summary>
        /// <returns>True if unhooked successfully, false otherwise.</returns>
        public bool UnhookMouseHook()
        {
            if (mouseHookHandle == IntPtr.Zero)
                return true;

            bool hooked = UnhookWindowsHook.UnhookWindowsHookEx(mouseHookHandle);

            mouseHookHandle = IntPtr.Zero;

            if (!hooked && ShouldThrow)
            {
                LastErrorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(LastErrorCode);
            }
            return false;
        }

        /// <summary>
        /// Removes keyboard hook.
        /// </summary>
        /// <returns>True if unhooked successfully, false otherwise.</returns>
        public bool UnhookKeyboardHook()
        {
            if (keyboardHookHandle == IntPtr.Zero)
                return true;

            bool hooked = UnhookWindowsHook.UnhookWindowsHookEx(keyboardHookHandle);

            keyboardHookHandle = IntPtr.Zero;

            if (!hooked & ShouldThrow)
            {
                LastErrorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(LastErrorCode);
            }
            return false;
        }

        /// <summary>
        /// Removes all hooks.
        /// </summary>
        /// <returns>True if unhooked successfully, false otherwise.</returns>
        public bool UnhookAllHooks()
        {
            bool unhookMouse = UnhookMouseHook();
            bool unhookKeyboard = UnhookKeyboardHook();
            if (unhookMouse && unhookKeyboard)
                return true;

            return false;
        }

        /// <summary>
        /// Default mouse hook procedure to use.
        /// </summary>
        protected int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            MouseLLHookStruct mouseHookStruct = Marshal.PtrToStructure<MouseLLHookStruct>(lParam);
            if (UnsetInjectedFlag)
            {
                unsafe
                {
                    MouseLLHookStruct* ptrMouseHookStruct = (MouseLLHookStruct*)lParam;
                    if (mouseHookStruct.flags == (uint)KeyboardLLHookStructFlags.LLKHF_INJECTED
                         || mouseHookStruct.flags == (uint)KeyboardLLHookStructFlags.LLKHF_LOWER_IL_INJECTED)
                    {
                        ptrMouseHookStruct->flags = 0;
                    }
                }
            }

            if (nCode < 0 || MouseAction == null)
                return CallNextHook.CallNextHookEx(mouseHookHandle, nCode, wParam, lParam);

            WindowsMessage message = (WindowsMessage)wParam;
            MouseButtons button = MouseButtons.None;
            short delta = 0;
            short highWord = (short)((mouseHookStruct.mouseData >> 16) & 0xffff);

            string messageString = message.ToString();
            if (messageString.Contains("LBUTTON"))
            {
                button = MouseButtons.Left;
            }
            else if (messageString.Contains("RBUTTON"))
            {
                button = MouseButtons.Right;
            }
            else if (message == WindowsMessage.MOUSEHWHEEL)
            {
                button = MouseButtons.Middle;
                delta = highWord;
            }
            else if (messageString.Contains("XBUTTON"))
            {
                switch (highWord)
                {
                    case 1:
                        button = MouseButtons.XButton1;
                        break;
                    case 2:
                        button = MouseButtons.XButton2;
                        break;
                }
            }

            int clicks = 0;
            if (button != MouseButtons.None)
                if (message == WindowsMessage.LBUTTONDBLCLK
                    || message == WindowsMessage.RBUTTONDBLCLK)
                    clicks = 2;
                else clicks = 1;

            MouseEventArgs e = new MouseEventArgs(
                button,
                clicks,
                mouseHookStruct.pt.x,
                mouseHookStruct.pt.y,
                delta);

            MouseAction(this, e);

            return CallNextHook.CallNextHookEx(mouseHookHandle, nCode, wParam, lParam);
        }

        private static void AddVirtualKeyCodeIfActive(ref Keys keys, bool active, Keys vkCode)
        {
            if (active)
                keys |= vkCode;
        }

        /// <summary>
        /// Default keyboard hook procedure to use.
        /// </summary>
        protected int KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            KeyboardLLHookStruct keyboardHookStruct = Marshal.PtrToStructure<KeyboardLLHookStruct>(lParam);
            if (UnsetInjectedFlag)
            {
                unsafe
                {
                    KeyboardLLHookStruct* ptrKeyboardHookStruct = (KeyboardLLHookStruct*)lParam;
                    if (keyboardHookStruct.flags == (uint)KeyboardLLHookStructFlags.LLKHF_INJECTED
                         || keyboardHookStruct.flags == (uint)KeyboardLLHookStructFlags.LLKHF_LOWER_IL_INJECTED)
                    {
                        ptrKeyboardHookStruct->flags = 0;
                    }
                }
            }

            if (nCode < 0 || (KeyDown == null && KeyUp == null && KeyPress == null))
                return CallNextHook.CallNextHookEx(keyboardHookHandle, nCode, wParam, lParam);

            WindowsMessage message = (WindowsMessage)wParam;
            bool handled = false;
            Keys vkCode = keyboardHookStruct.vkCode;

            bool shiftActive = (KeyState.GetKeyState(VirtualKeyState.VK_SHIFT) & 0x80) == 0x80;
            bool controlActive = (KeyState.GetKeyState(VirtualKeyState.VK_CONTROL) & 0x80) == 0x80;
            bool altActive = (KeyState.GetKeyState(VirtualKeyState.VK_MENU) & 0x80) == 0x80;
            bool capsLockActive = (KeyState.GetKeyState(VirtualKeyState.VK_CAPITAL) & 0x1) == 0x1;

            AddVirtualKeyCodeIfActive(ref vkCode, shiftActive, Keys.Shift);
            AddVirtualKeyCodeIfActive(ref vkCode, altActive, Keys.Alt);
            AddVirtualKeyCodeIfActive(ref vkCode, controlActive, Keys.Control);
            AddVirtualKeyCodeIfActive(ref vkCode, capsLockActive, Keys.CapsLock);

            KeyEventArgs e = new KeyEventArgs(vkCode);

            if (KeyDown != null && (message == WindowsMessage.KEYDOWN
                || message == WindowsMessage.SYSKEYDOWN))
            {
                KeyDown(this, e);
                handled |= e.Handled;
            }

            if (KeyPress != null && message == WindowsMessage.KEYDOWN)
            {
                byte[] keyState = new byte[256];
                KeyboardState.GetKeyboardState(keyState);
                byte[] inBuffer = new byte[2];
                if (Ascii.ToAscii(
                    vkCode,
                    keyboardHookStruct.scanCode,
                    keyState,
                    inBuffer,
                    keyboardHookStruct.flags) == 1)
                {
                    char key = (char)inBuffer[0];
                    if ((capsLockActive ^ shiftActive) && char.IsLetter(key))
                        key = char.ToUpper(key);
                    var pressedKey = new KeyPressEventArgs(key);
                    KeyPress(this, pressedKey);
                    handled |= e.Handled;
                }
            }

            if (KeyUp != null && (message == WindowsMessage.KEYUP
                || message == WindowsMessage.SYSKEYUP))
            {
                KeyUp(this, e);
                handled |= e.Handled;
            }

            // TODO reconsider this part
            if (handled)
                return 1;
            else
                return CallNextHook.CallNextHookEx(keyboardHookHandle, nCode, wParam, lParam);
        }

    }
}
