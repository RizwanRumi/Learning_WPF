using System.Configuration;
using System.Data;
using System.Windows;
using VTWPF.Views;

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
            VarTabWindow varTabWindow = new VarTabWindow();
            // Do stuff here, e.g. to the window
            varTabWindow.Title = "Demo VarTab Tutorial";
            // Show the window
            varTabWindow.Show();
        }
    }

}
