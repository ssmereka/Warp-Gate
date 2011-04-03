using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;

namespace WarpGate
{
    public partial class SettingsForm : Form
    {
        #region  /* Settings Variables */
        private OS CurOS = OS.NULL;                         //Current operating system enum OS
        private String CurOSStr = null;                     //Current operating system in a string
        private OST CurOST = OST.NULL;                      //Current operating system type enum OST
        private String CurOSTStr = null;                    //Current operating system type in a string
        private ColorFix ColorFixOption = ColorFix.NULL;    //Current color fix being used enum ColorFix
        private String ColorFixOptionStr = null;            //Current color fix being used in a string
        private String SCDirectory = null;                  //Starcraft Directory
        private String SCExe = null;                        //Starcraft Exe
        private String HamachiIP = "";                      //Hamachi IP Address
        private Boolean SinglePlayerRB = false;             //Current checked radio box

        MainForm parent = null;
        Boolean resetSettings = false;

        #endregion

        #region /* Form Functions */

        public SettingsForm(MainForm f) 
        {
            InitializeComponent();
            parent = f;
            LoadFormSettings();
        }
        private void SettingsForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
                LoadFormSettings();
        }
        private void SettingsForm_OKClicked(object sender, EventArgs e)
        {
            if (resetSettings)
            {
                resetSettings = false;
                ResetSettings();
            }
            SaveFormSettings();
            this.Visible = false;
        }
        private void SettingsForm_CancelClicked(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void SettingsForm_AutoSearchClicked(object sender, EventArgs e)
        {
            SCDirTxt.Text = FindSCDirectoryStr();
        }
        private void SettingsForm_BrowseBtnClicked(object sender, EventArgs e)
        {
            OpenFileD.Title = "Select the desired Starcraft executable.";
            OpenFileD.InitialDirectory = GetSCDirectory();
            if (OpenFileD.ShowDialog() == DialogResult.OK)
            {
                SCDirTxt.Text = OpenFileD.FileName;
            }
        }
        private void SettingsForm_DefaultBtnClicked(object sender, EventArgs e)
        {
            //Prompt user of destructive task
            resetSettings = true;
            SettingsForm_AutoSearchClicked(sender, e);
            ColorFix1RB.Checked = true;
        }

        #endregion

        #region /* Form Private Functions */

        private void LoadFormSettings()
        {
            SCDirTxt.Text = this.SCDirectory + "\\" + this.SCExe;
            if (GetColorFixOption() == ColorFix.A)  //Fix 1
                ColorFix1RB.Checked = true;
            else if (GetColorFixOption() == ColorFix.B)  //Fix 2
                ColorFix2RB.Checked = true;
            //Check what is installed
        }

        private void SaveFormSettings()
        {
            SetSCDirExe(SCDirTxt.Text.Trim());      //Save directory
            if (ColorFix1RB.Checked)                //Save color fix
                SetColorFixOption(ColorFix.A);
            else if (ColorFix2RB.Checked)
                SetColorFixOption(ColorFix.B);
            parent.UpdateSettings();            //Update Main Form
        }

        #endregion

        #region /* Regular Expressions */

        private static Regex regIP = new Regex(@"^((([0-9]{1,2})|(1[0-9]{2,2})|(2[0-4][0-9])|(25[0-5])|\*)\.){3}(([0-9]{1,2})|(1[0-9]{2,2})|(2[0-4][0-9])|(25[0-5])|\*)$");

        #endregion

        #region /* Static Variables */
        #region /* Default Starcraft Directories */
        public static string DefaultSC_win7_x32 = @"C:\Program Files\Starcraft\";
        public static string DefaultSC_win7_x64 = @"C:\Program Files (x86)\Starcraft\";
        public static string DefaultSC_vista_x32 = @"C:\Program Files\Starcraft\";
        public static string DefaultSC_vista_x64 = @"C:\program Files (x86)\Starcraft\";
        public static string DefaultSC_XP_x32 = @"C:\Program Files\Starcraft\";
        public static string DefaultSC_XP_x64 = @"C:\Program Files (x86)\Starcraft\";
        #endregion
        #region/* Default Starcraft Executables */
        public static string DefaultSCExe_win7_x32 = @"Starcraft.exe";
        public static string DefaultSCExe_win7_x64 = @"Starcraft.exe";
        public static string DefaultSCExe_vista_x32 = @"Starcraft.exe";
        public static string DefaultSCExe_vista_x64 = @"Starcraft.exe";
        public static string DefaultSCExe_XP_x32 = @"Starcraft.exe";
        public static string DefaultSCExe_XP_x64 = @"Starcraft.exe";
        #endregion
        #endregion

        #region  /* Public Functions */

        public void LoadSettings()
        {
            if (LoadUserSettings())
            {
                ResetSettings();
            }
        }

        public void SaveUserSettings()
        {
            Properties.Settings.Default.StarcraftDirectory = SCDirectory;
            Properties.Settings.Default.StarcraftExe = SCExe;
            Properties.Settings.Default.HamachiIPAddress = HamachiIP;
            Properties.Settings.Default.SinglePlayer = SinglePlayerRB;
            Properties.Settings.Default.CurrentOS = CurOSStr;
            Properties.Settings.Default.CurrentOST = CurOSTStr;
            Properties.Settings.Default.ColorFix = ColorFixOptionStr;
            Properties.Settings.Default.UserDefault = true;
        }

        public void ResetSettings()
        {
            SetOS();                        //Set current OS
            SetOST();                       //Set current OST
            FindAndSetSCDirectory();        //Look for starcraft directory or set to nothing.
            HamachiIP = "";                 //Set Hamachi IP address to nothing
            SetColorFixOption();            //Set Default ColorFixOption if needed
            SinglePlayerRB = true;          //Set SinglePlayer radio box to checked
            Properties.Settings.Default.UserDefault = true;  //Set settings to default
        }

        #endregion

        #region /* Getters & Setters */

        public Boolean SetSCDirExe(String fullpath) //Set SCDir & SCExe 
        {
            return SetSCDirExe(fullpath, false);
        }
        public Boolean SetSCDirExe(String fullpath, Boolean validate)
        {  
            if ((validate) && (fullpath !=""))
            {
                if (File.Exists(fullpath))
                {
                    SCExe = Path.GetFileName(fullpath);
                    SCDirectory = Path.GetDirectoryName(fullpath);
                    return true;
                }
            }
            else if (fullpath != "")
            {
                SCExe = Path.GetFileName(fullpath);
                SCDirectory = Path.GetDirectoryName(fullpath);
                return File.Exists(fullpath);
            }
            else
            {
                SCDirectory = "";
                SCExe = "";
            }
            return false;
        }
        public Boolean SetSCDirectory(String path) //Set SCDir 
        { /* Pre:  For a validation to return true, 
           *       SCExe must already be set by user or default.
           * Post: Sets SCDirectory even if not valid
           *       Returns the result of the validation.
           */
            return SetSCDirectory(path, false);
        }
        public Boolean SetSCDirectory(String path, Boolean validate)
        { /* Pre:  
           * Post: 
           */
            if (validate)
            {
                if (File.Exists(path + "\\" + this.SCExe))
                {
                    SCDirectory = path;
                    return true;
                }
            }
            else
            {
                SCDirectory = path;
                return File.Exists(path + "\\" + this.SCExe);
            }
            return false;
        }
        public String GetSCDirectory() //Get SCDir String 
        {
            return SCDirectory;
        }

        public Boolean SetSCExe(String exe) //Set SCExe 
        { /* Pre:  For a validation to return true, 
           *       SCDirectory must already be set by user or default.
           * Post: Sets SCExe even if not valid
           *       Returns the result of the validation.
           */
            return SetSCExe(exe, false);
        }
        public Boolean SetSCExe(String exe, Boolean validate)
        {
            if (validate)
            {
                if (File.Exists(this.SCDirectory + "\\" + exe))
                {
                    SCExe = exe;
                    return true;
                }
            }
            else
            {
                SCExe = exe;
                return File.Exists(this.SCDirectory + "\\" + exe);
            }
            return false;
        }
        public String GetSCExe() //Get SCExe 
        {
            return SCExe;
        }

        public Boolean SetHamachiIP(String ip) //Set HamachiIP 
        {
            if (regIP.IsMatch(ip, 0)) //Validate IP Address
            {
                HamachiIP = ip;
                return true;
            }
            else
                return false;
        }
        public String GetHamachiIP() //Get HamachiIP 
        {
            return HamachiIP;
        }

        public Boolean SetSinglePlayerRB(Boolean selected) //Set SinglePlayerRB 
        {
            SinglePlayerRB = selected;
            return true;
        }
        public Boolean GetSinglePlayerRB() //Get SinglePlayerRB 
        {
            return SinglePlayerRB;
        }

        public Boolean SetColorFixOption() //Set Default ColorFixOption
        { /* Pre:  none.
           * Post: Sets color fix & color fix string to A
           *       If color fix is not needed, both are set to null.
           */
            if (CurOS == OS.Win7 || CurOS == OS.Vista)
            {
                ColorFixOption = ColorFix.A;
                ColorFixOptionStr = "A";
                return true;
            }
            else
            {
                ColorFixOption = ColorFix.NULL;
                ColorFixOptionStr = "NULL";
                return false;
            }
        }
        public Boolean SetColorFixOption(ColorFix option) //Set ColorFixOption 
        {/* Pre:  none.
          * Post: Sets color fix & color fix string
          *       If invalid option is passed, return false & set to NULL
          */
            switch (option)
            {
                case ColorFix.A:
                    ColorFixOptionStr = "A";
                    ColorFixOption = option;
                    break;
                case ColorFix.B:
                    ColorFixOptionStr = "B";
                    ColorFixOption = option;
                    break;
                case ColorFix.NULL:
                    ColorFixOptionStr = "NULL";
                    ColorFixOption = option;
                    break;
                default:
                    ColorFixOptionStr = "NULL";
                    ColorFixOption = ColorFix.NULL;
                    return false;  //Invalid option
            }
            return true;
        }
        public Boolean SetColorFixOption(String option) //Set ColorFixOption 
        {/* Pre:  none.
          * Post: Sets color fix & color fix string
          *       If invalid option is passed, return false & set to NULL
          */
            if (option == "A")
            {
                ColorFixOptionStr = "A";
                ColorFixOption = ColorFix.A;
            }
            else if (option == "B")
            {
                ColorFixOptionStr = "B";
                ColorFixOption = ColorFix.B;
            }
            else if (option == "NULL")
            {
                ColorFixOptionStr = "NULL";
                ColorFixOption = ColorFix.NULL;
            }
            else
            {
                ColorFixOptionStr = "NULL";
                ColorFixOption = ColorFix.NULL;
                return false;  //Invalid option
            }
            return true;
        }
        public ColorFix GetColorFixOption() //Get ColorFixOption 
        {
            return ColorFixOption;
        }
        public String GetColorFixOptionStr() //Get ColorFixOption 
        {
            return ColorFixOptionStr;
        }

        public Boolean SetCurOS(OS os) //Set CurOS 
        {/* Pre:  none.
          * Post: Sets current OS & current OS string
          *       If invalid option is passed, return false & set to NULL
          */
            switch (os)
            {
                case OS.Win7:
                    CurOS = OS.Win7;
                    CurOSStr = "Win7";
                    break;
                case OS.Vista:
                    CurOS = OS.Vista;
                    CurOSStr = "Vista";
                    break;
                case OS.XP:
                    CurOS = OS.XP;
                    CurOSStr = "XP";
                    break;
                case OS.ME:
                    CurOS = OS.ME;
                    CurOSStr = "ME";
                    break;
                case OS.Win2000:
                    CurOS = OS.Win2000;
                    CurOSStr = "Win2000";
                    break;
                case OS.WinNT4_0:
                    CurOS = OS.WinNT4_0;
                    CurOSStr = "WinNT4_0";
                    break;
                case OS.WinNT3_51:
                    CurOS = OS.WinNT3_51;
                    CurOSStr = "WinNT3_51";
                    break;
                case OS.Win98SE:
                    CurOS = OS.Win98SE;
                    CurOSStr = "Win98SE";
                    break;
                case OS.Win98:
                    CurOS = OS.Win98;
                    CurOSStr = "Win98";
                    break;
                case OS.Win95:
                    CurOS = OS.Win95;
                    CurOSStr = "Win95";
                    break;
                case OS.NULL:
                    CurOS = OS.NULL;
                    CurOSStr = "NULL";
                    break;
                default:
                    CurOS = OS.NULL;
                    CurOSStr = "NULL";
                    return false;  //Invalid option
            }
            return true;
        }
        public Boolean SetCurOS(String os) //Set CurOS 
        {/* Pre:  none.
          * Post: Sets current OS & current OS string
          *       If invalid option is passed, return false & set to NULL
          */
            if (os == "Win7")
            {
                CurOS = OS.Win7;
                CurOSStr = "Win7";
            }
            else if (os == "Vista")
            {
                CurOS = OS.Vista;
                CurOSStr = "Vista";
            }
            else if (os == "XP")
            {
                CurOS = OS.XP;
                CurOSStr = "XP";
            }
            else if (os == "ME")
            {
                CurOS = OS.ME;
                CurOSStr = "ME";
            }
            else if (os == "Win2000")
            {
                CurOS = OS.Win2000;
                CurOSStr = "Win2000";
            }
            else if (os == "WinNT4_0")
            {
                CurOS = OS.WinNT4_0;
                CurOSStr = "WinNT4_0";
            }
            else if (os == "WinNT3_51")
            {
                CurOS = OS.WinNT3_51;
                CurOSStr = "WinNT3_51";
            }
            else if (os == "Win98SE")
            {
                CurOS = OS.Win98SE;
                CurOSStr = "Win98SE";
            }
            else if (os == "Win98")
            {
                CurOS = OS.Win98;
                CurOSStr = "Win98";
            }
            else if (os == "Win95")
            {
                CurOS = OS.Win95;
                CurOSStr = "Win95";
            }
            else if (os == "NULL")
            {
                CurOS = OS.NULL;
                CurOSStr = "NULL";
            }
            else
            {
                CurOS = OS.NULL;
                CurOSStr = "NULL";
                return false;
            }
            return true;
        }
        public OS GetCurOS() //Get CurOS 
        {
            return CurOS;
        }
        public String GetCurOSStr() //Get CurOS 
        {
            return CurOSStr;
        }

        public Boolean SetCurOST(OST ost) //Set CurOST 
        {/* Pre:  none.
          * Post: Sets current OST & current OST string
          *       If invalid option is passed, return false & set to NULL
          */
            switch (ost)
            {
                case OST.x64:
                    CurOST = OST.x64;
                    CurOSTStr = "x64";
                    break;
                case OST.x32:
                    CurOST = OST.x32;
                    CurOSTStr = "x32";
                    break;
                case OST.NULL:
                    CurOST = OST.NULL;
                    CurOSTStr = "NULL";
                    break;
                default:
                    CurOST = OST.NULL;
                    CurOSTStr = "NULL";
                    return false;
            }
            return true;
        }
        public Boolean SetCurOST(String ost) //Set CurOST 
        {/* Pre:  none.
          * Post: Sets current OST & current OST string
          *       If invalid option is passed, return false & set to NULL
          */
            if (ost == "x64")
            {
                CurOST = OST.x64;
                CurOSTStr = "x64";
            }
            else if (ost == "x32")
            {
                CurOST = OST.x32;
                CurOSTStr = "x32";
            }
            else if (ost == "NULL")
            {
                CurOST = OST.NULL;
                CurOSTStr = "NULL";
            }
            else
            {
                CurOST = OST.NULL;
                CurOSTStr = "NULL";
                return false;
            }
            return true;
        }
        public OST GetCurOST() //Get CurOST 
        {
            return CurOST;
        }
        public String GetCurOSTStr() //Get CurOST 
        {
            return CurOSTStr;
        }

        #endregion

        #region /* Private Class Functions */

        private Boolean LoadUserSettings()
        {
            SCDirectory = Properties.Settings.Default.StarcraftDirectory;
            SCExe = Properties.Settings.Default.StarcraftExe;
            HamachiIP = Properties.Settings.Default.HamachiIPAddress;
            SinglePlayerRB = Properties.Settings.Default.SinglePlayer;
            CurOSStr = Properties.Settings.Default.CurrentOS;
            CurOSTStr = Properties.Settings.Default.CurrentOST;
            ColorFixOptionStr = Properties.Settings.Default.ColorFix;
            return Properties.Settings.Default.UserDefault;
        }

        private Boolean FindAndSetSCDirectory()
        {
            String temp = GetDefaultSCPath();
            if (!SetSCDirExe(temp, true))
            {
                SetSCDirectory(null, false);
                SetSCExe(Path.GetFileName(GetDefaultSCPath()));
                return false;
            }
            return true;
        }

        private String FindSCDirectoryStr()
        {
            String temp = GetDefaultSCPath();
            if (File.Exists(temp))
            {
                return temp;
            }
            return null;
        }

        private String GetDefaultSCPath() //Returns Default Path 
        {
            switch (CurOS)
            {
                case OS.Win7:
                    switch (CurOST)
                    {
                        case OST.x64:
                            return DefaultSC_win7_x64 + DefaultSCExe_win7_x64;
                        case OST.x32:
                            return DefaultSC_win7_x32 + DefaultSCExe_win7_x32;
                        default: return null;
                    }
                case OS.Vista:
                    switch (CurOST)
                    {
                        case OST.x64:
                            return DefaultSC_vista_x64 + DefaultSCExe_vista_x64;
                        case OST.x32:
                            return DefaultSC_vista_x32 + DefaultSCExe_vista_x32;
                        default: return null;
                    }
                case OS.XP:
                    switch (CurOST)
                    {
                        case OST.x64:
                            return DefaultSC_XP_x64 + DefaultSCExe_XP_x64;
                        case OST.x32:
                            return DefaultSC_XP_x32 + DefaultSCExe_XP_x32;
                        default: return null;
                    }
                default: return null;
            }
        }

        private void SetOS()
        {/* Pre: 
          * 
          * Post: Sets the Current OS (CurOS) */

            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;
            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        CurOS = OS.Win95;
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            CurOS = OS.Win98SE;
                        else
                            CurOS = OS.Win98;
                        break;
                    case 90:
                        CurOS = OS.ME;
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        CurOS = OS.WinNT3_51;
                        break;
                    case 4:
                        CurOS = OS.WinNT4_0;
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            CurOS = OS.Win2000;
                        else
                            CurOS = OS.XP;
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            CurOS = OS.Vista;
                        else
                        {
                            CurOS = OS.Win7;
                            Console.WriteLine("Win7");
                        }
                        break;
                    default:
                        break;
                }
            }

        }

        private void SetOST()
        {
            if (Is64BitOperatingSystem())
                CurOST = OST.x64;
            else
                CurOST = OST.x32;
        }

        #region /* Microsoft - Detect 64bit OS */
        /// <summary>
        /// The function determines whether the current operating system is a 
        /// 64-bit operating system.
        /// </summary>
        /// <returns>
        /// The function returns true if the operating system is 64-bit; 
        /// otherwise, it returns false.
        /// </returns>
        public static bool Is64BitOperatingSystem()
        {
            if (IntPtr.Size == 8)  // 64-bit programs run only on Win64
            {
                return true;
            }
            else  // 32-bit programs run on both 32-bit and 64-bit Windows
            {
                // Detect whether the current process is a 32-bit process 
                // running on a 64-bit system.
                bool flag;
                return ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") &&
                    IsWow64Process(GetCurrentProcess(), out flag)) && flag);
            }
        }

        /// <summary>
        /// The function determins whether a method exists in the export 
        /// table of a certain module.
        /// </summary>
        /// <param name="moduleName">The name of the module</param>
        /// <param name="methodName">The name of the method</param>
        /// <returns>
        /// The function returns true if the method specified by methodName 
        /// exists in the export table of the module specified by moduleName.
        /// </returns>
        static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            if (moduleHandle == IntPtr.Zero)
            {
                return false;
            }
            return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule,
            [MarshalAs(UnmanagedType.LPStr)]string procName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

        #endregion

        #region /* Unused Functions */
        /*
        int getOSArchitecture()
        {
            string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return ((String.IsNullOrEmpty(pa) || String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64);
        }
        */
        #endregion

        #endregion
    }
}
