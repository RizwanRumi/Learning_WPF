using System.Windows;
using DemoWPFTutorial.ViewModels;
namespace DemoWPFTutorial
{
    /// <summary>
    /// Interaction logic for ButtonWindow.xaml
    /// </summary>
    public partial class ButtonWindow : Window
    {
        public ButtonWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
