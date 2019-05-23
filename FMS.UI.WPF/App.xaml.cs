using FMS.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FMS.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IKernel kernel = new StandardKernel();

            MainWindow = new MainWindow();
            MainWindow.DataContext = kernel.Get<MainWindowViewModel>();
            MainWindow.Show();
        }
    }
}
