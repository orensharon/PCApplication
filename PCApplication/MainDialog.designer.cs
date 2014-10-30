namespace PCApplication
{
    partial class MainDialog
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabContainer = new System.Windows.Forms.TabPage();
            this.GeneralTabContainer_AccountGroupBox = new System.Windows.Forms.GroupBox();
            this.GeneralTabContainer_AccountGroupBox_SingUpButton = new System.Windows.Forms.Button();
            this.GeneralTabContainer_AccountGroupBox_LoginButton = new System.Windows.Forms.Button();
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox = new System.Windows.Forms.TextBox();
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox = new System.Windows.Forms.TextBox();
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel = new System.Windows.Forms.Label();
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel = new System.Windows.Forms.Label();
            this.DataTabContainer = new System.Windows.Forms.TabPage();
            this.SecurityTabContainer = new System.Windows.Forms.TabPage();
            this.LogsTabContainer = new System.Windows.Forms.TabPage();
            this.MediaTabContainer = new System.Windows.Forms.TabPage();
            this.StorageTabContainer = new System.Windows.Forms.TabPage();
            this.ConnectionTabContainer = new System.Windows.Forms.TabPage();
            this.ConnectionTabContainer_RoutingGroupBox = new System.Windows.Forms.GroupBox();
            this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton = new System.Windows.Forms.Button();
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel = new System.Windows.Forms.Label();
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel = new System.Windows.Forms.Label();
            this.ConnectionTabContainer_StatusGroupBox = new System.Windows.Forms.GroupBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.GeneralTabContainer.SuspendLayout();
            this.GeneralTabContainer_AccountGroupBox.SuspendLayout();
            this.ConnectionTabContainer.SuspendLayout();
            this.ConnectionTabContainer_RoutingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GeneralTabContainer);
            this.MainTabControl.Controls.Add(this.DataTabContainer);
            this.MainTabControl.Controls.Add(this.SecurityTabContainer);
            this.MainTabControl.Controls.Add(this.LogsTabContainer);
            this.MainTabControl.Controls.Add(this.MediaTabContainer);
            this.MainTabControl.Controls.Add(this.StorageTabContainer);
            this.MainTabControl.Controls.Add(this.ConnectionTabContainer);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(383, 409);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.HandleMainTabSelection);
            // 
            // GeneralTabContainer
            // 
            this.GeneralTabContainer.Controls.Add(this.GeneralTabContainer_AccountGroupBox);
            this.GeneralTabContainer.Location = new System.Drawing.Point(4, 22);
            this.GeneralTabContainer.Name = "GeneralTabContainer";
            this.GeneralTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabContainer.Size = new System.Drawing.Size(375, 383);
            this.GeneralTabContainer.TabIndex = 0;
            this.GeneralTabContainer.Text = "General";
            this.GeneralTabContainer.UseVisualStyleBackColor = true;
            // 
            // GeneralTabContainer_AccountGroupBox
            // 
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_SingUpButton);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_LoginButton);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_PasswordTextBox);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_UsernameTextBox);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_PasswordLabel);
            this.GeneralTabContainer_AccountGroupBox.Controls.Add(this.GeneralTabContainer_AccountGroupBox_UsernameLabel);
            this.GeneralTabContainer_AccountGroupBox.Location = new System.Drawing.Point(18, 29);
            this.GeneralTabContainer_AccountGroupBox.Name = "GeneralTabContainer_AccountGroupBox";
            this.GeneralTabContainer_AccountGroupBox.Size = new System.Drawing.Size(341, 130);
            this.GeneralTabContainer_AccountGroupBox.TabIndex = 2;
            this.GeneralTabContainer_AccountGroupBox.TabStop = false;
            this.GeneralTabContainer_AccountGroupBox.Text = "Account";
            // 
            // GeneralTabContainer_AccountGroupBox_SingUpButton
            // 
            this.GeneralTabContainer_AccountGroupBox_SingUpButton.Location = new System.Drawing.Point(162, 84);
            this.GeneralTabContainer_AccountGroupBox_SingUpButton.Name = "GeneralTabContainer_AccountGroupBox_SingUpButton";
            this.GeneralTabContainer_AccountGroupBox_SingUpButton.Size = new System.Drawing.Size(76, 25);
            this.GeneralTabContainer_AccountGroupBox_SingUpButton.TabIndex = 18;
            this.GeneralTabContainer_AccountGroupBox_SingUpButton.Text = "Sing Up";
            this.GeneralTabContainer_AccountGroupBox_SingUpButton.UseVisualStyleBackColor = true;
            // 
            // GeneralTabContainer_AccountGroupBox_LoginButton
            // 
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Location = new System.Drawing.Point(244, 84);
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Name = "GeneralTabContainer_AccountGroupBox_LoginButton";
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Size = new System.Drawing.Size(82, 25);
            this.GeneralTabContainer_AccountGroupBox_LoginButton.TabIndex = 17;
            this.GeneralTabContainer_AccountGroupBox_LoginButton.Text = "Login";
            this.GeneralTabContainer_AccountGroupBox_LoginButton.UseVisualStyleBackColor = true;
            // 
            // GeneralTabContainer_AccountGroupBox_PasswordTextBox
            // 
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.Location = new System.Drawing.Point(98, 58);
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.Name = "GeneralTabContainer_AccountGroupBox_PasswordTextBox";
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.Size = new System.Drawing.Size(228, 20);
            this.GeneralTabContainer_AccountGroupBox_PasswordTextBox.TabIndex = 16;
            // 
            // GeneralTabContainer_AccountGroupBox_UsernameTextBox
            // 
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox.Location = new System.Drawing.Point(98, 29);
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox.Name = "GeneralTabContainer_AccountGroupBox_UsernameTextBox";
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox.Size = new System.Drawing.Size(228, 20);
            this.GeneralTabContainer_AccountGroupBox_UsernameTextBox.TabIndex = 15;
            // 
            // GeneralTabContainer_AccountGroupBox_PasswordLabel
            // 
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.AutoSize = true;
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.Location = new System.Drawing.Point(34, 61);
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.Name = "GeneralTabContainer_AccountGroupBox_PasswordLabel";
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.TabIndex = 14;
            this.GeneralTabContainer_AccountGroupBox_PasswordLabel.Text = "Password:";
            // 
            // GeneralTabContainer_AccountGroupBox_UsernameLabel
            // 
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.AutoSize = true;
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.Location = new System.Drawing.Point(34, 32);
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.Name = "GeneralTabContainer_AccountGroupBox_UsernameLabel";
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.TabIndex = 13;
            this.GeneralTabContainer_AccountGroupBox_UsernameLabel.Text = "Username:";
            // 
            // DataTabContainer
            // 
            this.DataTabContainer.Location = new System.Drawing.Point(4, 22);
            this.DataTabContainer.Name = "DataTabContainer";
            this.DataTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.DataTabContainer.Size = new System.Drawing.Size(375, 383);
            this.DataTabContainer.TabIndex = 1;
            this.DataTabContainer.Text = "Data";
            this.DataTabContainer.UseVisualStyleBackColor = true;
            // 
            // SecurityTabContainer
            // 
            this.SecurityTabContainer.Location = new System.Drawing.Point(4, 22);
            this.SecurityTabContainer.Name = "SecurityTabContainer";
            this.SecurityTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.SecurityTabContainer.Size = new System.Drawing.Size(375, 383);
            this.SecurityTabContainer.TabIndex = 2;
            this.SecurityTabContainer.Text = "Security";
            this.SecurityTabContainer.UseVisualStyleBackColor = true;
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
            // MediaTabContainer
            // 
            this.MediaTabContainer.Location = new System.Drawing.Point(4, 22);
            this.MediaTabContainer.Name = "MediaTabContainer";
            this.MediaTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.MediaTabContainer.Size = new System.Drawing.Size(375, 383);
            this.MediaTabContainer.TabIndex = 4;
            this.MediaTabContainer.Text = "Media";
            this.MediaTabContainer.UseVisualStyleBackColor = true;
            // 
            // StorageTabContainer
            // 
            this.StorageTabContainer.Location = new System.Drawing.Point(4, 22);
            this.StorageTabContainer.Name = "StorageTabContainer";
            this.StorageTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.StorageTabContainer.Size = new System.Drawing.Size(375, 383);
            this.StorageTabContainer.TabIndex = 5;
            this.StorageTabContainer.Text = "Storage";
            this.StorageTabContainer.UseVisualStyleBackColor = true;
            // 
            // ConnectionTabContainer
            // 
            this.ConnectionTabContainer.Controls.Add(this.ConnectionTabContainer_RoutingGroupBox);
            this.ConnectionTabContainer.Controls.Add(this.ConnectionTabContainer_StatusGroupBox);
            this.ConnectionTabContainer.Location = new System.Drawing.Point(4, 22);
            this.ConnectionTabContainer.Name = "ConnectionTabContainer";
            this.ConnectionTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.ConnectionTabContainer.Size = new System.Drawing.Size(375, 383);
            this.ConnectionTabContainer.TabIndex = 6;
            this.ConnectionTabContainer.Text = "Connection";
            this.ConnectionTabContainer.UseVisualStyleBackColor = true;
            // 
            // ConnectionTabContainer_RoutingGroupBox
            // 
            this.ConnectionTabContainer_RoutingGroupBox.Controls.Add(this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton);
            this.ConnectionTabContainer_RoutingGroupBox.Controls.Add(this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox);
            this.ConnectionTabContainer_RoutingGroupBox.Controls.Add(this.ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox);
            this.ConnectionTabContainer_RoutingGroupBox.Controls.Add(this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel);
            this.ConnectionTabContainer_RoutingGroupBox.Controls.Add(this.ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel);
            this.ConnectionTabContainer_RoutingGroupBox.Location = new System.Drawing.Point(18, 29);
            this.ConnectionTabContainer_RoutingGroupBox.Name = "ConnectionTabContainer_RoutingGroupBox";
            this.ConnectionTabContainer_RoutingGroupBox.Size = new System.Drawing.Size(359, 137);
            this.ConnectionTabContainer_RoutingGroupBox.TabIndex = 2;
            this.ConnectionTabContainer_RoutingGroupBox.TabStop = false;
            this.ConnectionTabContainer_RoutingGroupBox.Text = "Routing";
            // 
            // ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton
            // 
            this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton.Location = new System.Drawing.Point(239, 94);
            this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton.Name = "ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton";
            this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton.Size = new System.Drawing.Size(103, 25);
            this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton.TabIndex = 12;
            this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton.Text = "Force Update";
            this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton.UseVisualStyleBackColor = true;
            this.ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton.Click += new System.EventHandler(this.ForceUpdateButton_Click);
            // 
            // ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox
            // 
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox.Location = new System.Drawing.Point(133, 59);
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox.Name = "ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox";
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox.Size = new System.Drawing.Size(208, 20);
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox.TabIndex = 11;
            // 
            // ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox
            // 
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox.Location = new System.Drawing.Point(133, 29);
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox.Name = "ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox";
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox.Size = new System.Drawing.Size(209, 20);
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox.TabIndex = 10;
            // 
            // ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel
            // 
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel.AutoSize = true;
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel.Location = new System.Drawing.Point(13, 62);
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel.Name = "ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel";
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel.Size = new System.Drawing.Size(105, 13);
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel.TabIndex = 9;
            this.ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel.Text = "Updated IP Address:";
            // 
            // ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel
            // 
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel.AutoSize = true;
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel.Location = new System.Drawing.Point(13, 36);
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel.Name = "ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel";
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel.Size = new System.Drawing.Size(98, 13);
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel.TabIndex = 8;
            this.ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel.Text = "Current IP Address:";
            // 
            // ConnectionTabContainer_StatusGroupBox
            // 
            this.ConnectionTabContainer_StatusGroupBox.Location = new System.Drawing.Point(17, 187);
            this.ConnectionTabContainer_StatusGroupBox.Name = "ConnectionTabContainer_StatusGroupBox";
            this.ConnectionTabContainer_StatusGroupBox.Size = new System.Drawing.Size(360, 167);
            this.ConnectionTabContainer_StatusGroupBox.TabIndex = 1;
            this.ConnectionTabContainer_StatusGroupBox.TabStop = false;
            this.ConnectionTabContainer_StatusGroupBox.Text = "Status";
            // 
            // cmdOK
            // 
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
            this.cmdCancel.Location = new System.Drawing.Point(215, 427);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 29);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // MainDialog
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
            this.Name = "MainDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppName";
            this.MainTabControl.ResumeLayout(false);
            this.GeneralTabContainer.ResumeLayout(false);
            this.GeneralTabContainer_AccountGroupBox.ResumeLayout(false);
            this.GeneralTabContainer_AccountGroupBox.PerformLayout();
            this.ConnectionTabContainer.ResumeLayout(false);
            this.ConnectionTabContainer_RoutingGroupBox.ResumeLayout(false);
            this.ConnectionTabContainer_RoutingGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GeneralTabContainer;
        private System.Windows.Forms.TabPage DataTabContainer;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TabPage SecurityTabContainer;
        private System.Windows.Forms.TabPage LogsTabContainer;
        private System.Windows.Forms.TabPage MediaTabContainer;
        private System.Windows.Forms.TabPage StorageTabContainer;
        private System.Windows.Forms.TabPage ConnectionTabContainer;
        private System.Windows.Forms.GroupBox ConnectionTabContainer_RoutingGroupBox;
        private System.Windows.Forms.Button ConnectionTabContainer_RoutingGroupBox_ForceUpdateButton;
        private System.Windows.Forms.TextBox ConnectionTabContainer_RoutingGroupBox_UpdatedIPTextBox;
        private System.Windows.Forms.TextBox ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox;
        private System.Windows.Forms.Label ConnectionTabContainer_RoutingGroupBox_UpdatedIPLabel;
        private System.Windows.Forms.Label ConnectionTabContainer_RoutingGroupBox_CurrentIPLabel;
        private System.Windows.Forms.GroupBox ConnectionTabContainer_StatusGroupBox;
        private System.Windows.Forms.GroupBox GeneralTabContainer_AccountGroupBox;
        private System.Windows.Forms.Button GeneralTabContainer_AccountGroupBox_SingUpButton;
        private System.Windows.Forms.Button GeneralTabContainer_AccountGroupBox_LoginButton;
        private System.Windows.Forms.TextBox GeneralTabContainer_AccountGroupBox_PasswordTextBox;
        private System.Windows.Forms.TextBox GeneralTabContainer_AccountGroupBox_UsernameTextBox;
        private System.Windows.Forms.Label GeneralTabContainer_AccountGroupBox_PasswordLabel;
        private System.Windows.Forms.Label GeneralTabContainer_AccountGroupBox_UsernameLabel;
    }
}