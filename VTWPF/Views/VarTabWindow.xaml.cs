using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VTWPF.ViewModels;

namespace VTWPF.Views
{
    /// <summary>
    /// Interaction logic for VarTabWindow.xaml
    /// </summary>
    public partial class VarTabWindow : Window
    {
        public VarTabWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void SelectCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SetCheckedForSelected((FrameworkElement)sender, true);
        }       

        private void SelectCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SetCheckedForSelected((FrameworkElement)sender, false);
        }

        private static void SetCheckedForSelected(FrameworkElement sender, bool isChecked)
        {
            var dataGrid = (DataGrid)(sender).Tag;

            // code implement.... 
        }
    }
}
