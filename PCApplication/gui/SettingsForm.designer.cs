﻿namespace PCApplication
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabContainer = new System.Windows.Forms.TabPage();
            this.GeneralTabContainer_RoutingGroupBox = new System.Windows.Forms.GroupBox();
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel = new System.Windows.Forms.Label();
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon = new System.Windows.Forms.PictureBox();
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.GeneralTabContainer_ConnectionGroupBox_IPTextBox = new System.Windows.Forms.TextBox();
            this.GeneralTabContainer_ConnectionGroupBox_IPLabel = new System.Windows.Forms.Label();
            this.GeneralTabContainer_AccountGroupBox = new System.Windows.Forms.GroupBox();
            this.GeneralTabContainer_AccountGroupBox_LoginButton = new System.Windows.Forms.Button();
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox = new System.Windows.Forms.TextBox();
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox = new System.Windows.Forms.TextBox();
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel = new System.Windows.Forms.Label();
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel = new System.Windows.Forms.Label();
            this.GalleryTabContainer = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MediaTabContainer = new System.Windows.Forms.TabPage();
            this.LogsTabContainer = new System.Windows.Forms.TabPage();
            this.ConnectionTabContainer = new System.Windows.Forms.TabPage();
            this.ConnectionTabContainer_StatusGroupBox = new System.Windows.Forms.GroupBox();
            this.ConnectionTabContainer_StatusGroupBox_lblStatusValue = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.MainTabControl.SuspendLayout();
            this.GeneralTabContainer.SuspendLayout();
            this.GeneralTabContainer_RoutingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon)).BeginInit();
            this.GeneralTabContainer_AccountGroupBox.SuspendLayout();
            this.GalleryTabContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MediaTabContainer.SuspendLayout();
            this.ConnectionTabContainer.SuspendLayout();
            this.ConnectionTabContainer_StatusGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GeneralTabContainer);
            this.MainTabControl.Controls.Add(this.GalleryTabContainer);
            this.MainTabControl.Controls.Add(this.MediaTabContainer);
            this.MainTabControl.Controls.Add(this.LogsTabContainer);
            this.MainTabControl.Controls.Add(this.ConnectionTabContainer);
            this.MainTabControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(383, 409);
            this.MainTabControl.TabIndex = 0;
            // 
            // GeneralTabContainer
            // 
            this.GeneralTabContainer.Controls.Add(this.GeneralTabContainer_RoutingGroupBox);
            this.GeneralTabContainer.Controls.Add(this.GeneralTabContainer_AccountGroupBox);
            this.GeneralTabContainer.Location = new System.Drawing.Point(4, 22);
            this.GeneralTabContainer.Name = "GeneralTabContainer";
            this.GeneralTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabContainer.Size = new System.Drawing.Size(375, 383);
            this.GeneralTabContainer.TabIndex = 0;
            this.GeneralTabContainer.Text = "General";
            this.GeneralTabContainer.UseVisualStyleBackColor = true;
            // 
            // GeneralTabContainer_RoutingGroupBox
            // 
            this.GeneralTabContainer_RoutingGroupBox.Controls.Add(this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel);
            this.GeneralTabContainer_RoutingGroupBox.Controls.Add(this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon);
            this.GeneralTabContainer_RoutingGroupBox.Controls.Add(this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel);
            this.GeneralTabContainer_RoutingGroupBox.Controls.Add(this.GeneralTabContainer_ConnectionGroupBox_IPTextBox);
            this.GeneralTabContainer_RoutingGroupBox.Controls.Add(this.GeneralTabContainer_ConnectionGroupBox_IPLabel);
            this.GeneralTabContainer_RoutingGroupBox.Location = new System.Drawing.Point(18, 177);
            this.GeneralTabContainer_RoutingGroupBox.Name = "GeneralTabContainer_RoutingGroupBox";
            this.GeneralTabContainer_RoutingGroupBox.Size = new System.Drawing.Size(341, 121);
            this.GeneralTabContainer_RoutingGroupBox.TabIndex = 4;
            this.GeneralTabContainer_RoutingGroupBox.TabStop = false;
            this.GeneralTabContainer_RoutingGroupBox.Text = "Connection";
            // 
            // GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel
            // 
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.AutoSize = true;
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.Location = new System.Drawing.Point(183, 31);
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.Name = "GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel";
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.Size = new System.Drawing.Size(54, 13);
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.TabIndex = 14;
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.Text = "OFFLINE";
            // 
            // GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon
            // 
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.Image = ((System.Drawing.Image)(resources.GetObject("GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.Image")));
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.Location = new System.Drawing.Point(156, 27);
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.Name = "GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon";
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.Size = new System.Drawing.Size(20, 20);
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.TabIndex = 13;
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.TabStop = false;
            // 
            // GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel
            // 
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel.AutoSize = true;
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel.Location = new System.Drawing.Point(34, 31);
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel.Name = "GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel";
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel.Size = new System.Drawing.Size(114, 13);
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel.TabIndex = 12;
            this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel.Text = "Connection status:";
            // 
            // GeneralTabContainer_ConnectionGroupBox_IPTextBox
            // 
            this.GeneralTabContainer_ConnectionGroupBox_IPTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.GeneralTabContainer_ConnectionGroupBox_IPTextBox.Location = new System.Drawing.Point(130, 60);
            this.GeneralTabContainer_ConnectionGroupBox_IPTextBox.Name = "GeneralTabContainer_ConnectionGroupBox_IPTextBox";
            this.GeneralTabContainer_ConnectionGroupBox_IPTextBox.ReadOnly = true;
            this.GeneralTabContainer_ConnectionGroupBox_IPTextBox.Size = new System.Drawing.Size(196, 20);
            this.GeneralTabContainer_ConnectionGroupBox_IPTextBox.TabIndex = 11;
            this.GeneralTabContainer_ConnectionGroupBox_IPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GeneralTabContainer_ConnectionGroupBox_IPLabel
            // 
            this.GeneralTabContainer_ConnectionGroupBox_IPLabel.AutoSize = true;
            this.GeneralTabContainer_ConnectionGroupBox_IPLabel.Location = new System.Drawing.Point(34, 60);
            this.GeneralTabContainer_ConnectionGroupBox_IPLabel.Name = "GeneralTabContainer_ConnectionGroupBox_IPLabel";
            this.GeneralTabContainer_ConnectionGroupBox_IPLabel.Size = new System.Drawing.Size(74, 13);
            this.GeneralTabContainer_ConnectionGroupBox_IPLabel.TabIndex = 9;
            this.GeneralTabContainer_ConnectionGroupBox_IPLabel.Text = "IP Address:";
            // 
            // GeneralTabContainer_AccountGroupBox
            // 
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_LoginButton);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_PasswordTextBox);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_UsernameTextBox);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_PasswordLabel);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_UsernameLabel);
            this.GeneralTabContainer_AccountGroupBox.Location = new System.Drawing.Point(18, 29);
            this.GeneralTabContainer_AccountGroupBox.Name = "GeneralTabContainer_AccountGroupBox";
            this.GeneralTabContainer_AccountGroupBox.Size = new System.Drawing.Size(341, 132);
            this.GeneralTabContainer_AccountGroupBox.TabIndex = 2;
            this.GeneralTabContainer_AccountGroupBox.TabStop = false;
            this.GeneralTabContainer_AccountGroupBox.Text = "Account";
            // 
            // GeneralTabContainer_AccountGroupBox_LoginButton
            // 
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Location = new System.Drawing.Point(244, 91);
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Name = "GeneralTabContainer_AccountGroupBox_LoginButton";
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Size = new System.Drawing.Size(82, 25);
            this.GeneralTabContainer_AccountGroupBox_LoginButton.TabIndex = 17;
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Text = "Start";
            this.GeneralTabContainer_AccountGroupBox_LoginButton.UseVisualStyleBackColor = true;
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Click += new System.EventHandler(this.GeneralTabContainer_AccountGroupBox_LoginButton_Click);
            // 
            // GeneralTabContainer_AccountGroupBox_PasswordTextBox
            // 
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.Location = new System.Drawing.Point(130, 58);
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.Name = "GeneralTabContainer_AccountGroupBox_PasswordTextBox";
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.Size = new System.Drawing.Size(196, 21);
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.TabIndex = 16;
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // GeneralTabContainer_AccountGroupBox_UsernameTextBox
            // 
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox.Location = new System.Drawing.Point(130, 29);
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox.Name = "GeneralTabContainer_AccountGroupBox_UsernameTextBox";
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox.Size = new System.Drawing.Size(196, 21);
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox.TabIndex = 15;
            // 
            // GeneralTabContainer_AccountGroupBox_PasswordLabel
            // 
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.AutoSize = true;
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.Location = new System.Drawing.Point(34, 61);
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.Name = "GeneralTabContainer_AccountGroupBox_PasswordLabel";
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.Size = new System.Drawing.Size(66, 13);
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.TabIndex = 14;
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.Text = "Password:";
            // 
            // GeneralTabContainer_AccountGroupBox_UsernameLabel
            // 
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.AutoSize = true;
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.Location = new System.Drawing.Point(34, 32);
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.Name = "GeneralTabContainer_AccountGroupBox_UsernameLabel";
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.Size = new System.Drawing.Size(70, 13);
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.TabIndex = 13;
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.Text = "Username:";
            // 
            // GalleryTabContainer
            // 
            this.GalleryTabContainer.Controls.Add(this.groupBox1);
            this.GalleryTabContainer.Location = new System.Drawing.Point(4, 22);
            this.GalleryTabContainer.Name = "GalleryTabContainer";
            this.GalleryTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.GalleryTabContainer.Size = new System.Drawing.Size(375, 383);
            this.GalleryTabContainer.TabIndex = 1;
            this.GalleryTabContainer.Text = "Gallery";
            this.GalleryTabContainer.UseVisualStyleBackColor = true;
            
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 209);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slideshow";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Normal",
            "Hybrid speed/quality",
            "Optimizes image quality"});
            this.comboBox2.Location = new System.Drawing.Point(158, 82);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Performance:";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.Location = new System.Drawing.Point(56, 179);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(174, 17);
            this.checkBox4.TabIndex = 25;
            this.checkBox4.Text = "Pause slideshow on hover";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Fade",
            "Slide Top",
            "Slide Right",
            "Slide Bottom",
            "Slide Left",
            "Carousel Right",
            "Carousel Left"});
            this.comboBox1.Location = new System.Drawing.Point(158, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 24;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(56, 156);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(134, 17);
            this.checkBox3.TabIndex = 23;
            this.checkBox3.Text = "Start automatically";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(56, 133);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(154, 17);
            this.checkBox2.TabIndex = 22;
            this.checkBox2.Text = "Randomize slide order";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Transition style:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "ms";
            
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(34, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Enable slideshow";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(158, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 21);
            this.textBox1.TabIndex = 16;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Interval:";
            // 
            // MediaTabContainer
            // 
            this.MediaTabContainer.Controls.Add(this.groupBox2);
            this.MediaTabContainer.Location = new System.Drawing.Point(4, 22);
            this.MediaTabContainer.Name = "MediaTabContainer";
            this.MediaTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.MediaTabContainer.Size = new System.Drawing.Size(375, 383);
            this.MediaTabContainer.TabIndex = 2;
            this.MediaTabContainer.Text = "Media";
            this.MediaTabContainer.UseVisualStyleBackColor = true;
            // 
            // LogsTabContainer
            // 
            this.LogsTabContainer.Location = new System.Drawing.Point(4, 22);
            this.LogsTabContainer.Name = "LogsTabContainer";
            this.LogsTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.LogsTabContainer.Size = new System.Drawing.Size(375, 383);
            this.LogsTabContainer.TabIndex = 3;
            this.LogsTabContainer.Text = "Logs";
            this.LogsTabContainer.UseVisualStyleBackColor = true;
            // 
            // ConnectionTabContainer
            // 
            this.ConnectionTabContainer.Controls.Add(this.ConnectionTabContainer_StatusGroupBox);
            this.ConnectionTabContainer.Location = new System.Drawing.Point(4, 22);
            this.ConnectionTabContainer.Name = "ConnectionTabContainer";
            this.ConnectionTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.ConnectionTabContainer.Size = new System.Drawing.Size(375, 383);
            this.ConnectionTabContainer.TabIndex = 6;
            this.ConnectionTabContainer.Text = "Connection";
            this.ConnectionTabContainer.UseVisualStyleBackColor = true;
            // 
            // ConnectionTabContainer_StatusGroupBox
            // 
            this.ConnectionTabContainer_StatusGroupBox.Controls.Add(this.ConnectionTabContainer_StatusGroupBox_lblStatusValue);
            this.ConnectionTabContainer_StatusGroupBox.Location = new System.Drawing.Point(17, 122);
            this.ConnectionTabContainer_StatusGroupBox.Name = "ConnectionTabContainer_StatusGroupBox";
            this.ConnectionTabContainer_StatusGroupBox.Size = new System.Drawing.Size(360, 232);
            this.ConnectionTabContainer_StatusGroupBox.TabIndex = 1;
            this.ConnectionTabContainer_StatusGroupBox.TabStop = false;
            this.ConnectionTabContainer_StatusGroupBox.Text = "System status";
            // 
            // ConnectionTabContainer_StatusGroupBox_lblStatusValue
            // 
            this.ConnectionTabContainer_StatusGroupBox_lblStatusValue.AutoSize = true;
            this.ConnectionTabContainer_StatusGroupBox_lblStatusValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ConnectionTabContainer_StatusGroupBox_lblStatusValue.Location = new System.Drawing.Point(14, 30);
            this.ConnectionTabContainer_StatusGroupBox_lblStatusValue.Name = "ConnectionTabContainer_StatusGroupBox_lblStatusValue";
            this.ConnectionTabContainer_StatusGroupBox_lblStatusValue.Size = new System.Drawing.Size(0, 14);
            this.ConnectionTabContainer_StatusGroupBox_lblStatusValue.TabIndex = 10;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(308, 427);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 29);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(215, 427);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 29);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.checkBox7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 209);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quality";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Video:";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.Location = new System.Drawing.Point(30, 153);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(174, 17);
            this.checkBox5.TabIndex = 25;
            this.checkBox5.Text = "Pause slideshow on hover";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.Location = new System.Drawing.Point(30, 130);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(134, 17);
            this.checkBox6.TabIndex = 23;
            this.checkBox6.Text = "Start automatically";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox7.Location = new System.Drawing.Point(30, 107);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(154, 17);
            this.checkBox7.TabIndex = 22;
            this.checkBox7.Text = "Randomize slide order";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Photos:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(132, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 21);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(132, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(121, 21);
            this.textBox3.TabIndex = 27;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 463);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeepItSafe";
            this.Load += new System.EventHandler(this.MainDialog_Load);
            this.MainTabControl.ResumeLayout(false);
            this.GeneralTabContainer.ResumeLayout(false);
            this.GeneralTabContainer_RoutingGroupBox.ResumeLayout(false);
            this.GeneralTabContainer_RoutingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon)).EndInit();
            this.GeneralTabContainer_AccountGroupBox.ResumeLayout(false);
            this.GeneralTabContainer_AccountGroupBox.PerformLayout();
            this.GalleryTabContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MediaTabContainer.ResumeLayout(false);
            this.ConnectionTabContainer.ResumeLayout(false);
            this.ConnectionTabContainer_StatusGroupBox.ResumeLayout(false);
            this.ConnectionTabContainer_StatusGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GeneralTabContainer;
        private System.Windows.Forms.TabPage GalleryTabContainer;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TabPage MediaTabContainer;
        private System.Windows.Forms.TabPage LogsTabContainer;
        private System.Windows.Forms.TabPage ConnectionTabContainer;
        private System.Windows.Forms.GroupBox ConnectionTabContainer_StatusGroupBox;
        private System.Windows.Forms.GroupBox GeneralTabContainer_AccountGroupBox;
        private System.Windows.Forms.Button GeneralTabContainer_AccountGroupBox_LoginButton;
        private System.Windows.Forms.TextBox GeneralTabContainer_AccountGroupBox_PasswordTextBox;
        private System.Windows.Forms.TextBox GeneralTabContainer_AccountGroupBox_UsernameTextBox;
        private System.Windows.Forms.Label GeneralTabContainer_AccountGroupBox_PasswordLabel;
        private System.Windows.Forms.Label GeneralTabContainer_AccountGroupBox_UsernameLabel;
        private System.Windows.Forms.Label ConnectionTabContainer_StatusGroupBox_lblStatusValue;
        private System.Windows.Forms.GroupBox GeneralTabContainer_RoutingGroupBox;
        private System.Windows.Forms.TextBox GeneralTabContainer_ConnectionGroupBox_IPTextBox;
        private System.Windows.Forms.Label GeneralTabContainer_ConnectionGroupBox_IPLabel;
        private System.Windows.Forms.PictureBox GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon;
        private System.Windows.Forms.Label GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel;
        private System.Windows.Forms.Label GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
    }
}