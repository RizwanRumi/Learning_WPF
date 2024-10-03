using MVVMTutorial.Model;
using MVVMTutorial.MVVM;
using System.Collections.ObjectModel;

namespace MVVMTutorial.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }
        public MainWindowViewModel() 
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item
            {
                Name = "Product1",
                SerialNumber = "0001",
                Quantity = 5
            });
            Items.Add(new Item
            {
                Name = "Product2",
                SerialNumber = "0002",
                Quantity = 10
            });
        }

        private Item selectedItem;
                
        public Item SelectedItem
        {
            get { return selectedItem; }
            set 
            { 
                selectedItem = value;
                OnPropertyChanged();
            }
        }
    }
}
