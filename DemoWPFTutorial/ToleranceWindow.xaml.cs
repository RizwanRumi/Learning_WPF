using DemoWPFTutorial.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DemoWPFTutorial
{
    /// <summary>
    /// Interaction logic for ToleranceWindow.xaml
    /// </summary>
    public partial class ToleranceWindow : Window
    {
        public ObservableCollection<ToleranceData> ToleranceDataList { get; set; }
        public ObservableCollection<MeritFunctionData> MeritFunctionDataList { get; set; }

        public ToleranceWindow()
        {
            InitializeComponent();

            // Initialize collections
            ToleranceDataList = new ObservableCollection<ToleranceData>();
            MeritFunctionDataList = new ObservableCollection<MeritFunctionData>();

            // Bind the DataContext to this window
            this.DataContext = this;

            // Load sample data
            LoadData();
        }

        private void LoadData()
        {
            // Add sample data to ToleranceDataList
            ToleranceDataList.Add(new ToleranceData { IsSelected = true, Nr = 1, Type = "TWAV", Int1 = 4, Int2 = 0, Int3 = 0, VarMin = "0.546", VarMax = "", Comment = "" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 2, Type = "TOFF", Int1 = 4, Int2 = -6, Int3 = 6, VarMin = "Symm.", VarMax = "", Comment = "" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = true, Nr = 3, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });

            // Add sample data to MeritFunctionDataList
            MeritFunctionDataList.Add(new MeritFunctionData { Show = true, Nr = 1, Type = "CONF", Param1 = "1", Param2 = "", Param3 = "", Param4 = "", Param5 = "", Target = "0", Weight = "0" });
            MeritFunctionDataList.Add(new MeritFunctionData { Show = false, Nr = 2, Type = "BLNK", Param1 = "EFFL", Param2 = "1", Param3 = "1", Param4 = "0", Param5 = "0", Target = "0", Weight = "0" });
        }
    }
}
