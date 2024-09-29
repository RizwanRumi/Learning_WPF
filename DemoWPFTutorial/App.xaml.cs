﻿using System.Configuration;
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
            // Create the startup window
            MainWindow wnd = new MainWindow();
            // Do stuff here, e.g. to the window
            wnd.Title = "Demo WPF :)";
            // Show the window
            wnd.Show();            
        }
    }

}
