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
using Microsoft.Win32;
using System.CodeDom;
using System.Net;

namespace KLaunch
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private List<KConnection> connections = new List<KConnection>();
		private List<Action> actions = new List<Action>();
		//Nacho
		private List<Action> markets = new List<Action>();
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
			this.Text = "KiFrost, a Keyloop internal tool for KCML, build number: " + version;             // Set application window title

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
				"MS 00 General_utilities Keyloop_utilities MS_file_viewer",
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
			//Nacho Load TLS Encryption
			TLSBox.Checked = (kConnection.TLSBox == "Y" && true || false);

			comboBoxActions.Items.Clear();
			comboBoxActions.Items.Add("");
			comboBoxActions.Items.AddRange(
				actions.FindAll(c => ((kConnection.CvsSystem == true && (c.CvsOnly == true || c.CvsOnly == false)
				|| (kConnection.CvsSystem == false && c.CvsOnly == false)))).ToArray());

			buttonLaunch.Enabled = true;
			menuItemLaunch.Enabled = true;
			buttonFtpClient.Enabled = true;
			buttonConManager.Enabled = true;

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
						buttonConManager.Enabled=false;
					}
					else
					{
						comboBoxDestinations.Enabled = false;
						buttonExecute.Enabled = true;
						buttonLaunch.Enabled = true;
						menuItemLaunch.Enabled = true;
						buttonFtpClient.Enabled = true;
						buttonConManager.Enabled = true;
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
				textBoxNotes.Text = textBoxNotes.Text + Environment.NewLine + Environment.NewLine + "Action: " + action.Script.GetNotes();
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
																						// Nacho TLS encryption flag
			if (TLSBox.Checked == false)
				arguments = arguments + " ";
			else
				arguments = arguments + "-l";
			// check Icon tex
			if (textIcon.Text == "")
				arguments = arguments + String.Format(" -P 1,1 ");
			else
				arguments = arguments + String.Format(" -i {0},0", textIcon.Text); // Pass the icon absolute path
																				   //arguments = arguments + String.Format(" -P 1,1 ");
																				   // Check if an action has been selected
			if (comboBoxActions.SelectedIndex != -1)
			// Check if an action has been selected
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
			panel1.Text = "Courtesy of Jose Alexis Paez Thurgood, for contact: jose.alexis.paez@keyloop.com";
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
			buttonConManager.Enabled = true;
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
			string FileZillaExec;
			string FileZillaDir;
			string FileZillaPath;

			panel1.Text = "Starting FTP client...";

			// Filezilla release 3
			FileZillaPath = "SOFTWARE\\Filezilla Client";
			RegistryKey erreka;
			if (Environment.Is64BitOperatingSystem == true)
			{
				erreka = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
			}
			else
			{
				//registryKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
				erreka = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
			}
			erreka = erreka.OpenSubKey(FileZillaPath, false);
			if (erreka is null)
			{
				// Filezilla release 2
				FileZillaPath = "SOFTWARE\\Filezilla\\Install_dir";
				erreka = erreka.OpenSubKey(FileZillaPath, false);
			}
			if (erreka is null)
			{ FileZillaDir = "C:\\Program Files (x86)\\FileZilla FTP Client\\"; }

			FileZillaDir = erreka.GetValue(null).ToString();
			erreka.Close();

			// TODO prepare parameters for sftp
			//System.Diagnostics.Process.Start("C:\\Program Files (x86)\\FileZilla FTP Client\\filezilla.exe", arguments);

			FileZillaExec = FileZillaDir + "\filezilla.exe";

			System.Diagnostics.Process.Start(FileZillaExec, arguments);
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

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void textBoxPassword_TextChanged(object sender, EventArgs e)
		{

		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

		}

		private void labelNotes_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void comboBoxMarket_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		private void PatchInfo_click(object sender, EventArgs e)
		{
			string HomeDir = "$HOMEDIR=";
			string sIPa = "$IP=";
			string sLogin = "$LOGIN=";
			string sPwd = "$PASSWORD=";
			string sPatchInfoc;
			sPatchInfoc = "PATCHINFO:   " + HomeDir + textBoxHome.Text + "    " + sIPa + textBoxHost + "    " + sLogin + textBoxUser.Text + "    " + sPwd + textBoxPassword.Text;

			panel1.Text = "Copiando información de parcheo al portapapeles";
			Clipboard.SetData(DataFormats.Text, sPatchInfoc);
			// Copied to clipboard
			label4.Text = "Patch Information copied to clipboard.";
			textBoxNotes.Text = sPatchInfoc;
		}

		private void ConManager_Click(object sender, EventArgs e)
		{
			//Open Host:port so that Connection Manager is triggered		
			string sURL = "https://" + textBoxHost.Text + ":" + textBoxPort.Text;
			System.Diagnostics.Process.Start(sURL);
		}

		private void buttonPatchMS_Click(object sender, EventArgs e)
		{
			string messageBoxText = "Se abrirá un fichero que deberá rellenar con los productos MS o CS requeridos.";
			string sFrom = "MSProductList.xml";
			string sDestTo;
			int itries=0;
			string sLine;
			string sequence;
			string SubModule;
			string xmlLine;
			string xmlFile;
									
			MessageBox.Show(messageBoxText);
			System.Diagnostics.Process.Start(@"ListMS.csv").WaitForExit();

			//Convert this file into an XML
			FileStream objWrite = null;
			xmlFile = connectionsFilePath + sFrom;
			objWrite = new FileStream(xmlFile, FileMode.Open);

			StreamReader sr = new StreamReader(@"ListMS.csv");
			sr.ReadLine();
			while ((sLine = sr.ReadLine()) != null)
			{
				string[] MSProducts = sLine.Split(',');
				//MSProducts[0] ==> Module
				//MSProducts[1] ==> Product
				//MSProducts[2] ==> Branch
				//MSProducts[3] ==> Release
				itries = itries + 1;
				sequence = itries.ToString();
				SubModule = MSProducts[1].Substring(0, 2);
				xmlLine = "<Install Module=\"" + MSProducts[0] + "\"";
				xmlLine = xmlLine + "ProductID=\"" + MSProducts[1] + "\"";
				xmlLine = xmlLine + "Sequence=\"" + sequence + "\"";
				xmlLine = xmlLine + "SubModule=\"" + SubModule + "\"";
				xmlLine = xmlLine + "VersionMajor=\"" + MSProducts[2] + "\"";
				xmlLine = xmlLine + "VersionMinor=\"" + MSProducts[3] + "\"";
				xmlLine = xmlLine + "/>";
				using (StreamWriter src = new StreamWriter(objWrite))
				{
					src.WriteLine(xmlLine);
				}
				if (objWrite != null)
					objWrite.Dispose();
			}
			sr.Close();
			//End - create an file that will be an XML

			// Upload this XML file
			sDestTo = "ftp://" + textBoxHost.Text + textBoxHome.Text + "/" + sFrom;
			using (WebClient client = new WebClient())
				{
					client.Credentials = new NetworkCredential(textBoxUser.Text, textBoxPassword.Text);
					client.UploadFile(sDestTo, WebRequestMethods.Ftp.UploadFile, sFrom);
				}
			//Now let's remove the local xml file
			File.Delete(xmlFile);
		}

		private void buttonSaveRec_Click(object sender, EventArgs e)
		{
			string sTempString;
			int parenthPos;
			string sCountry;
			string sSysName;
			string NewRec;
			string sCVS = "N";
			string sTLS = "N";
			FileStream objWrite=null;
			objWrite  = new FileStream(connectionsFilePath, FileMode.Append);

			sTempString = comboBoxConnections.Items[comboBoxConnections.SelectedIndex].ToString();
			if (sTempString.Contains("("))
			{
				parenthPos = sTempString.IndexOf("(");
			}
			else
			{
				parenthPos = 20;
			}
			if (checkBoxCvsOnly.Checked == true)
			{
				sCVS = "Y";
			}
			if (TLSBox.Checked == true)
				{
				sTLS = "Y";
				}
			sCountry = sTempString.Substring(0, 2);
			sSysName = sTempString.Substring(4, parenthPos);
			NewRec = sCountry + ";" + sSysName + ";" + textBoxPath.Text + ";"
				+ textBoxHost.Text + ";" + textBoxService + ";" + textBoxPort.Text + ";"
				+ textBoxUser.Text + ";" + textBoxPassword.Text + ";" + textBoxHome.Text + ";"
				+ sCVS + " ;" //CVS system
				+ " ;" //Notes not for the moment
				+ textIcon.Text
				+ sTLS + " ;" //TLS encrypt
				;
			using (StreamWriter src = new StreamWriter(objWrite))
			{
				src.WriteLine(NewRec);
			}
			//src.close()
			if (objWrite != null)
				objWrite.Dispose();
		}
	}
}
