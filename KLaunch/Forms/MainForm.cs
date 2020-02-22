/*
 * Created by SharpDevelop.
 * User: paezj
 * Date: 15/07/2018
 * Time: 19:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using KLaunch.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Runtime.CompilerServices;

namespace KLaunch
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        private List<KConnection> connections = new List<KConnection>();
        private List<Action> actions = new List<Action>();
        private StatusBar statusBar;
        private StatusBarPanel panel1;
        private StatusBarPanel panel2;
        private string connectionsFilePath;
        private FileSystemWatcher watcher;
        private readonly SynchronizationContext _syncContext;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuItemLaunch;
        private System.Windows.Forms.MenuItem menuItemExit;
        private int sessionsToOpen = 0;

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            _syncContext = SynchronizationContext.Current;

            // Form setup
            CreateStatusBar();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "KiFrost, a CDK Global internal tool for KCML, build number: " + version;             // Set application window title

            //Setup context menu
            contextMenu = new System.Windows.Forms.ContextMenu();
            menuItemLaunch = new System.Windows.Forms.MenuItem();
            menuItemExit = new System.Windows.Forms.MenuItem();
            contextMenu.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[] { this.menuItemLaunch, this.menuItemExit });

            menuItemLaunch.Index = 0;
            menuItemLaunch.Text = "Launch && execute";
            menuItemLaunch.Enabled = false;
            menuItemLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);

            menuItemExit.Index = 1;
            menuItemExit.Text = "&Exit";
            menuItemExit.Enabled = true;
            menuItemExit.Click += new System.EventHandler(this.ButtonExitClick);

            notifyIcon.ContextMenu = this.contextMenu;

            int.TryParse(ConfigurationManager.AppSettings["SessionsToOpen"], out sessionsToOpen);
            numericSessions.Value = sessionsToOpen;

            // Get the connections file filename
            string connectionsFileName = ConfigurationManager.AppSettings["ConnectionsFileName"];
            // Get the application directory path
            AppDomain domain = AppDomain.CurrentDomain;
            // Compose the full connections file path
            connectionsFilePath = domain.BaseDirectory + connectionsFileName;
            LoadConnections(connectionsFilePath);

            // Add a file watcher to monitor changes to the connection config file
            watcher = new FileSystemWatcher();
            watcher.Path = domain.BaseDirectory;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = connectionsFileName;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;                 // Begin watching.

            // Add the actions to the action list
            actions.Add(new Action(
                    "Go to CVS Interface",
                    null,
                    new GoToCvsInterface(),
                    true));
            actions.Add(new Action(
                "Go to MS Release Wizard",
                "MS 00 General_utilities Development_tools Release_management_menu Release_wizard",
                null, 
                true));
            actions.Add(new Action(
                "Go to CS Release Wizard",
                "CS 00 Release_management_menu Release_wizard",
                null,
                true));
            actions.Add(new Action(
                "Go to MS Patch",
                "MS 00 General_utilities Development_tools Release_management_menu Patch_customer_site",
                new MSCSPatch(),
                true));
            actions.Add(new Action(
                "Go to CS Patch",
                "CS 00 Release_management_menu Patch_customer_site",
                new MSCSPatch(),
                true));
            actions.Add(new Action(
                "Go to MS File Viewer",
                "MS 00 General_utilities CDK_utilities MS_file_viewer",
                null,
                false));
            actions.Add(new Action(
                "Go to Customer Patch",
                null,
                new ScriptPatchCustomer(),
                true));
            actions.Add(new Action(
                "Send CTRL-BREAK",
                null,
                new SendControlBreak(),
                false));
            actions.Add(new Action(
                "Help fix a broken library",
                null,
                new FixBrokenLibrary(),
                false));
            //actions.Add(new Action(
            //    "Get file through FTP",
            //    null,
            //    new ScriptFtpFile(),
            //    false));

            comboBoxDestinations.Enabled = false;
        }

        // Define event handler for FileWatcher
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed
            // Post actions to UI thread
            _syncContext.Post(o => LoadConnections(e.FullPath), null);
        }

        private void LoadConnections(string connectionsFilePath)
        {
            // Try five times to read the connections file into the connections list
            bool readFile = false;
            int tries = 0;
            string message = "";

            while (!readFile && tries++ < 5)
                try
                {
                    Thread.Sleep(200);

                    KConnectionReader.LoadConnections(connections, connectionsFilePath);

                    comboBoxConnections.Items.Clear();
                    // Add items to the connection list dropdown
                    comboBoxConnections.Items.AddRange(
                        connections.FindAll(c => (checkBoxCvsOnly.Checked == true && c.CvsSystem == true) || (checkBoxCvsOnly.Checked == false)).ToArray());

                    readFile = true;
                } catch (Exception ex) { message = ex.Message; }

            if (!readFile)
                MessageBox.Show(String.Format("Could not read connection file:\n\n{0}", message), "Connection file error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            RefreshConnection();
        }

        private void comboBoxConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            KConnection kConnection = (KConnection)((ComboBox)sender).SelectedItem;
            SetConnectionFields(kConnection);
        }

        private void RefreshConnection()
        {
            comboBoxConnections.SelectedIndex = comboBoxConnections.FindStringExact(comboBoxConnections.Text);
        }

        private void SetConnectionFields(KConnection kConnection)
        {
            // Load the dropdown and text boxes
            textBoxPath.Text = kConnection.Path;
            textBoxHost.Text = kConnection.Host;
            textBoxService.Text = kConnection.Service;
            textBoxPort.Text = kConnection.Port;
            textBoxUser.Text = kConnection.User;
            textBoxPassword.Text = kConnection.Password;
            textBoxHome.Text = kConnection.Home;
            //Nacho Load the icon
            textIcon.Text = kConnection.IconR;

            comboBoxActions.Items.Clear();
            comboBoxActions.Items.Add("");
            comboBoxActions.Items.AddRange(
                actions.FindAll(c => ((kConnection.CvsSystem == true && (c.CvsOnly == true || c.CvsOnly == false)
                || (kConnection.CvsSystem == false && c.CvsOnly == false)))).ToArray());

            buttonLaunch.Enabled = true;
            menuItemLaunch.Enabled = true;
            buttonFtpClient.Enabled = true;

            SetNotes();
        }

        private void comboBoxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem.ToString() == "")
            {
                SetNotes();
                comboBoxDestinations.Enabled = false;
                buttonExecute.Enabled = false;
            }
            else
            {
                Action action = (Action)comboBox.SelectedItem;

                if (action.Script != null)
                {
                    SetNotes();

                    if (action.Script.TakesDestination())
                    {
                        comboBoxDestinations.Items.Clear();
                        comboBoxDestinations.Items.AddRange(connections.FindAll(x => x.CvsSystem == false).ToArray());
                        comboBoxDestinations.Text = "";
                        comboBoxDestinations.Enabled = true;
                        buttonExecute.Enabled = false;
                        buttonLaunch.Enabled = false;
                        menuItemLaunch.Enabled = false;
                    }
                    else
                    {
                        comboBoxDestinations.Enabled = false;
                        buttonExecute.Enabled = true;
                        buttonLaunch.Enabled = true;
                        menuItemLaunch.Enabled = true;
                        buttonFtpClient.Enabled = true;
                    }
                }
                else
                {
                    SetNotes();
                    buttonExecute.Enabled = false;
                    comboBoxDestinations.Enabled = false;
                }
            }
        }

        private void SetNotes()
        {
            textBoxNotes.Clear();

            KConnection kConnection = (KConnection)comboBoxConnections.SelectedItem;
            Action action = null;

            if (comboBoxActions.SelectedItem != null && !comboBoxActions.SelectedItem.ToString().Equals("")) action = (Action)comboBoxActions.SelectedItem;

            textBoxNotes.Text = "Connection: " + kConnection.GetNotes();
            if (action != null && action.Script != null)
                textBoxNotes.Text = textBoxNotes.Text + Environment.NewLine + Environment.NewLine + "Action: " +  action.Script.GetNotes();
        }

        void buttonLaunch_Click(object sender, EventArgs e)
        {
            int hActiveWindow = WinApi.GetActiveWindow();

            // Examine the user's selection and prepare a launch object for execution
            // If the action is a shortcut then add it to the arguments
            // if it is a script, prepare a script object
            Script script = null;

            string arguments = String.Format(
                "-s -h {0}:{1} -v {2} -u {3}", // -C {5} for shortcuts ;; Nacho added -s
                textBoxHost.Text,
                textBoxPort.Text,
                textBoxService.Text,
                textBoxUser.Text);

            // Check for a password in the connection data
            if (textBoxPassword.Text == "")
                arguments = arguments + " -R";  // Recall a saved password
            else
                arguments = arguments + String.Format(" -X {0}", textBoxPassword.Text); // Pass the password explicitly
            // Nacho check Icon tex
            if (textIcon.Text == "")
                arguments = arguments + String.Format(" -P 1,1 ");
                // Nacho
            else
                arguments = arguments + String.Format(" -i {0},0", textIcon.Text); // Pass the icon absolute path
                //arguments = arguments + String.Format(" -P 1,1 ");
            // Check if an action has been selected
            if (comboBoxActions.SelectedIndex != -1)
            {
                if (comboBoxActions.SelectedItem.ToString() != "")
                {
                    Action action = (Action)comboBoxActions.SelectedItem;

                    // Check for shortcuts
                    if (action.Shortcut != null)
                        arguments = arguments + String.Format(" -C {0}", action.Shortcut);

                    // Check for scripts
                    if (action.Script != null)
                        script = (Script)action.Script;
                }
            }

            // Execute the program with the given arguments 
            panel1.Text = "Launching connection...";
            try
            {
                System.Diagnostics.Process process;

                 if (script == null && numericSessions.Value > 1)
                {
                    // Launch multiple sessions if no script selected and sessions is greater than one
                    for (int iCount = 1; iCount <= numericSessions.Value; iCount++)
                    process = System.Diagnostics.Process.Start(textBoxPath.Text, arguments);
                }
                else
                    process = System.Diagnostics.Process.Start(textBoxPath.Text, arguments);

                // Minimize the window
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeOnLaunch"]) == true)
                    WindowState = FormWindowState.Minimized;

                // Execute the script if selected
                if (script != null)
                    RunScript(hActiveWindow, script, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error in connection data:\n\n{0}.\n\nPlease check the KClient path and try again.", ex.Message), "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Reset status bar message
            panel1.Text = "Select a connection...";
        }

        void ButtonExitClick(object sender, EventArgs e)
        {
            // Save settings
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["SessionsToOpen"].Value != numericSessions.Value.ToString())
                config.AppSettings.Settings["SessionsToOpen"].Value = numericSessions.Value.ToString();
            config.Save(ConfigurationSaveMode.Modified);

            // Exit app
            Application.Exit();
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            int hActiveWindow = WinApi.GetActiveWindow();
            Action action = (Action)comboBoxActions.SelectedItem;
            Script script = (Script)action.Script;

            // Execute the script
            if (script != null)
                RunScript(hActiveWindow, script, this);

        }

        private void checkBoxCvsOnly_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            comboBoxConnections.Items.Clear();
            comboBoxConnections.Items.AddRange(
                connections.FindAll(x => (checkBox.Checked == true && x.CvsSystem == true) || (checkBox.Checked == false)).ToArray());
        }

        private void RunScript(int hWnd, Script script, Form parent)
        {
            panel1.Text = "Executing script " + script.ToString();

            Automate automate = new Automate();
            script.Run(hWnd, automate, (KConnection)comboBoxConnections.SelectedItem, (KConnection)comboBoxDestinations.SelectedItem, parent);
        }

        private void CreateStatusBar()
        {
            // TODO move status bar to a separate class

            // Create a StatusBar control.
            statusBar = new StatusBar();
            // Create two StatusBarPanel objects to display in the StatusBar.
            panel1 = new StatusBarPanel();
            panel2 = new StatusBarPanel();

            // Display the first panel with a sunken border style.
            panel1.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            // Initialize the text of the panel.
            panel1.Text = "Courtesy of Jose Alexis Paez Thurgood, for contact: jose.alexis.paez@cdk.com";
            // Set the AutoSize property to use all remaining space on the StatusBar.
            panel1.AutoSize = StatusBarPanelAutoSize.Spring;

            // Display the second panel with a raised border style.
            panel2.BorderStyle = StatusBarPanelBorderStyle.Raised;

            // Create ToolTip text that displays time the application was 
            //started.
            panel2.ToolTipText = "Started: " + System.DateTime.Now.ToShortTimeString();
            // Set the text of the panel to the current date.
            panel2.Text = System.DateTime.Today.ToLongDateString();
            // Set the AutoSize property to size the panel to the size of the contents.
            panel2.AutoSize = StatusBarPanelAutoSize.Contents;

            // Display panels in the StatusBar control.
            statusBar.ShowPanels = true;

            // Add both panels to the StatusBarPanelCollection of the StatusBar.			
            statusBar.Panels.Add(panel1);
            statusBar.Panels.Add(panel2);

            // Add the StatusBar to the form.
            this.Controls.Add(statusBar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"KConnections.csv");
        }

        private void buttonReloadConnectionList_Click(object sender, EventArgs e)
        {
            LoadConnections(connectionsFilePath);
        }

        private void comboBoxDestinations_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonExecute.Enabled = true;
            buttonLaunch.Enabled = true;
            menuItemLaunch.Enabled = true;
            buttonFtpClient.Enabled = true;
        }

        private void checkBoxCvsOnly_CheckedChanged_1(object sender, EventArgs e)
        {
            LoadConnections(connectionsFilePath);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Ee.Inc();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeToNotificationArea"]) == true)
                    Hide();
                WindowState = FormWindowState.Minimized;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeToNotificationArea"]) == true)
                    Hide();
        }

        private static class Ee
        {
            private static int count = 0;
            public static void Inc()
            {
                count++;

                if (count > 30)
                {
                    MessageBox.Show("You found the easter egg!");
                    count = 0;
                }
            }
        }

        private void buttonFtpClient_Click(object sender, EventArgs e)
        {
            string arguments = "sftp://" + textBoxUser.Text + ":" + textBoxPassword.Text + "@" + textBoxHost.Text + textBoxHome.Text;

            panel1.Text = "Starting FTP client...";

            // TODO Get path from registry or parameter
            // TODO prepare parameters for sftp
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\FileZilla FTP Client\\filezilla.exe", arguments);
        }

        private void buttonEditParameters_Click(object sender, EventArgs e)
        {
            ParameterForm pf = new ParameterForm();
            pf.StartPosition = FormStartPosition.CenterParent;
            pf.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void textIcon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
