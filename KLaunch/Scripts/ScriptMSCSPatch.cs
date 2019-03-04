using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KLaunch.Scripts
{
    class MSCSPatch : Script
    {
        public bool TakesDestination()
        {
            return true;
        }

        public string GetNotes()
        {
            return "This script automatically open the MSCS patching program and populates the host detail fields with the selected destination data. It requires selecting a destination.";
        }

        public void Run(int hWndMain, KConnection connection, KConnection destination, Form parent)
        {
            do
            {
                int hWnd = Automate.WinWait("KCMLMasterForm_32", "Enter host details", Automate.WinMatchMode.Start, 5);
                int ret;

                if (hWnd == 0) break;

                uint procID = WinApi.GetWindowThreadProcessId(hWnd, 0);
                uint currThread = WinApi.GetCurrentThreadId();
                bool lret = WinApi.AttachThreadInput(currThread, procID, true);

                WinApi.SetForegroundWindow(hWnd);
                ret = Automate.SetFocus(hWnd);

                int hCtrlHost = Automate.ControlGetHandle(hWnd, "KCMLEdit32", 1);
                ret = Automate.SetFocus(hCtrlHost);

                Automate.SendString(hCtrlHost, destination.Host);
                Thread.Sleep(500);

                int hCtrlUserID = Automate.ControlGetHandle(hWnd, "KCMLEdit32", 2);
                ret = Automate.SetFocus(hCtrlUserID);

                Automate.SendString(hCtrlUserID, destination.User);
                Thread.Sleep(500);

                int hCtrlPassword = Automate.ControlGetHandle(hWnd, "KCMLEdit32", 3);
                ret = Automate.SetFocus(hCtrlPassword);

                Automate.SendString(hCtrlPassword, destination.Password);
                Thread.Sleep(500);

                int hCtrlHome = Automate.ControlGetHandle(hWnd, "KCMLEdit32", 4);
                ret = Automate.SetFocus(hCtrlHome);

                Automate.SendString(hCtrlHome, destination.Home);
                Thread.Sleep(500);

            } while (false);
        }
    }
}
