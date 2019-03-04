using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KLaunch.Scripts
{
    class SendControlBreak : Script
    {
        public bool TakesDestination()
        {
            return false;
        }

        public string GetNotes()
        {
            return "This script sends a CONTROL-BREAK sequence to the first Autoline pack it finds.";
        }

        public void Run(int hWndMain, KConnection connection, KConnection destination, Form parent)
        {
            do
            {
                int hWnd = Automate.WinWait("KCMLMasterForm_32", "", Automate.WinMatchMode.Start, 5);

                if (hWnd == 0)
                {
                    // If the main window did not become active check for a system info windows
                    hWnd = Automate.WinWait("#32770", "System", Automate.WinMatchMode.Any, 3);

                    if (hWnd != 0)
                    {
                        // System info window found, click on the button to close it
                        int hSystemInfoButton = Automate.ControlGetHandle(hWnd, "Button", "");
                        if (hSystemInfoButton != 0)
                        {
                            Thread.Sleep(500);
                            Automate.ControlClick(hSystemInfoButton);
                        }
                        else
                        {
                            WinApi.SetForegroundWindow(hWndMain);
                            MessageBox.Show("System info button not found");
                            break;
                        }
                    }
                    else
                    {
                        // System info window not found either, end process
                        WinApi.SetForegroundWindow(hWndMain);
                        MessageBox.Show("Main form not found");
                        break;

                    }
                }

                Thread.Sleep(200);
                WinApi.SetForegroundWindow(hWnd);

                Thread.Sleep(500);
                SendKeys.Send("^{BREAK}");
            } while (false);
        }
    }
}
