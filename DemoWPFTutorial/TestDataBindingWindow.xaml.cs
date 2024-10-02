using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace DemoWPFTutorial
{
    /// <summary>
    /// Interaction logic for TestDataBindingWindow.xaml
    /// </summary>
    public partial class TestDataBindingWindow : Window, INotifyPropertyChanged
    {
        public TestDataBindingWindow()
        {
            DataContext = this;

            InitializeComponent();
        }

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
        //    {
        //        lstNames.Items.Add(txtName.Text);
        //        txtName.Clear();

        //    }
        //}

        private string boundText = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string BoundText
        {
            get { return boundText; }
            set
            {
                boundText = value;
                OnPropertyOnChanged();
            }
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            BoundText = "Set from Code";
        }

        private void OnPropertyOnChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
