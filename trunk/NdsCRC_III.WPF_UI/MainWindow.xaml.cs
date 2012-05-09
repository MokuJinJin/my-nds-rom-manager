using System.Windows;
using Equin.ApplicationFramework;
using NdsCRC_III.BusinessService;
using NdsCRC_III.TO;
using Utils.Configuration;

namespace NdsCRC_III.WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Parameter.Initializer(@"E:\Games\-=Mes Documents=-\Visual Studio 2010\Projects\my-nds-rom-manager\trunk\NdsCRC III\bin\Debug");
            DataContext = new MFControler();
        }
    }
}
