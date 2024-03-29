﻿//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III
{
    using System;
    using System.Windows.Forms;
    using Utils.Configuration;

    /// <summary>
    /// Program Class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Parameter.Initializer(Application.StartupPath);
            
            Application.Run(new MainForm());

            // Application.Run(new Form1());
        }
    }
}
