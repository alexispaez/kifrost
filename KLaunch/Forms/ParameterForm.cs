using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KLaunch
{
    public partial class ParameterForm : Form
    {
        public ParameterForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            // Save the parameters here
            SaveParameters();
        }

        public static implicit operator ParameterForm(PasswordForm v)
        {
            throw new NotImplementedException();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void ParameterForm_Load(object sender, EventArgs e)
        {
            int value;
            int.TryParse(ConfigurationManager.AppSettings["ShortDelay"], out value);
            numericUpDownShort.Value = value;
            int.TryParse(ConfigurationManager.AppSettings["MediumDelay"], out value);
            numericUpDownMedium.Value = value;
            int.TryParse(ConfigurationManager.AppSettings["LongDelay"], out value);
            numericUpDownLong.Value = value;
            int.TryParse(ConfigurationManager.AppSettings["SpeedModifier"], out value);
            trackBarSpeedModifier.Value = value;
            int.TryParse(ConfigurationManager.AppSettings["ModuleBuildDelay"], out value);
            numericUpDownModule.Value = value;

            textBoxConnections.Text = ConfigurationManager.AppSettings["ConnectionsFileName"];

            checkBoxMinimizeOnLaunch.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeOnLaunch"]);
            checkBoxMinimizeToNotification.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeToNotificationArea"]);

            checkBoxMinimizeToNotification.Enabled = checkBoxMinimizeOnLaunch.Checked;
        }

        private void buttonConnections_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new System.Windows.Forms.OpenFileDialog();
            DialogResult result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxConnections.Text = fd.FileName;
            }
        }

        private void checkBoxMinimizeOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
                checkBoxMinimizeToNotification.Enabled = true;
            else
                checkBoxMinimizeToNotification.Enabled = false;
        }

        void SaveParameters()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["ShortDelay"].Value != numericUpDownShort.Value.ToString())
                config.AppSettings.Settings["ShortDelay"].Value = numericUpDownShort.Value.ToString();

            if (config.AppSettings.Settings["MediumDelay"].Value != numericUpDownMedium.Value.ToString())
                config.AppSettings.Settings["MediumDelay"].Value = numericUpDownMedium.Value.ToString();

            if (config.AppSettings.Settings["LongDelay"].Value != numericUpDownLong.Value.ToString())
                config.AppSettings.Settings["LongDelay"].Value = numericUpDownLong.Value.ToString();

            if (config.AppSettings.Settings["SpeedModifier"].Value != trackBarSpeedModifier.Value.ToString())
                config.AppSettings.Settings["SpeedModifier"].Value = trackBarSpeedModifier.Value.ToString();

            if (config.AppSettings.Settings["ModuleBuildDelay"].Value != numericUpDownModule.Value.ToString())
                config.AppSettings.Settings["ModuleBuildDelay"].Value = numericUpDownModule.Value.ToString();

            if (config.AppSettings.Settings["ConnectionsFileName"].Value != textBoxConnections.Text)
                config.AppSettings.Settings["ConnectionsFileName"].Value = textBoxConnections.Text;

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeOnLaunch"]) != checkBoxMinimizeOnLaunch.Checked)
                config.AppSettings.Settings["MinimizeOnLaunch"].Value = (checkBoxMinimizeOnLaunch.Checked == true ? "true" : "false");

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeToNotificationArea"]) != checkBoxMinimizeToNotification.Checked)
                config.AppSettings.Settings["MinimizeToNotificationArea"].Value = (checkBoxMinimizeToNotification.Checked == true ? "true" : "false");

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
