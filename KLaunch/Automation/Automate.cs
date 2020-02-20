/*
 * Created by SharpDevelop.
 * User: paezj
 * Date: 18/07/2018
 * Time: 16:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KLaunch
{
	/// <summary>
	/// Description of WindowFinder.
	/// </summary>
	public class Automate : WinApi
	{
        // TODO Add focus or bring to front command to the send keys methods

        public enum WinMatchMode { Exact, Start, Any };
        public delegate int CallBack(int hWnd, int lParam);

        private int shortDelay;     // Delay times between commands
        private int mediumDelay;
        private int longDelay;
        private int moduleBuildDelay;
        private double speedModifier;   

        public Automate()
        {
            // Get delay values from parameters
            int shortDelay = 0;
            int mediumDelay = 0;
            int longDelay = 0;
            int moduleBuildDelay = 0;
            int.TryParse(ConfigurationManager.AppSettings["ShortDelay"], out shortDelay);
            int.TryParse(ConfigurationManager.AppSettings["MediumDelay"], out mediumDelay);
            int.TryParse(ConfigurationManager.AppSettings["LongDelay"], out longDelay);
            int.TryParse(ConfigurationManager.AppSettings["ModuleBuildDelay"], out moduleBuildDelay);
            // TODO Get speed modifier parameter

            this.shortDelay = shortDelay;
            this.mediumDelay = mediumDelay;
            this.longDelay = longDelay;
            this.moduleBuildDelay = moduleBuildDelay;
        }

        public Automate(int shortDelay, int mediumDelay, int longDelay, int moduleBuildDelay)
		{
            this.shortDelay = shortDelay;
            this.mediumDelay = mediumDelay;
            this.longDelay = longDelay;
            this.moduleBuildDelay = moduleBuildDelay;
        }		

        // Miscellaneous delay functions
        public void ShortDelay()
        {
            Thread.Sleep(shortDelay);
        }

        public void MediumDelay()
        {
            Thread.Sleep(mediumDelay);
        }

        public void LongDelay()
        {
            Thread.Sleep(longDelay);
        }

        public void CustomDelay(int delayTime = 0)
        {
            if (delayTime == 0)
                Thread.Sleep(moduleBuildDelay);
            else
                Thread.Sleep(delayTime);
        }

        // Control management methods
        // ControlClick: Sends a mouse click command to a given control.
        // TODO Add overload for className/Instance
        public static  bool ControlClick(int hWnd)
        {
            return WinApi.PostMessage(hWnd, WinApi.BM_CLICK, 0, 0);
        }
        // ControlGetHandle: Retrieves the internal handle of a control.
        public static int ControlGetHandle(int hWnd, string className, string controlText)
        {
            return FindControlStart(hWnd, className, controlText);
        }
        public static int ControlGetHandle(int hWnd, string className, int instance)
        {
            int hWndFound = 0;
            int instanceCount = 0;

            CallBack callBack = delegate (int hWndToCheck, int lParam) {
                StringBuilder sb = new StringBuilder(512);

                WinApi.GetWindowText(hWndToCheck, sb, 512);
                string windowText = sb.ToString().Trim();

                WinApi.GetClassName(hWndToCheck, sb, 512);
                string classText = sb.ToString().Trim();

                if (classText.Equals(className))
                {
                    instanceCount++;
                    
                    if (instanceCount == instance)
                    {
                        hWndFound = hWndToCheck;
                        return 0;
                    }
                }
                return 1;
            };

            WinApi.EnumChildWindows(hWnd, callBack, 0);

            return hWndFound;
        }

        // Send a string of keys to the active application
        // and applies the specified delay afterwards
        public void Send(string keys)
        {
            SendKeys.Send(keys);
        }
        // Send a string to a control
        public static bool SendString(int hWnd, string stringToSend)
        {
            foreach (char c in stringToSend)
                if (SendChar(hWnd, c) == false)
                    return false;
            return true;
        }

        // Send a character to a control
        public static bool SendChar(int hWnd, char c)
        {
            return WinApi.PostMessage(hWnd, WinApi.WM_CHAR, c, 0);
        }
        // ConvertKeys will convert characters with special meaning such as +, ^, %, ~, {, }, [ and ]
        // So they can be used with SendKeysSend
        public static string ConvertKeys(string keys)
        {
            string convertedKeys = "";

            foreach (char c in keys)
            {
                switch (c)
                {
                    case '+':
                    case '^':
                    case '%':
                    case '~':
                    case '(':
                    case ')':
                    case '{':
                    case '}':
                    case '[':
                    case ']':
                        convertedKeys = convertedKeys + "{" + c + "}";
                        break;
                    default:
                        convertedKeys = convertedKeys + c;
                        break;
                }
            }
            return convertedKeys;
        }

        // Set focus to a window
        public static int SetFocus(int hWnd)
        {
            return WinApi.SetFocus(hWnd);
        }

        // Window management methods
        // Example: Automate.WinClose(hWnd);
        public static int WinClose(int hWnd)
        {
            return (WinApi.PostMessage(hWnd, WinApi.WM_CLOSE, 0, 0) == true ? 1 : 0);
        }

        // Check if a window exists
        public static bool WinExists(string className, string windowName, WinMatchMode mode = WinMatchMode.Start)
		{
            return (FindWindow(className, windowName, mode) != 0 ? true : false);
        }
        public static int WinExists(int hWnd)
        {
            return (WinApi.IsWindow(hWnd) != false ? 1 : 0);
        }

        // Retrieves the internal handle of a window.
        // Example: int hWnd = Automate.WinGetHandle("KCMLMasterForm_32", "OWS Version2");
        public static int WinGetHandle(string className, string windowName, WinMatchMode mode = WinMatchMode.Start)
        {
            return FindWindow(className, windowName, mode);
        }

        // Wait for a window to become available
        public static int WinWait(string className, string windowName, WinMatchMode mode = WinMatchMode.Start, long timeout = 0)
        {
            int hWnd = 0;
            int pollDelay = 250;
            long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            while ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime < (timeout * 1000)
                && hWnd == 0)
            {
                hWnd = FindWindow(className, windowName, mode);
                Thread.Sleep(pollDelay);
            }

            return hWnd;
        }

        // Private helper methods
        private static int FindControlStart(int hWnd, string className, string controlText)
        {
            int hWndFound = 0;

            CallBack callBack = delegate (int hWndToCheck, int lParam) {
                StringBuilder sb = new StringBuilder(512);

                WinApi.GetWindowText(hWndToCheck, sb, 512);
                string windowText = sb.ToString().Trim();

                WinApi.GetClassName(hWndToCheck, sb, 512);
                string classText = sb.ToString().Trim();

                if (classText.Equals(className))
                {
                    if (windowText.Replace("&", "").ToLower().StartsWith(controlText.ToLower()))
                    {
                        hWndFound = hWndToCheck;
                        return 0;
                    }
                }
                return 1;
            };

            WinApi.EnumChildWindows(hWnd, callBack, 0);

            return hWndFound;
        }
        private static int FindWindow(string className, string windowName, WinMatchMode mode = WinMatchMode.Start)
        {
            switch (mode)
            {
                case WinMatchMode.Exact:
                    return WinApi.FindWindow(className, windowName);
                case WinMatchMode.Start:
                    return FindWindowStart(className, windowName);
                case WinMatchMode.Any:
                    return FindWindowAny(className, windowName);
                default:
                    return 0;
            }
        }
        private static int FindWindowStart(string className, string windowName)
        {
            int hWndFound = 0;

            CallBack callBack = delegate (int hWnd, int lParam) {
                StringBuilder sb = new StringBuilder(512);

                WinApi.GetWindowText(hWnd, sb, 512);
                string windowText = sb.ToString().Trim();

                WinApi.GetClassName(hWnd, sb, 512);
                string classText = sb.ToString().Trim();

                if (classText.Equals(className))
                {
                    if (windowText.StartsWith(windowName))
                    {
                        hWndFound = hWnd;
                        return 0;
                    }
                }
                return 1;
            };

            WinApi.EnumWindows(callBack, 0);

            return hWndFound;
        }
        private static int FindWindowAny(string className, string windowName)
        {
            int hWndFound = 0;

            CallBack callBack = delegate (int hWnd, int lParam) {
                StringBuilder sb = new StringBuilder(512);

                WinApi.GetWindowText(hWnd, sb, 512);
                string windowText = sb.ToString().Trim();

                WinApi.GetClassName(hWnd, sb, 512);
                string classText = sb.ToString().Trim();

                if (classText.Equals(className))
                {
                    if (windowText.Contains(windowName))
                    {
                        hWndFound = hWnd;
                        return 0;
                    }
                }
                return 1;
            };

            WinApi.EnumWindows(callBack, 0);

            return hWndFound;
        }
    }
}
