using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarpGate
{
    class Launcher
    {
        public volatile string Argument = "";

      #region /* Public Functions */

        public void StartSC()
        {
            System.Diagnostics.Process startSC = new System.Diagnostics.Process();
            try
            {
                startSC.EnableRaisingEvents = false;
                startSC.StartInfo.CreateNoWindow = true;
                startSC.StartInfo.Arguments = "/c " + Argument;
                startSC.StartInfo.FileName = "CMD.exe";
                System.Threading.Thread.Sleep(1000);
                startSC.Start();
                startSC.WaitForExit();
            }
            catch
            {
                //Inform main class
                //startSC.Close();
               // startSC.Dispose();
            }
            startSC.Close();
            startSC.Dispose();
        }

      #endregion

        public void StartFBIP()
        {/* Pre:  ForceBindIP not already installed
          * 
          * Post: Launch ForceBindIP Installer*/

            System.Diagnostics.Process startFBIP = new System.Diagnostics.Process();
            startFBIP.EnableRaisingEvents = false;
            startFBIP.StartInfo.FileName = "ForceBindIP-1.2a-Setup.exe";
            try
            {
                startFBIP.Start();
                startFBIP.WaitForExit();
            }
            catch
            {
            }
            startFBIP.Close();
            startFBIP.Dispose();
        }

        public void StartHamachi()
        {/* Pre: Hamachi not already installed
          * 
          * Post: Launch Hamachi installer */
            System.Diagnostics.Process startHamachi = new System.Diagnostics.Process();
            startHamachi.EnableRaisingEvents = false;
            startHamachi.StartInfo.FileName = "hamachi.msi";
            try
            {
                startHamachi.Start();
                startHamachi.WaitForExit();
            }
            catch
            {
            }

            startHamachi.Close();
            startHamachi.Dispose();
        }
        //private volatile boofffl _shouldStop;
    }
}
