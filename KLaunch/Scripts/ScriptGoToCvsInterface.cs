﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KLaunch.Scripts
{
    class GoToCvsInterface : Script
    {
        public bool TakesDestination()
        {
            return false;
        }

        public string GetNotes()
        {
            return "This script automatically opens the CVS interface.";
        }

        public void Run(int hWndMain, Automate automate, KConnection connection, KConnection destination, Form parent)
        {
            do
            {
                int hWnd = Automate.WinWait("KCMLMasterForm_32", "", Automate.WinMatchMode.Start, 5);

                if (hWnd == 0) break;

                int hControlUtilities = Automate.ControlGetHandle(hWnd, "KCMLButton_32", "Utilities...");
                if (hControlUtilities == 0)
                {
                    Thread.Sleep(300);
                    automate.Send("%(u)");

                    int hControlList = Automate.ControlGetHandle(hWnd, "ListBox_Class", "");
                    if (hControlList == 0) break;

                    Thread.Sleep(200);

                    automate.Send("c");
                    //Automate.SendChar(hControlList, 'c');

                    Thread.Sleep(200);

                    int hControlOk = Automate.ControlGetHandle(hWnd, "KCMLButton_32", "OK");
                    if (hControlOk == 0) break;

                    Thread.Sleep(200);

                    Automate.ControlClick(hControlOk);
                }
                else
                {
                    Automate.ControlClick(hControlUtilities);

                    Thread.Sleep(200);

                    int hWndUtilities = Automate.WinWait("KCMLMasterForm_32", "Select Item", Automate.WinMatchMode.Start, 5);
                    if (hWndUtilities == 0) break;

                    int hControlList = Automate.ControlGetHandle(hWndUtilities, "ListBox_Class", "");
                    if (hControlList == 0) break;

                    Thread.Sleep(200);

                    automate.Send("c");
                    //Automate.SendChar(hControlList, 'c');

                    Thread.Sleep(200);

                    int hControlOk = Automate.ControlGetHandle(hWndUtilities, "KCMLButton_32", "OK");
                    if (hControlOk == 0) break;

                    Thread.Sleep(200);

                    Automate.ControlClick(hControlOk);
                }
            } while (false);
        }
    }
}
