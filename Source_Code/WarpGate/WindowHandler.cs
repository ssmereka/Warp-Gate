using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;  //Needed for Window Handler DLL references

namespace WarpGate
{
    class WindowHandler
    {
       #region /* Private Class Variables */
        private const int WM_CLOSE = 0x0010;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
       #endregion

        [DllImport("user32.dll")]  // Send a Windows Message
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")] // Get the foreground window, returns window handle
        private static extern int GetForegroundWindow();

        [DllImport("user32")]  //Show a window, parameters windowhandle & parameter to set a special state
        private static extern int ShowWindow(int hwnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]  //Find window by caption
        static extern Int32 FindWindowByCaption(int lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(int hWnd); //Set window to foreground

        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public void SetForegroundWnd(IntPtr hWnd) 
        {
            SetForegroundWindow(hWnd);
        }

        public void SetForegroundWnd2(Int32 handle) //int handle 
        {
            SetForegroundWindow(handle);
        }

        public Int32 FindWindowByCaption(String caption) 
        {
            return FindWindowByCaption(0, caption);  //send 0 only for lp class name
        }

        public Int32 GetWnd(string processName) //Get the window for a special process, parameter name of process, returns Process-Handle 
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
                throw new ArgumentException("Process with name " + processName +
                    " not running!");
            return processes[0].MainWindowHandle.ToInt32();
        }

        public Int32 GetForegroundWnd() //Get the windowhandle of the window in the foreground, return windowhandle 
        {
            return GetForegroundWindow();
        }

        public void Close(Int32 handle) //Close the main window of a process 
        {
            SendMessage(handle, WM_CLOSE, 0, 0);
        }

        public void Minimize(Int32 handle) //Minimize the window, paramter window handle 
        {
            ShowWindow(handle, SW_SHOWMINIMIZED);
        }

        public void Maximize(Int32 handle) //Maximize the window, parameter windowhandle 
        {
            ShowWindow(handle, SW_SHOWMAXIMIZED);
        }

        public void Normalize(Int32 handle) //Normalize the window, parameter window handle 
        {
            ShowWindow(handle, SW_SHOWNORMAL);
        }

    }
}
