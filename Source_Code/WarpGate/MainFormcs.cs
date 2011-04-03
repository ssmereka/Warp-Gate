using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WarpGate
{
    #region  /* Global Types */
    public enum OS { NULL, WinNT3_51, WinNT4_0, Win2000, Win95, Win98, Win98SE, ME, XP, Vista, Win7 };
    public enum OST { NULL, x32, x64 };
    public enum ColorFix { NULL, A, B };
    public enum AutoLaunch { NULL, Single, Multi };
    #endregion

    public partial class MainForm : Form
    {
        #region /* Class Variables */

        //SettingsForm settingsForm = null;

        SettingsForm settings = null;
        ColorFixClass colorFix = null;
        Launcher launcher = null;
        int dotCount = 0;
        int numCount = -1;
        #endregion

        #region/* Form Functions */

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
        private void RBChanged(object sender, EventArgs e)
        {
            if (SinglePlayerRB.Checked)
            {
                HamachiIPLbl.Visible = false;
                HamachiIPTxt.Visible = false;
                settings.SetSinglePlayerRB(true);
                LaunchSCBtn.Enabled = true;
            }
            else
            {
                HamachiIPLbl.Visible = true;
                HamachiIPTxt.Visible = true;
                settings.SetSinglePlayerRB(false);
                if (settings.GetHamachiIP() == "")
                    LaunchSCBtn.Enabled = false;
                else
                    LaunchSCBtn.Enabled = true;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.SaveUserSettings();
        }
        private void CloseProgram(object sender, EventArgs e)
        {
            Close();
        }
        private void UpdateHamachiIP(object sender, EventArgs e)
        {
            if (!settings.SetHamachiIP(HamachiIPTxt.Text.Trim()))
            {
                HamachiIPTxt.Text = settings.GetHamachiIP();
                if(HamachiIPTxt.Text == "")
                  LaunchSCBtn.Enabled = false;
            }
            else
            {
                LaunchSCBtn.Enabled = true;
                settings.SetHamachiIP(HamachiIPTxt.Text.Trim());
            }
        }
        private void ClearHamachiIP(object sender, EventArgs e)
        {
            HamachiIPTxt.Text = "";
        }
        private void IsHamachiIPEntered(object sender, EventArgs e)
        {
            String ip = HamachiIPTxt.Text.Trim();
            dotCount = 0;
            numCount = -1;
            for (int x = 0; x < ip.Length; x++)
            {
                if (ip[x] == '.')
                    dotCount++;
                if (dotCount == 3)
                    numCount++;
            }
            if ((dotCount == 3) && (numCount > 0))
            {
                if (!settings.SetHamachiIP(HamachiIPTxt.Text.Trim()))
                {  //Not valid
                    LaunchSCBtn.Enabled = false;
                }
                else
                {   //Valid
                    LaunchSCBtn.Enabled = true;
                    settings.SetHamachiIP(HamachiIPTxt.Text.Trim());
                }
            }
        }
        private void HamachiIPTxt_KeyUp(object sender, KeyEventArgs e)
        {
            IsHamachiIPEntered(sender, e);
        }
        private void UpdateColorFix(object sender, EventArgs e)
        {
            if (UseFix2MMI.Checked)  //Use Fix 1
            {
                UseFix2MMI.Checked = false;
                UseFix1MMI.Checked = true;
                settings.SetColorFixOption(ColorFix.A);
            }
            else  //Use Fix 2
            {
                UseFix1MMI.Checked = false;
                UseFix2MMI.Checked = true;
                settings.SetColorFixOption(ColorFix.B);
            }
        }
        private void UpdateStarcraftPath(object sender, EventArgs e)
        {
            FolderBrowserD.SelectedPath = settings.GetSCDirectory();
            FolderBrowserD.Description = "Select the folder containing the Starcraft program files.";
            if (FolderBrowserD.ShowDialog() == DialogResult.OK)
            {
                if (settings.GetSCDirectory() != FolderBrowserD.SelectedPath)
                {
                    if (!settings.SetSCDirectory(FolderBrowserD.SelectedPath, true))
                    {
                        if (System.Windows.Forms.DialogResult.Yes == MessageBox.Show("The selected directory does not contain \""
                            + settings.GetSCExe() +
                            "\" which is your currently selected Starcraft executable.  " +
                            "Do you still want to set \"" + FolderBrowserD.SelectedPath + "\" as your default starcraft directory?",
                            "Directory is not valid!",
                            MessageBoxButtons.YesNo))
                            settings.SetSCDirectory(FolderBrowserD.SelectedPath);
                    }
                }
            } 
        }
        private void UpdateStarcraftExe(object sender, EventArgs e)
        {
            OpenFileD.Title = "Select the desired Starcraft executable.";
            OpenFileD.InitialDirectory = settings.GetSCDirectory();
            if (OpenFileD.ShowDialog() == DialogResult.OK)
            {
                settings.SetSCDirExe(OpenFileD.FileName);
            }
        }
        private void SearchStarcraftPath(object sender, EventArgs e)
        {
            //TODO:  search for starcraft path based on exe
        }
        private void CheckForUpdates(object sender, EventArgs e)
        {
            //TODO:  Check website for updates
        }
        private void OpenSettings(object sender, EventArgs e)
        {
            settings.ShowDialog();
        }
        private void ViewHelp(object sender, EventArgs e)
        {
        }
        private void LaunchStarcraft(object sender, EventArgs e)
        {
            if (settings.GetColorFixOption() != ColorFix.NULL)  //If color fix is needed
            {
                if (settings.GetColorFixOption() == ColorFix.A)  //Perform color fix A
                    colorFix.ColorFixA();
                else if (settings.GetColorFixOption() == ColorFix.B) //Perform color fix B
                    colorFix.ColorFixB();
            }
            
            Launcher launchSC = new Launcher();

            String InjectIP = "test";

            if (SinglePlayerRB.Checked)  //Launch Normal or UDP mode arguments
                launchSC.Argument = " \"" + settings.GetSCDirectory() + "\\" + settings.GetSCExe() + "\"";
            else
                launchSC.Argument = InjectIP + settings.GetHamachiIP() + " \"" + settings.GetSCDirectory() + "\"";

            Thread Starcraft = new Thread(launchSC.StartSC);
            Starcraft.Start();
            Starcraft.Join();

            if(settings.GetColorFixOption() == ColorFix.A)  //Undo color fix A
                colorFix.UndoColorFixA();
            else if (settings.GetColorFixOption() == ColorFix.B)  //Undo color fix B
                colorFix.UndoColorFixB();
        }
        public void UpdateSettings()
        {//Update settings from settings form

            if (settings.GetColorFixOption() == ColorFix.A)  //Update colorfix
            {
                ColorFixMMI.Visible = true;
                UseFix1MMI.Checked = true;
                UseFix2MMI.Checked = false;
            }
            else if (settings.GetColorFixOption() == ColorFix.B)
            {
                ColorFixMMI.Visible = true;
                UseFix2MMI.Checked = true;
                UseFix1MMI.Checked = false;
            }
            else
                ColorFixMMI.Visible = false;
            HamachiIPTxt.Text = settings.GetHamachiIP();  //Update Hamachi
            SinglePlayerRB.Checked = settings.GetSinglePlayerRB();
            StatusSBLb.Text = settings.GetCurOS().ToString() + " " + settings.GetCurOST().ToString();
        }
        #endregion

        #region /* Private Functions */

        private void LoadSettings()
        {
            settings = new SettingsForm(this);
            colorFix = new ColorFixClass();
            launcher = new Launcher();
            settings.LoadSettings();

            if (!settings.GetSinglePlayerRB())    //Set Radiobutton
            {
                HamachiIPLbl.Visible = true;
                HamachiIPTxt.Visible = true;
                MultiPlayerRB.Checked = true;
            }
            else
                SinglePlayerRB.Checked = true;

            HamachiIPTxt.Text = settings.GetHamachiIP();  //Set Hamachi IP address

            if (settings.GetColorFixOption() == ColorFix.A)  //Set color fix
            {
                ColorFixMMI.Visible = true;
                UseFix1MMI.Checked = true;
                UseFix2MMI.Checked = false;
            }
            else if (settings.GetColorFixOption() == ColorFix.B)
            {
                ColorFixMMI.Visible = true;
                UseFix2MMI.Checked = true;
                UseFix1MMI.Checked = false;
            }
            else
                ColorFixMMI.Visible = false;

            StatusSBLb.Text = settings.GetCurOS().ToString() + " " + settings.GetCurOST().ToString();
        }

        #endregion

    }
}
