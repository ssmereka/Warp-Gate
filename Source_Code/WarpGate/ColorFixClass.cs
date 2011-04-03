using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace WarpGate
{
    class ColorFixClass
    {
        /* Public Static Class Variables */

        #region  /* Private Class Variables */

        WindowHandler wh = new WindowHandler();

        #endregion

        #region  /* Public Functions */

        public void ColorFixA()
        {
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            cmd.EnableRaisingEvents = false;
            cmd.StartInfo.CreateNoWindow = true;
            System.Diagnostics.Process.Start("CMD.exe", "/c " + "start desk.cpl"); //Open screen resolution
            cmd.Close();
        }
        public void UndoColorFixA()
        {
            wh.Close(wh.FindWindowByCaption("Screen Resolution"));
        }
        public void ColorFixB()
        {
            System.Diagnostics.Process.Start("CMD.exe", "/c" + "taskkill /f /IM explorer.exe");  //Kill windows explorer
        }
        public void UndoColorFixB()
        {
            //TODO:  Restart explorer
        }

        #endregion

        /* Private Functions */

        #region /* Unused Functions */

        private void SendCommandToCMD()
        { //Sends key commands to write explorer to open command prompt
            int iHandle = wh.FindWindowByCaption("Administrator: C:\\Windows\\system32\\cmd.exe");  //Untitled - Notepad //Administrator: 
            wh.SetForegroundWnd2(iHandle);
            string message = "explorer";
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            for (int x = 0; x < message.Length; x++)
            {
                System.Threading.Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait(message.Substring(x, 1));
            }
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        }

        #endregion
    }
}
