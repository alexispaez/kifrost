/*
 * Created by SharpDevelop.
 * User: paezj
 * Date: 15/07/2018
 * Time: 19:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace KLaunch
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.textIcon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericSessions = new System.Windows.Forms.NumericUpDown();
            this.buttonEditParameters = new System.Windows.Forms.Button();
            this.buttonFtpClient = new System.Windows.Forms.Button();
            this.buttonReloadConnectionList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHome = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.checkBoxCvsOnly = new System.Windows.Forms.CheckBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.comboBoxDestinations = new System.Windows.Forms.ComboBox();
            this.labelConnection = new System.Windows.Forms.Label();
            this.labelAction = new System.Windows.Forms.Label();
            this.comboBoxActions = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelService = new System.Windows.Forms.Label();
            this.textBoxService = new System.Windows.Forms.TextBox();
            this.labelHost = new System.Windows.Forms.Label();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.comboBoxConnections = new System.Windows.Forms.ComboBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSessions)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 339);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.textIcon);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.numericSessions);
            this.tabPage1.Controls.Add(this.buttonEditParameters);
            this.tabPage1.Controls.Add(this.buttonFtpClient);
            this.tabPage1.Controls.Add(this.buttonReloadConnectionList);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxHome);
            this.tabPage1.Controls.Add(this.labelNotes);
            this.tabPage1.Controls.Add(this.textBoxNotes);
            this.tabPage1.Controls.Add(this.checkBoxCvsOnly);
            this.tabPage1.Controls.Add(this.buttonExecute);
            this.tabPage1.Controls.Add(this.labelPassword);
            this.tabPage1.Controls.Add(this.textBoxPassword);
            this.tabPage1.Controls.Add(this.labelDestination);
            this.tabPage1.Controls.Add(this.comboBoxDestinations);
            this.tabPage1.Controls.Add(this.labelConnection);
            this.tabPage1.Controls.Add(this.labelAction);
            this.tabPage1.Controls.Add(this.comboBoxActions);
            this.tabPage1.Controls.Add(this.labelUser);
            this.tabPage1.Controls.Add(this.textBoxUser);
            this.tabPage1.Controls.Add(this.labelPort);
            this.tabPage1.Controls.Add(this.textBoxPort);
            this.tabPage1.Controls.Add(this.labelService);
            this.tabPage1.Controls.Add(this.textBoxService);
            this.tabPage1.Controls.Add(this.labelHost);
            this.tabPage1.Controls.Add(this.textBoxHost);
            this.tabPage1.Controls.Add(this.labelPath);
            this.tabPage1.Controls.Add(this.comboBoxConnections);
            this.tabPage1.Controls.Add(this.textBoxPath);
            this.tabPage1.Controls.Add(this.buttonExit);
            this.tabPage1.Controls.Add(this.buttonLaunch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Packs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "Save Connection";
            this.button2.AccessibleName = "SaveConnection";
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(325, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Save Connection";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textIcon
            // 
            this.textIcon.AccessibleDescription = "textIcon";
            this.textIcon.AccessibleName = "textIcon";
            this.textIcon.Location = new System.Drawing.Point(80, 273);
            this.textIcon.Name = "textIcon";
            this.textIcon.Size = new System.Drawing.Size(238, 20);
            this.textIcon.TabIndex = 33;
            this.textIcon.TextChanged += new System.EventHandler(this.textIcon_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Icon:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // numericSessions
            // 
            this.numericSessions.Location = new System.Drawing.Point(434, 8);
            this.numericSessions.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericSessions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSessions.Name = "numericSessions";
            this.numericSessions.Size = new System.Drawing.Size(31, 20);
            this.numericSessions.TabIndex = 30;
            this.numericSessions.Tag = "";
            this.numericSessions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonEditParameters
            // 
            this.buttonEditParameters.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditParameters.Image")));
            this.buttonEditParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditParameters.Location = new System.Drawing.Point(324, 89);
            this.buttonEditParameters.Name = "buttonEditParameters";
            this.buttonEditParameters.Size = new System.Drawing.Size(141, 23);
            this.buttonEditParameters.TabIndex = 29;
            this.buttonEditParameters.Text = "Edit parameters...";
            this.buttonEditParameters.UseVisualStyleBackColor = true;
            this.buttonEditParameters.Click += new System.EventHandler(this.buttonEditParameters_Click);
            // 
            // buttonFtpClient
            // 
            this.buttonFtpClient.Enabled = false;
            this.buttonFtpClient.Image = ((System.Drawing.Image)(resources.GetObject("buttonFtpClient.Image")));
            this.buttonFtpClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFtpClient.Location = new System.Drawing.Point(472, 60);
            this.buttonFtpClient.Name = "buttonFtpClient";
            this.buttonFtpClient.Size = new System.Drawing.Size(125, 23);
            this.buttonFtpClient.TabIndex = 28;
            this.buttonFtpClient.Text = "Start FTP client...";
            this.buttonFtpClient.UseVisualStyleBackColor = true;
            this.buttonFtpClient.Click += new System.EventHandler(this.buttonFtpClient_Click);
            // 
            // buttonReloadConnectionList
            // 
            this.buttonReloadConnectionList.Image = ((System.Drawing.Image)(resources.GetObject("buttonReloadConnectionList.Image")));
            this.buttonReloadConnectionList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReloadConnectionList.Location = new System.Drawing.Point(325, 60);
            this.buttonReloadConnectionList.Name = "buttonReloadConnectionList";
            this.buttonReloadConnectionList.Size = new System.Drawing.Size(141, 23);
            this.buttonReloadConnectionList.TabIndex = 24;
            this.buttonReloadConnectionList.Text = "Reload list";
            this.buttonReloadConnectionList.UseVisualStyleBackColor = true;
            this.buttonReloadConnectionList.Click += new System.EventHandler(this.buttonReloadConnectionList_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(325, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Edit list...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Home:";
            // 
            // textBoxHome
            // 
            this.textBoxHome.Location = new System.Drawing.Point(80, 190);
            this.textBoxHome.Name = "textBoxHome";
            this.textBoxHome.Size = new System.Drawing.Size(238, 20);
            this.textBoxHome.TabIndex = 16;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(328, 145);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(83, 13);
            this.labelNotes.TabIndex = 26;
            this.labelNotes.Text = "Important notes:";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(331, 167);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.Size = new System.Drawing.Size(266, 97);
            this.textBoxNotes.TabIndex = 27;
            // 
            // checkBoxCvsOnly
            // 
            this.checkBoxCvsOnly.AutoSize = true;
            this.checkBoxCvsOnly.Location = new System.Drawing.Point(324, 10);
            this.checkBoxCvsOnly.Name = "checkBoxCvsOnly";
            this.checkBoxCvsOnly.Size = new System.Drawing.Size(69, 17);
            this.checkBoxCvsOnly.TabIndex = 2;
            this.checkBoxCvsOnly.Text = "CVS only";
            this.checkBoxCvsOnly.UseVisualStyleBackColor = true;
            this.checkBoxCvsOnly.CheckedChanged += new System.EventHandler(this.checkBoxCvsOnly_CheckedChanged_1);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Enabled = false;
            this.buttonExecute.Image = ((System.Drawing.Image)(resources.GetObject("buttonExecute.Image")));
            this.buttonExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExecute.Location = new System.Drawing.Point(473, 33);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(125, 23);
            this.buttonExecute.TabIndex = 23;
            this.buttonExecute.Text = "Execute script...";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(15, 167);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 13;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(80, 164);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(238, 20);
            this.textBoxPassword.TabIndex = 14;
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(7, 245);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(63, 13);
            this.labelDestination.TabIndex = 19;
            this.labelDestination.Text = "Destination:";
            // 
            // comboBoxDestinations
            // 
            this.comboBoxDestinations.FormattingEnabled = true;
            this.comboBoxDestinations.Location = new System.Drawing.Point(80, 243);
            this.comboBoxDestinations.Name = "comboBoxDestinations";
            this.comboBoxDestinations.Size = new System.Drawing.Size(238, 21);
            this.comboBoxDestinations.TabIndex = 20;
            this.comboBoxDestinations.SelectedIndexChanged += new System.EventHandler(this.comboBoxDestinations_SelectedIndexChanged);
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.Location = new System.Drawing.Point(7, 11);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(64, 13);
            this.labelConnection.TabIndex = 0;
            this.labelConnection.Text = "Connection:";
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Location = new System.Drawing.Point(31, 219);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(40, 13);
            this.labelAction.TabIndex = 17;
            this.labelAction.Text = "Action:";
            // 
            // comboBoxActions
            // 
            this.comboBoxActions.FormattingEnabled = true;
            this.comboBoxActions.Location = new System.Drawing.Point(80, 216);
            this.comboBoxActions.Name = "comboBoxActions";
            this.comboBoxActions.Size = new System.Drawing.Size(238, 21);
            this.comboBoxActions.TabIndex = 18;
            this.comboBoxActions.SelectedIndexChanged += new System.EventHandler(this.comboBoxAction_SelectedIndexChanged);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(39, 141);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(32, 13);
            this.labelUser.TabIndex = 11;
            this.labelUser.Text = "User:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(80, 138);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(238, 20);
            this.textBoxUser.TabIndex = 12;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(42, 115);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 9;
            this.labelPort.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(80, 112);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(238, 20);
            this.textBoxPort.TabIndex = 10;
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Location = new System.Drawing.Point(25, 89);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(46, 13);
            this.labelService.TabIndex = 7;
            this.labelService.Text = "Service:";
            // 
            // textBoxService
            // 
            this.textBoxService.Location = new System.Drawing.Point(80, 86);
            this.textBoxService.Name = "textBoxService";
            this.textBoxService.Size = new System.Drawing.Size(238, 20);
            this.textBoxService.TabIndex = 8;
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(39, 63);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(32, 13);
            this.labelHost.TabIndex = 5;
            this.labelHost.Text = "Host:";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(80, 60);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(238, 20);
            this.textBoxHost.TabIndex = 6;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(39, 37);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 13);
            this.labelPath.TabIndex = 3;
            this.labelPath.Text = "Path:";
            // 
            // comboBoxConnections
            // 
            this.comboBoxConnections.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxConnections.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxConnections.FormattingEnabled = true;
            this.comboBoxConnections.Location = new System.Drawing.Point(80, 7);
            this.comboBoxConnections.Name = "comboBoxConnections";
            this.comboBoxConnections.Size = new System.Drawing.Size(238, 21);
            this.comboBoxConnections.TabIndex = 1;
            this.comboBoxConnections.SelectedIndexChanged += new System.EventHandler(this.comboBoxConnections_SelectedIndexChanged);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(80, 34);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(238, 20);
            this.textBoxPath.TabIndex = 4;
            // 
            // buttonExit
            // 
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonExit.Location = new System.Drawing.Point(472, 89);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(125, 23);
            this.buttonExit.TabIndex = 25;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExitClick);
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Enabled = false;
            this.buttonLaunch.Location = new System.Drawing.Point(472, 7);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(125, 23);
            this.buttonLaunch.TabIndex = 21;
            this.buttonLaunch.Text = "Launch && execute...";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Projects";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "TODO: KCML development projects";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "KiFrost";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.ImageLocation = "MainLogo.jpg";
            this.pictureBoxLogo.Location = new System.Drawing.Point(2, 364);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(609, 151);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 520);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSessions)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.CheckBox checkBoxCvsOnly;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.ComboBox comboBoxDestinations;
        private System.Windows.Forms.Label labelConnection;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.ComboBox comboBoxActions;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.TextBox textBoxService;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.ComboBox comboBoxConnections;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonReloadConnectionList;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button buttonFtpClient;
        private System.Windows.Forms.Button buttonEditParameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericSessions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textIcon; //Nacho
        private System.Windows.Forms.Button button2;
    }
}
