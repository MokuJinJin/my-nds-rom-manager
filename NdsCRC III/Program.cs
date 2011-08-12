using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NdsCRC_III
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NDSDirectories.SetStartupPath(Application.StartupPath);
            Application.Run(new MainForm());
            // Application.Run(new Form1());
        }
    }
}
