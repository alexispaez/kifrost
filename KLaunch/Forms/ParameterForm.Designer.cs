namespace KLaunch
{
    partial class ParameterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSaveRec = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxScriptParameters = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownModule = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownLong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMedium = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownShort = new System.Windows.Forms.NumericUpDown();
            this.trackBarSpeedModifier = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxMinimizeToNotification = new System.Windows.Forms.CheckBox();
            this.checkBoxMinimizeOnLaunch = new System.Windows.Forms.CheckBox();
            this.buttonConnections = new System.Windows.Forms.Button();
            this.textBoxConnections = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxScriptParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeedModifier)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSaveRec.Location = new System.Drawing.Point(490, 209);
            this.buttonSaveRec.Name = "buttonSaveRec";
            this.buttonSaveRec.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveRec.TabIndex = 3;
            this.buttonSaveRec.Text = "Save";
            this.buttonSaveRec.UseVisualStyleBackColor = true;
            this.buttonSaveRec.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sorry! This form is under construction!";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(571, 209);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxScriptParameters
            // 
            this.groupBoxScriptParameters.Controls.Add(this.label6);
            this.groupBoxScriptParameters.Controls.Add(this.numericUpDownModule);
            this.groupBoxScriptParameters.Controls.Add(this.label5);
            this.groupBoxScriptParameters.Controls.Add(this.label4);
            this.groupBoxScriptParameters.Controls.Add(this.numericUpDownLong);
            this.groupBoxScriptParameters.Controls.Add(this.label3);
            this.groupBoxScriptParameters.Controls.Add(this.numericUpDownMedium);
            this.groupBoxScriptParameters.Controls.Add(this.label2);
            this.groupBoxScriptParameters.Controls.Add(this.numericUpDownShort);
            this.groupBoxScriptParameters.Controls.Add(this.trackBarSpeedModifier);
            this.groupBoxScriptParameters.Location = new System.Drawing.Point(13, 13);
            this.groupBoxScriptParameters.Name = "groupBoxScriptParameters";
            this.groupBoxScriptParameters.Size = new System.Drawing.Size(263, 183);
            this.groupBoxScriptParameters.TabIndex = 6;
            this.groupBoxScriptParameters.TabStop = false;
            this.groupBoxScriptParameters.Text = "Script parameters";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Module build delay";
            // 
            // numericUpDownModule
            // 
            this.numericUpDownModule.Location = new System.Drawing.Point(131, 143);
            this.numericUpDownModule.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDownModule.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownModule.Name = "numericUpDownModule";
            this.numericUpDownModule.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownModule.TabIndex = 9;
            this.numericUpDownModule.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Modify delay by factor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Long delay";
            // 
            // numericUpDownLong
            // 
            this.numericUpDownLong.Location = new System.Drawing.Point(131, 72);
            this.numericUpDownLong.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownLong.Minimum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.numericUpDownLong.Name = "numericUpDownLong";
            this.numericUpDownLong.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLong.TabIndex = 6;
            this.numericUpDownLong.Value = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Medium delay";
            // 
            // numericUpDownMedium
            // 
            this.numericUpDownMedium.Location = new System.Drawing.Point(131, 46);
            this.numericUpDownMedium.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownMedium.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownMedium.Name = "numericUpDownMedium";
            this.numericUpDownMedium.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMedium.TabIndex = 4;
            this.numericUpDownMedium.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Short delay";
            // 
            // numericUpDownShort
            // 
            this.numericUpDownShort.Location = new System.Drawing.Point(131, 20);
            this.numericUpDownShort.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownShort.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownShort.Name = "numericUpDownShort";
            this.numericUpDownShort.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownShort.TabIndex = 2;
            this.numericUpDownShort.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // trackBarSpeedModifier
            // 
            this.trackBarSpeedModifier.Location = new System.Drawing.Point(131, 98);
            this.trackBarSpeedModifier.Maximum = 200;
            this.trackBarSpeedModifier.Minimum = 50;
            this.trackBarSpeedModifier.Name = "trackBarSpeedModifier";
            this.trackBarSpeedModifier.Size = new System.Drawing.Size(120, 45);
            this.trackBarSpeedModifier.TabIndex = 1;
            this.trackBarSpeedModifier.TickFrequency = 10;
            this.trackBarSpeedModifier.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSpeedModifier.Value = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxMinimizeToNotification);
            this.groupBox1.Controls.Add(this.checkBoxMinimizeOnLaunch);
            this.groupBox1.Controls.Add(this.buttonConnections);
            this.groupBox1.Controls.Add(this.textBoxConnections);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(285, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 183);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application parameters";
            // 
            // checkBoxMinimizeToNotification
            // 
            this.checkBoxMinimizeToNotification.AutoSize = true;
            this.checkBoxMinimizeToNotification.Location = new System.Drawing.Point(135, 49);
            this.checkBoxMinimizeToNotification.Name = "checkBoxMinimizeToNotification";
            this.checkBoxMinimizeToNotification.Size = new System.Drawing.Size(156, 17);
            this.checkBoxMinimizeToNotification.TabIndex = 5;
            this.checkBoxMinimizeToNotification.Text = "Minimize to notification area";
            this.checkBoxMinimizeToNotification.UseVisualStyleBackColor = true;
            // 
            // checkBoxMinimizeOnLaunch
            // 
            this.checkBoxMinimizeOnLaunch.AutoSize = true;
            this.checkBoxMinimizeOnLaunch.Location = new System.Drawing.Point(13, 49);
            this.checkBoxMinimizeOnLaunch.Name = "checkBoxMinimizeOnLaunch";
            this.checkBoxMinimizeOnLaunch.Size = new System.Drawing.Size(116, 17);
            this.checkBoxMinimizeOnLaunch.TabIndex = 4;
            this.checkBoxMinimizeOnLaunch.Text = "Minimize on launch";
            this.checkBoxMinimizeOnLaunch.UseVisualStyleBackColor = true;
            this.checkBoxMinimizeOnLaunch.CheckedChanged += new System.EventHandler(this.checkBoxMinimizeOnLaunch_CheckedChanged);
            // 
            // buttonConnections
            // 
            this.buttonConnections.Location = new System.Drawing.Point(284, 19);
            this.buttonConnections.Name = "buttonConnections";
            this.buttonConnections.Size = new System.Drawing.Size(71, 19);
            this.buttonConnections.TabIndex = 2;
            this.buttonConnections.Text = "Browse...";
            this.buttonConnections.UseVisualStyleBackColor = true;
            this.buttonConnections.Click += new System.EventHandler(this.buttonConnections_Click);
            // 
            // textBoxConnections
            // 
            this.textBoxConnections.Location = new System.Drawing.Point(98, 20);
            this.textBoxConnections.Name = "textBoxConnections";
            this.textBoxConnections.Size = new System.Drawing.Size(180, 20);
            this.textBoxConnections.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Connections file";
            // 
            // ParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 244);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxScriptParameters);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveRec);
            this.Name = "ParameterForm";
            this.Text = "KiFrost Parameters";
            this.Load += new System.EventHandler(this.ParameterForm_Load);
            this.groupBoxScriptParameters.ResumeLayout(false);
            this.groupBoxScriptParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeedModifier)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveRec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxScriptParameters;
        private System.Windows.Forms.TrackBar trackBarSpeedModifier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMedium;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownShort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownLong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownModule;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonConnections;
        private System.Windows.Forms.TextBox textBoxConnections;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxMinimizeToNotification;
        private System.Windows.Forms.CheckBox checkBoxMinimizeOnLaunch;
    }
}