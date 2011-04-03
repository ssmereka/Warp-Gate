using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WarpGate
{
    class ThirdPartyPrograms
    {
        //Install hamachi
        //Install ForcebindIP
        //Install Starcraft
        //Install Starcraft no cd hack
        
        
        /*
        private void InstallFBIP()
        {/* Pre:  Operating system defined
          * 
          * Post: If not already installed, ForceBindIP is installed and configured 
            if (!File.Exists(Windows_x32 + FBIP_EXE))
            {
                Launcher LaFBIP = new Launcher();
                Thread FBIP = new Thread(LaFBIP.StartFBIP);
                FBIP.Start(); //Launch ForceBindIP Installer
                FBIP.Join();
                if (CurOST == OST.x64)
                {
                    System.IO.File.Copy(Windows_x64 + FBIP_EXE, Windows_x32 + FBIP_EXE, true);
                    System.IO.File.Copy(Windows_x64 + FBIP_Uninstall, Windows_x32 + FBIP_Uninstall, true);
                }
            }
            else
            {
                MessageBox.Show("ForceBindIP has already been installed");
            }
        }

        private void InstallUpdate()
        {/* Pre: Starcraft is installed
          * 
          * Post: Installs the latest Starcraft Update */

        //Check for latest update
        //Compare to current update
        //Launch install of update
        //InstallUpdate() //check again
        /*
        }

        private void InstallHamachi()
        {/* Pre: 
          * 
          * Post: Installs Hamachi, 
          *        walkthrough on configuration presented */

        /* TODO: Check if already installed 
        Launcher LaHamachi = new Launcher();
        Thread Hamachi = new Thread(LaHamachi.StartHamachi);
        Hamachi.Start(); //Launch Hamachi Installer
    } */
    }
}
