using System;
using System.Windows.Input;
using static System.Windows.Input.CommandManager;

namespace PasswordGenerator
{
    public class RelayCommand: ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;


        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => RequerySuggested += value;
            remove => RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}