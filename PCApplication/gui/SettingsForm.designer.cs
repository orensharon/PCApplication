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
            this.LogsTabContainer = new System.Windows.Forms.TabPage();
            this.ConnectionTabContainer_StatusGroupBox = new System.Windows.Forms.GroupBox();
            this.LogsTabContainer_StatusGroupBox_txtSystemLog = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.GeneralTabContainer.SuspendLayout();
            this.GeneralTabContainer_RoutingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon)).BeginInit();
            this.GeneralTabContainer_AccountGroupBox.SuspendLayout();
            this.LogsTabContainer.SuspendLayout();
            this.ConnectionTabContainer_StatusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GeneralTabContainer);
            this.MainTabControl.Controls.Add(this.LogsTabContainer);
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
            // LogsTabContainer
            // 
            this.LogsTabContainer.Controls.Add(this.ConnectionTabContainer_StatusGroupBox);
            this.LogsTabContainer.Location = new System.Drawing.Point(4, 22);
            this.LogsTabContainer.Name = "LogsTabContainer";
            this.LogsTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.LogsTabContainer.Size = new System.Drawing.Size(375, 383);
            this.LogsTabContainer.TabIndex = 3;
            this.LogsTabContainer.Text = "Logs";
            this.LogsTabContainer.UseVisualStyleBackColor = true;
            // 
            // ConnectionTabContainer_StatusGroupBox
            // 
            this.ConnectionTabContainer_StatusGroupBox.Controls.Add(this.LogsTabContainer_StatusGroupBox_txtSystemLog);
            this.ConnectionTabContainer_StatusGroupBox.Location = new System.Drawing.Point(6, 20);
            this.ConnectionTabContainer_StatusGroupBox.Name = "ConnectionTabContainer_StatusGroupBox";
            this.ConnectionTabContainer_StatusGroupBox.Size = new System.Drawing.Size(360, 357);
            this.ConnectionTabContainer_StatusGroupBox.TabIndex = 2;
            this.ConnectionTabContainer_StatusGroupBox.TabStop = false;
            this.ConnectionTabContainer_StatusGroupBox.Text = "System status";
            // 
            // LogsTabContainer_StatusGroupBox_txtSystemLog
            // 
            this.LogsTabContainer_StatusGroupBox_txtSystemLog.BackColor = System.Drawing.SystemColors.Window;
            this.LogsTabContainer_StatusGroupBox_txtSystemLog.Location = new System.Drawing.Point(6, 20);
            this.LogsTabContainer_StatusGroupBox_txtSystemLog.Multiline = true;
            this.LogsTabContainer_StatusGroupBox_txtSystemLog.Name = "LogsTabContainer_StatusGroupBox_txtSystemLog";
            this.LogsTabContainer_StatusGroupBox_txtSystemLog.ReadOnly = true;
            this.LogsTabContainer_StatusGroupBox_txtSystemLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogsTabContainer_StatusGroupBox_txtSystemLog.Size = new System.Drawing.Size(348, 322);
            this.LogsTabContainer_StatusGroupBox_txtSystemLog.TabIndex = 0;
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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 463);
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
            this.LogsTabContainer.ResumeLayout(false);
            this.ConnectionTabContainer_StatusGroupBox.ResumeLayout(false);
            this.ConnectionTabContainer_StatusGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GeneralTabContainer;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TabPage LogsTabContainer;
        private System.Windows.Forms.GroupBox GeneralTabContainer_AccountGroupBox;
        private System.Windows.Forms.Button GeneralTabContainer_AccountGroupBox_LoginButton;
        private System.Windows.Forms.TextBox GeneralTabContainer_AccountGroupBox_PasswordTextBox;
        private System.Windows.Forms.TextBox GeneralTabContainer_AccountGroupBox_UsernameTextBox;
        private System.Windows.Forms.Label GeneralTabContainer_AccountGroupBox_PasswordLabel;
        private System.Windows.Forms.Label GeneralTabContainer_AccountGroupBox_UsernameLabel;
        private System.Windows.Forms.GroupBox GeneralTabContainer_RoutingGroupBox;
        private System.Windows.Forms.TextBox GeneralTabContainer_ConnectionGroupBox_IPTextBox;
        private System.Windows.Forms.Label GeneralTabContainer_ConnectionGroupBox_IPLabel;
        private System.Windows.Forms.PictureBox GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon;
        private System.Windows.Forms.Label GeneralTabContainer_ConnectionGroupBox_ConnectionStatusLabel;
        private System.Windows.Forms.Label GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel;
        private System.Windows.Forms.GroupBox ConnectionTabContainer_StatusGroupBox;
        private System.Windows.Forms.TextBox LogsTabContainer_StatusGroupBox_txtSystemLog;
    }
}