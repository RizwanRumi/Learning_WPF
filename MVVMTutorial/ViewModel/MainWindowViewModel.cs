using MVVMTutorial.Model;
using MVVMTutorial.MVVM;
using System.Collections.ObjectModel;

namespace MVVMTutorial.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItem(), canExecute => CanSave());


        public MainWindowViewModel() 
        {
            Items = new ObservableCollection<Item>();
            //Items.Add(new Item
            //{
            //    Name = "Product1",
            //    SerialNumber = "0001",
            //    Quantity = 5
            //});
            //Items.Add(new Item
            //{
            //    Name = "Product2",
            //    SerialNumber = "0002",
            //    Quantity = 10
            //});
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

        private void AddItem()
        {
            Items.Add(new Item
            {
                Name = "NEW ITEM",
                SerialNumber = "XXXXX",
                Quantity = 0
            });
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }

        private void SaveItem()
        {
            //save to file / database
        }

        private bool CanSave()
        {
            // db connection permition
            return true;
        }
    }
}
