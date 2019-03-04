using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace KLaunch.Scripts
{
    class FixBrokenLibrary : Script
    {
        public bool TakesDestination()
        {
            return false;
        }

        public string GetNotes()
        {
            return "This script will help find what is the problem when a library won't build.";
        }

        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        public void Run(int hWndMain, KConnection connection, KConnection destination, Form parent)
        {
            string password;

            // Get delay values from parameters
            int shortDelay = 0;
            int mediumDelay = 0;
            int longDelay = 0;
            int moduleBuildDelay = 0;
            int.TryParse(ConfigurationManager.AppSettings["ShortDelay"], out shortDelay);
            int.TryParse(ConfigurationManager.AppSettings["MediumDelay"], out mediumDelay);
            int.TryParse(ConfigurationManager.AppSettings["LongDelay"], out longDelay);
            int.TryParse(ConfigurationManager.AppSettings["ModuleBuildDelay"], out moduleBuildDelay);
            // Get speed modifier parameter

            Automate automate = new Automate(shortDelay, mediumDelay, longDelay, moduleBuildDelay);

            do
            {
                // Open the password form
                PasswordForm pf = new PasswordForm();
                pf.StartPosition = FormStartPosition.CenterParent;
                if (pf.ShowDialog() == DialogResult.OK)
                    password = pf.textBoxPassword.Text;
                else
                    break;

                // Wait for main window to become active
                int hWnd = Automate.WinWait("KCMLMasterForm_32", "", Automate.WinMatchMode.Start, 3);
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
                            automate.MediumDelay();
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
           
                WinApi.SetForegroundWindow(hWnd);
                automate.MediumDelay();

                // At this point the Autoline library form should be displayed and we need to select "Kerridge mode" to break into code
                // Get the handle of the Kerridge mode button
                int hKerridgeModeButton = Automate.ControlGetHandle(hWnd, "KCMLButton_32", 5);
                if (hKerridgeModeButton == 0)
                {
                    WinApi.SetForegroundWindow(hWndMain);
                    MessageBox.Show("Kerridge mode button not found");
                    break;
                }
                automate.ShortDelay();
                Automate.ControlClick(hKerridgeModeButton);

                // Enter the daily password got from the password form
                int hPasswordCtrl = Automate.ControlGetHandle(hWnd, "KCMLEdit32", 1);
                if (hPasswordCtrl == 0)
                {
                    WinApi.SetForegroundWindow(hWndMain);
                    MessageBox.Show("Password control not found");
                    break;
                }
                automate.ShortDelay();
                SendKeys.Send(password + "{ENTER}");

                automate.MediumDelay();

                SendKeys.Send("{TAB}");

                automate.MediumDelay();

                SendKeys.Send("CLEARP{ENTER}");

                automate.MediumDelay();

                SendKeys.Send("LOAD \"GB/MKMOD\"{ENTER}");      // This if for loading the make modules program

                automate.MediumDelay();

                SendKeys.Send("TRAP 'ExecuteScript{ENTER}");    // This is to stop the execution right after the module build sript has been created and before it's executed

                automate.MediumDelay();

                SendKeys.Send("RUN{ENTER}");

                automate.LongDelay();

                // At this point the Make Modules form will be displayed, now we need to press the Build button

                // Wait for the next form
                hWnd = Automate.WinWait("KCMLMasterForm_32", "", Automate.WinMatchMode.Start, 5);
                if (hWnd == 0)
                {
                    WinApi.SetForegroundWindow(hWndMain);
                    MessageBox.Show("Build modules form not found");
                    break;
                }

                // Click on the button to build
                int hCtrlBuild = Automate.ControlGetHandle(hWnd, "KCMLButton_32", 2);
                if (hCtrlBuild == 0)
                {
                    WinApi.SetForegroundWindow(hWndMain);
                    MessageBox.Show("Build button not found");
                    break;
                }
                automate.MediumDelay();
                Automate.ControlClick(hCtrlBuild);

                // The build modules process will start, now we need to wait for it to reach the trap
                // as this process can take very variable amounts of time to complete it requires it's own delay time
                automate.CustomDelay();

                SendKeys.Send("{TAB}");
                automate.MediumDelay();

                // Capture the module build script name by writing it into a known file name that we can get through FTP
                automate.Send(
                    Automate.ConvertKeys("stream = OPEN $PRINTF(\"%s/%s\", ENV(\"WORKSPACE\"), \"ScriptFileName.txt\"), \"w\"")
                    +"{ENTER}");
                automate.Send(
                    Automate.ConvertKeys("pointer = WRITE #stream, ScriptName$")
                    + "{ENTER}");

                // Get the file through FTP
                // Get the object used to communicate with the server.
                FtpWebRequest requestFile = (FtpWebRequest)WebRequest.Create(
                    //"ftp://" + connection.Host + "/%2f" + connection.Home.Substring(1).Replace("home", "work") + "/ScriptFileName.txt");
                    "ftp://" + connection.Host + "/%2f" + ReplaceLastOccurrence(connection.Home.Substring(1), "home", "work") + "/ScriptFileName.txt");
                requestFile.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                requestFile.Credentials = new NetworkCredential(connection.User, connection.Password);
                FtpWebResponse responseFile = (FtpWebResponse)requestFile.GetResponse();
                // Get the file from the response 
                Stream responseStreamFile = responseFile.GetResponseStream();
                StreamReader readerFile = new StreamReader(responseStreamFile);

                string line = readerFile.ReadLine();
                if (line != null)
                {
                    string test = line.Substring(1);
                    StringCollection result2 = new StringCollection();

                    FtpWebRequest requestFile2 = (FtpWebRequest)WebRequest.Create("ftp://" + connection.Host + "/%2f" + line.Substring(1));
                    requestFile2.Method = WebRequestMethods.Ftp.DownloadFile;

                    // This example assumes the FTP site uses anonymous logon.
                    requestFile2.Credentials = new NetworkCredential(connection.User, connection.Password);
                    FtpWebResponse responseFile2 = (FtpWebResponse)requestFile2.GetResponse();

                    Stream responseStreamFile2 = responseFile2.GetResponseStream();
                    StreamReader readerFile2 = new StreamReader(responseStreamFile2);

                    line = readerFile2.ReadLine();
                    while (line != null)
                    {
                        result2.Add(line);
                        line = readerFile2.ReadLine();
                    }

                    readerFile2.Close();

                    int firstIndex = result2.IndexOf("CLEAR P");
                    int lastIndex = 0;

                    foreach (string s in result2)
                    {
                        if (s.Contains("SAVE <G>"))
                            lastIndex = result2.IndexOf(s);
                    }

                    for (int index = firstIndex; index <= lastIndex; index++)
                    {
                        string lineCommand = result2[index];

                        // We now have each command ready to send to the console
                        automate.Send(lineCommand + "{ENTER}");

                        automate.LongDelay();
                    }
                }

                readerFile.Close();

                //SendKeys.Send("$END");
            } while (false);
        }
    }
}
