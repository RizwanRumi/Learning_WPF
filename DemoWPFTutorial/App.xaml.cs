using System.Configuration;
using System.Data;
using System.Windows;

namespace DemoWPFTutorial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Create the startup window
            //MainWindow wnd = new MainWindow();
            TestDataBindingWindow wnd = new TestDataBindingWindow();
            // Do stuff here, e.g. to the window
            wnd.Title = "Demo WPF :)";
            // Show the window
            wnd.Show();

            //TestPage testPage = new TestPage();
            //testPage.ShowsNavigationUI = true;
        }
    }

}
