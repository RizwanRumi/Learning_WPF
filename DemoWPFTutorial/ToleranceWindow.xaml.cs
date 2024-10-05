using DemoWPFTutorial.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ObservableCollection<ToleranceData> SelectedToleranceDataList { get; set; }
        public ObservableCollection<MeritFunctionData> MeritFunctionDataList { get; set; }

        public ToleranceWindow()
        {
            InitializeComponent();

            // Initialize collections
            ToleranceDataList = new ObservableCollection<ToleranceData>();
            SelectedToleranceDataList = new ObservableCollection<ToleranceData>();
            MeritFunctionDataList = new ObservableCollection<MeritFunctionData>();

            // Bind the DataContext to this window
            DataContext = this;

            // Load sample data
            LoadData();

            // Subscribe to the property changed event for each item
            foreach (var item in ToleranceDataList)
            {
                item.PropertyChanged += ToleranceData_PropertyChanged;
            }

            //
            SelectAllRowsInitially();
        }

        private void SelectAllRowsInitially()
        {
            foreach (var item in ToleranceDataList)
            {
                if (item.IsSelected)
                {
                    SelectedToleranceDataList.Add(item);
                }
            }
        }

        private void LoadData()
        {
            // Add sample data to ToleranceDataList
            ToleranceDataList.Add(new ToleranceData { IsSelected = true, Nr = 1, Type = "TWAV", Int1 = 4, Int2 = 0, Int3 = 0, VarMin = "0.546", VarMax = "", Comment = "" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 2, Type = "TOFF", Int1 = 4, Int2 = -6, Int3 = 6, VarMin = "Symm.", VarMax = "", Comment = "" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = true, Nr = 3, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 4, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 5, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 6, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 7, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 8, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 9, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 10, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 11, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 12, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });

            // Add sample data to MeritFunctionDataList
            MeritFunctionDataList.Add(new MeritFunctionData { Show = true, Nr = 1, Type = "CONF", Param1 = "1", Param2 = "", Param3 = "", Param4 = "", Param5 = "", Target = "0", Weight = "0" });
            MeritFunctionDataList.Add(new MeritFunctionData { Show = false, Nr = 2, Type = "BLNK", Param1 = "EFFL", Param2 = "1", Param3 = "1", Param4 = "0", Param5 = "0", Target = "0", Weight = "0" });
        }

        // Event handler to detect changes in the IsSelected property
        private void ToleranceData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                var toleranceData = sender as ToleranceData;
                if (toleranceData != null)
                {
                    if (toleranceData.IsSelected)
                    {
                        // Add to selected list if checked
                        if (!SelectedToleranceDataList.Contains(toleranceData))
                        {
                            SelectedToleranceDataList.Add(toleranceData);
                        }
                    }
                    else
                    {
                        // Remove from selected list if unchecked
                        if (SelectedToleranceDataList.Contains(toleranceData))
                        {
                            SelectedToleranceDataList.Remove(toleranceData);
                        }
                    }
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var list = SelectedToleranceDataList.ToList();
            var test = 1; 
        }
    }
}
