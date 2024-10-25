using System.Configuration;
using System.Data;
using System.Windows;

namespace VTWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Create the startup window

            //Main windown
           MainWindow maiWindow = new MainWindow();
            // Do stuff here, e.g. to the window
            maiWindow.Title = "Demo VarTab Tutorial";
            // Show the window
            maiWindow.Show();
        }
    }

}
