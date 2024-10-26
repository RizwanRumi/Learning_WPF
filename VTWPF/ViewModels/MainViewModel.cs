using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VTWPF.Models;
using VTWPF.MVVM;

namespace VTWPF.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ToleranceData> ToleranceDataList { get; set; }
        public ObservableCollection<MeritFunctionData> MeritFunctionDataList { get; set; }
        public ObservableCollection<SenseTableData> SenseTableDataList { get; set; }


        public ObservableCollection<ToleranceData> SelectedToleranceDataList { get; set; }
        public ObservableCollection<MeritFunctionData> SelectedMeritFunctionDataList { get; set; }

        public ICommand ComputeCommand { get; }

        public MainViewModel()
        {
            ToleranceDataList = new ObservableCollection<ToleranceData>();
            MeritFunctionDataList = new ObservableCollection<MeritFunctionData>();
            SenseTableDataList = new ObservableCollection<SenseTableData>();
            SelectedToleranceDataList = new ObservableCollection<ToleranceData>();
            SelectedMeritFunctionDataList = new ObservableCollection<MeritFunctionData>();

            ComputeCommand = new RelayCommand(Compute, CanCompute);

            LoadData();

            // Subscribe to property changed events for each ToleranceData item
            foreach (var item in ToleranceDataList)
            {
                item.PropertyChanged += OnToleranceData_PropertyChanged;
            }

            // Subscribe to property changed events for each MeritFunctionData item
            foreach (var item in MeritFunctionDataList)
            {
                item.PropertyChanged += OnMeritFunctionData_PropertyChanged;
            }

            SelectAllRowsInitially();
        }

        private void LoadData()
        {
            // Add sample data to ToleranceDataList
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 1, Type = "TWAV", Int1 = 4, Int2 = 0, Int3 = 0, VarMin = "0.546", VarMax = "", Comment = "" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = true, Nr = 2, Type = "TOFF", Int1 = 4, Int2 = -6, Int3 = 6, VarMin = "Symm.", VarMax = "", Comment = "" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 3, Type = "TFRN", Int1 = 5, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 3/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = true, Nr = 4, Type = "AXSE", Int1 = 7, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 4/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 5, Type = "BEFD", Int1 = 8, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 5/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 6, Type = "CHGG", Int1 = 9, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 6/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 7, Type = "DFFF", Int1 = 10, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 7/ Power" });
            ToleranceDataList.Add(new ToleranceData { IsSelected = false, Nr = 8, Type = "EEEE", Int1 = 11, Int2 = -6, Int3 = 6, VarMin = "", VarMax = "", Comment = "Passe 8/ Power" });
            // Add additional sample data here...

            // Add sample data to MeritFunctionDataList
            MeritFunctionDataList.Add(new MeritFunctionData { IsSelected = true, Nr = 1, Type = "CONF", Param1 = "1", Param2 = "", Param3 = "", Param4 = "", Param5 = "", Target = "0", Weight = "0" });
            MeritFunctionDataList.Add(new MeritFunctionData { IsSelected = false, Nr = 2, Type = "BLNK", Param1 = "EFFL", Param2 = "1", Param3 = "1", Param4 = "0", Param5 = "0", Target = "0", Weight = "0" });
            MeritFunctionDataList.Add(new MeritFunctionData { IsSelected = true, Nr = 3, Type = "ZERN", Param1 = "EFFL", Param2 = "2", Param3 = "2", Param4 = "0", Param5 = "0", Target = "0", Weight = "0" });
            MeritFunctionDataList.Add(new MeritFunctionData { IsSelected = true, Nr = 4, Type = "TRRR", Param1 = "EFFL", Param2 = "3", Param3 = "1", Param4 = "0", Param5 = "0", Target = "0", Weight = "0" });
            MeritFunctionDataList.Add(new MeritFunctionData { IsSelected = false, Nr = 5, Type = "AAAA", Param1 = "EFFL", Param2 = "4", Param3 = "2", Param4 = "0", Param5 = "0", Target = "0", Weight = "0" });
            MeritFunctionDataList.Add(new MeritFunctionData { IsSelected = false, Nr = 6, Type = "SSSS", Param1 = "EFFL", Param2 = "5", Param3 = "1", Param4 = "0", Param5 = "0", Target = "0", Weight = "0" });
            MeritFunctionDataList.Add(new MeritFunctionData { IsSelected = true, Nr = 7, Type = "WWWW", Param1 = "EFFL", Param2 = "6", Param3 = "3", Param4 = "0", Param5 = "0", Target = "0", Weight = "0" });
            // Add additional sample data here...

        }

       
        private void SelectAllRowsInitially()
        {
            // Add initially selected items to SelectedToleranceDataList
            //foreach (var item in ToleranceDataList)
            //{
            //    if (item.IsSelected)
            //    {                    
            //        SelectedToleranceDataList.Add(item);                    
            //    }
            //}

            SelectedToleranceDataList = new ObservableCollection<ToleranceData>(ToleranceDataList.Where(t => t.IsSelected).ToList());
            var list = ToleranceDataList.Where(t => t.IsSelected);

            // Add initially selected items to MeritFunctionDataList
            //foreach (var item in MeritFunctionDataList)
            //{
            //    if (item.IsSelected)
            //    {
            //        SelectedMeritFunctionDataList.Add(item);
            //    }
            //}

            SelectedMeritFunctionDataList = new ObservableCollection<MeritFunctionData>(MeritFunctionDataList.Where(t => t.IsSelected).ToList());
        }

        private void OnToleranceData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
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

                //((RelayCommand)ComputeCommand).RaiseCanExecuteChanged();
            }
        }

        private void OnMeritFunctionData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                var meritFunctionData = sender as MeritFunctionData;
                if (meritFunctionData != null)
                {
                    if (meritFunctionData.IsSelected)
                    {
                        // Add to selected list if checked
                        if (!SelectedMeritFunctionDataList.Contains(meritFunctionData))
                        {
                            SelectedMeritFunctionDataList.Add(meritFunctionData);
                        }
                    }
                    else
                    {
                        // Remove from selected list if unchecked
                        if (SelectedMeritFunctionDataList.Contains(meritFunctionData))
                        {
                            SelectedMeritFunctionDataList.Remove(meritFunctionData);
                        }
                    }
                }

                //((RelayCommand)ComputeCommand).RaiseCanExecuteChanged();
            }
        }

        private void Compute(object parameter)
        {
            var selectedMeritData = MeritFunctionDataList.Where(m => m.IsSelected);

            SenseTableDataList.Clear();
            foreach (var tol in SelectedToleranceDataList)
            {
                foreach (var merit in selectedMeritData)
                {
                    SenseTableDataList.Add(new SenseTableData
                    {
                        Property = $"{tol.Type}-{merit.Type}",
                        ComputedValue = tol.Int1 + tol.Int2 + tol.Int3 // Replace with actual computation logic
                    });
                }
            }
        }

        private bool CanCompute(object parameter)
        {
            // Enable button only if both selected lists contain items
            return SelectedToleranceDataList.Any() && MeritFunctionDataList.Any();
        }
    }

}
