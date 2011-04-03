namespace WarpGate
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdatesMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFixMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.UseFix1MMI = new System.Windows.Forms.ToolStripMenuItem();
            this.UseFix2MMI = new System.Windows.Forms.ToolStripMenuItem();
            this.SCDirMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePathMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeExecutableMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingsMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewHelpMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutMMI = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusSBLb = new System.Windows.Forms.ToolStripStatusLabel();
            this.SinglePlayerRB = new System.Windows.Forms.RadioButton();
            this.MultiPlayerRB = new System.Windows.Forms.RadioButton();
            this.HamachiIPTxt = new System.Windows.Forms.TextBox();
            this.HamachiIPLbl = new System.Windows.Forms.Label();
            this.LaunchSCBtn = new System.Windows.Forms.Button();
            this.FolderBrowserD = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenFileD = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMMI,
            this.EditMMI,
            this.HelpMMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(355, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMMI
            // 
            this.FileMMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckForUpdatesMMI,
            this.toolStripSeparator1,
            this.ExitMMI});
            this.FileMMI.Name = "FileMMI";
            this.FileMMI.Size = new System.Drawing.Size(44, 24);
            this.FileMMI.Text = "File";
            // 
            // CheckForUpdatesMMI
            // 
            this.CheckForUpdatesMMI.Name = "CheckForUpdatesMMI";
            this.CheckForUpdatesMMI.Size = new System.Drawing.Size(199, 24);
            this.CheckForUpdatesMMI.Text = "Check for Updates";
            this.CheckForUpdatesMMI.Click += new System.EventHandler(this.CheckForUpdates);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // ExitMMI
            // 
            this.ExitMMI.Name = "ExitMMI";
            this.ExitMMI.Size = new System.Drawing.Size(199, 24);
            this.ExitMMI.Text = "Exit";
            this.ExitMMI.Click += new System.EventHandler(this.CloseProgram);
            // 
            // EditMMI
            // 
            this.EditMMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorFixMMI,
            this.SCDirMMI,
            this.toolStripSeparator3,
            this.SettingsMMI});
            this.EditMMI.Name = "EditMMI";
            this.EditMMI.Size = new System.Drawing.Size(47, 24);
            this.EditMMI.Text = "Edit";
            // 
            // ColorFixMMI
            // 
            this.ColorFixMMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UseFix1MMI,
            this.UseFix2MMI});
            this.ColorFixMMI.Name = "ColorFixMMI";
            this.ColorFixMMI.Size = new System.Drawing.Size(199, 24);
            this.ColorFixMMI.Text = "Color Fix";
            // 
            // UseFix1MMI
            // 
            this.UseFix1MMI.Name = "UseFix1MMI";
            this.UseFix1MMI.Size = new System.Drawing.Size(136, 24);
            this.UseFix1MMI.Text = "Use Fix 1";
            this.UseFix1MMI.Click += new System.EventHandler(this.UpdateColorFix);
            // 
            // UseFix2MMI
            // 
            this.UseFix2MMI.Name = "UseFix2MMI";
            this.UseFix2MMI.Size = new System.Drawing.Size(136, 24);
            this.UseFix2MMI.Text = "Use Fix 2";
            this.UseFix2MMI.Click += new System.EventHandler(this.UpdateColorFix);
            // 
            // SCDirMMI
            // 
            this.SCDirMMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangePathMMI,
            this.ChangeExecutableMMI});
            this.SCDirMMI.Name = "SCDirMMI";
            this.SCDirMMI.Size = new System.Drawing.Size(199, 24);
            this.SCDirMMI.Text = "Starcraft Directory";
            // 
            // ChangePathMMI
            // 
            this.ChangePathMMI.Name = "ChangePathMMI";
            this.ChangePathMMI.Size = new System.Drawing.Size(204, 24);
            this.ChangePathMMI.Text = "Change Path";
            this.ChangePathMMI.Click += new System.EventHandler(this.UpdateStarcraftPath);
            // 
            // ChangeExecutableMMI
            // 
            this.ChangeExecutableMMI.Name = "ChangeExecutableMMI";
            this.ChangeExecutableMMI.Size = new System.Drawing.Size(204, 24);
            this.ChangeExecutableMMI.Text = "Change Executable";
            this.ChangeExecutableMMI.Click += new System.EventHandler(this.UpdateStarcraftExe);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // SettingsMMI
            // 
            this.SettingsMMI.Name = "SettingsMMI";
            this.SettingsMMI.Size = new System.Drawing.Size(199, 24);
            this.SettingsMMI.Text = "Settings";
            this.SettingsMMI.Click += new System.EventHandler(this.OpenSettings);
            // 
            // HelpMMI
            // 
            this.HelpMMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewHelpMMI,
            this.toolStripSeparator2,
            this.AboutMMI});
            this.HelpMMI.Name = "HelpMMI";
            this.HelpMMI.Size = new System.Drawing.Size(53, 24);
            this.HelpMMI.Text = "Help";
            // 
            // ViewHelpMMI
            // 
            this.ViewHelpMMI.Name = "ViewHelpMMI";
            this.ViewHelpMMI.Size = new System.Drawing.Size(146, 24);
            this.ViewHelpMMI.Text = "View Help";
            this.ViewHelpMMI.Click += new System.EventHandler(this.ViewHelp);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // AboutMMI
            // 
            this.AboutMMI.Name = "AboutMMI";
            this.AboutMMI.Size = new System.Drawing.Size(146, 24);
            this.AboutMMI.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusSBLb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 155);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(355, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusSBLb
            // 
            this.StatusSBLb.Name = "StatusSBLb";
            this.StatusSBLb.Size = new System.Drawing.Size(74, 20);
            this.StatusSBLb.Text = "Working...";
            // 
            // SinglePlayerRB
            // 
            this.SinglePlayerRB.AutoSize = true;
            this.SinglePlayerRB.Location = new System.Drawing.Point(12, 43);
            this.SinglePlayerRB.Name = "SinglePlayerRB";
            this.SinglePlayerRB.Size = new System.Drawing.Size(180, 21);
            this.SinglePlayerRB.TabIndex = 2;
            this.SinglePlayerRB.TabStop = true;
            this.SinglePlayerRB.Text = "Single Player / Battlenet";
            this.SinglePlayerRB.UseVisualStyleBackColor = true;
            this.SinglePlayerRB.CheckedChanged += new System.EventHandler(this.RBChanged);
            // 
            // MultiPlayerRB
            // 
            this.MultiPlayerRB.AutoSize = true;
            this.MultiPlayerRB.Location = new System.Drawing.Point(12, 70);
            this.MultiPlayerRB.Name = "MultiPlayerRB";
            this.MultiPlayerRB.Size = new System.Drawing.Size(186, 21);
            this.MultiPlayerRB.TabIndex = 3;
            this.MultiPlayerRB.TabStop = true;
            this.MultiPlayerRB.Text = "Multiplayer (VLAN / LAN)";
            this.MultiPlayerRB.UseVisualStyleBackColor = true;
            this.MultiPlayerRB.CheckedChanged += new System.EventHandler(this.RBChanged);
            // 
            // HamachiIPTxt
            // 
            this.HamachiIPTxt.Location = new System.Drawing.Point(217, 70);
            this.HamachiIPTxt.Name = "HamachiIPTxt";
            this.HamachiIPTxt.Size = new System.Drawing.Size(126, 22);
            this.HamachiIPTxt.TabIndex = 4;
            this.HamachiIPTxt.Visible = false;
            this.HamachiIPTxt.Enter += new System.EventHandler(this.ClearHamachiIP);
            this.HamachiIPTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HamachiIPTxt_KeyUp);
            this.HamachiIPTxt.Leave += new System.EventHandler(this.UpdateHamachiIP);
            // 
            // HamachiIPLbl
            // 
            this.HamachiIPLbl.AutoSize = true;
            this.HamachiIPLbl.Location = new System.Drawing.Point(241, 45);
            this.HamachiIPLbl.Name = "HamachiIPLbl";
            this.HamachiIPLbl.Size = new System.Drawing.Size(79, 17);
            this.HamachiIPLbl.TabIndex = 5;
            this.HamachiIPLbl.Text = "Hamachi IP";
            this.HamachiIPLbl.Visible = false;
            // 
            // LaunchSCBtn
            // 
            this.LaunchSCBtn.Enabled = false;
            this.LaunchSCBtn.Location = new System.Drawing.Point(12, 107);
            this.LaunchSCBtn.Name = "LaunchSCBtn";
            this.LaunchSCBtn.Size = new System.Drawing.Size(331, 36);
            this.LaunchSCBtn.TabIndex = 6;
            this.LaunchSCBtn.Text = "Launch Starcraft";
            this.LaunchSCBtn.UseVisualStyleBackColor = true;
            this.LaunchSCBtn.Click += new System.EventHandler(this.LaunchStarcraft);
            // 
            // OpenFileD
            // 
            this.OpenFileD.FileName = "Starcraft.exe";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 180);
            this.Controls.Add(this.LaunchSCBtn);
            this.Controls.Add(this.HamachiIPLbl);
            this.Controls.Add(this.HamachiIPTxt);
            this.Controls.Add(this.MultiPlayerRB);
            this.Controls.Add(this.SinglePlayerRB);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Warp Gate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitMMI;
        private System.Windows.Forms.ToolStripMenuItem EditMMI;
        private System.Windows.Forms.ToolStripMenuItem ColorFixMMI;
        private System.Windows.Forms.ToolStripMenuItem UseFix1MMI;
        private System.Windows.Forms.ToolStripMenuItem UseFix2MMI;
        private System.Windows.Forms.ToolStripMenuItem SCDirMMI;
        private System.Windows.Forms.ToolStripMenuItem HelpMMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem AboutMMI;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RadioButton SinglePlayerRB;
        private System.Windows.Forms.RadioButton MultiPlayerRB;
        private System.Windows.Forms.TextBox HamachiIPTxt;
        private System.Windows.Forms.Label HamachiIPLbl;
        private System.Windows.Forms.Button LaunchSCBtn;
        private System.Windows.Forms.ToolStripStatusLabel StatusSBLb;
        private System.Windows.Forms.ToolStripMenuItem ChangePathMMI;
        private System.Windows.Forms.ToolStripMenuItem ChangeExecutableMMI;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserD;
        private System.Windows.Forms.OpenFileDialog OpenFileD;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesMMI;
        private System.Windows.Forms.ToolStripMenuItem ViewHelpMMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem SettingsMMI;
    }
}