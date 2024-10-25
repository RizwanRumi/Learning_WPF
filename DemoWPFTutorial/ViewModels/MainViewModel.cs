using DemoWPFTutorial.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoWPFTutorial.ViewModels
{
    // This example is to understand how a button works as a command and how to implement RelayCommand class 
    public class MainViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged(); // Notify UI of property change
                }
            }
        }
        public ICommand MyCommand { get; }
        private bool canExecuteCommand;

        public MainViewModel()
        {
            canExecuteCommand = true; // Default condition
            Message = "Hello! I am a TextBlock."; // Initial message for the TextBlock
            MyCommand = new RelayCommand(ExecuteMyCommand, CanExecuteMyCommand);
        }

        private void ExecuteMyCommand(object parameter)
        {
            // Update Message when command is executed
            Message = "Command Executed!";
            OnPropertyChanged(); // Notify UI of change

            // Toggle canExecuteCommand condition (for demonstration purposes)
            canExecuteCommand = !canExecuteCommand;
            ((RelayCommand)MyCommand).RaiseCanExecuteChanged(); // Notify that CanExecute changed
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            // Determine if command can execute based on state
            return canExecuteCommand;
        }

    }
}
