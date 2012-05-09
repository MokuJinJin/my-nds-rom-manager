//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2012
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III.WPF_UI
{
    using BusinessService;
    using Utils.Configuration;

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            // Parameter.Initializer(@"E:\Games\-=Mes Documents=-\Visual Studio 2010\Projects\my-nds-rom-manager\trunk\NdsCRC III\bin\Debug");
            Parameter.Initializer(Properties.Settings.Default.StartupPath);
            DataContext = new MFControler();
        }
    }
}
