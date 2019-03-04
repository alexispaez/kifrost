/*
 * Created by SharpDevelop.
 * User: paezj
 * Date: 18/07/2018
 * Time: 16:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace KLaunch
{
	/// <summary>
	/// Description of User32.
	/// </summary>
	public class WinApi
	{
        // Window message codes
        public const uint WM_CLOSE = 0x0010;
        public const uint WM_CHAR = 0x0102;
        // Button control messages
        public const uint BM_CLICK = 0x00F5;

        // API imports
        [DllImport("User32.dll")]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("User32.dll")]
        protected static extern bool CloseWindow(int hWnd);

        [DllImport("User32.dll")]
        protected static extern bool EnumWindows(Delegate lpEnumFunc, int lParam);

        [DllImport("User32.dll")]
        protected static extern bool EnumChildWindows(int hWnd, Delegate lpEnumFunc, int lParam);

        [DllImport("User32.dll")]
        protected static extern int FindWindow(string lpClassName, string lpWindowName);

        // Return Value
        // Type: HWND
        // The return value is the handle to the active window attached to the calling thread's message queue. Otherwise, the return value is NULL.
        [DllImport("User32.dll")]
        public static extern int GetActiveWindow();

        [DllImport("User32.dll")]
        protected static extern int GetClassName(int hWnd, StringBuilder s, int nMaxCount);

        [DllImport("Kernel32.dll")]
        public static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(int hWnd, int ProcessId);

        [DllImport("User32.dll")]
        protected static extern int GetWindowText(int hWnd, StringBuilder s, int nMaxCount);

        [DllImport("User32.dll")]
        protected static extern bool IsWindow(int hWnd);

        [DllImport("User32.dll")]
        protected static extern bool IsWindowEnabled(int hWnd);

        [DllImport("user32.dll")]
        protected static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport("User32.dll")]
        protected static extern int SetFocus(int hWnd);

        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(int hWnd);
	}
}
