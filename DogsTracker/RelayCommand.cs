using System;
using System.Windows.Input;

namespace DogsTracker
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Func<object, bool> canExecute;

        private readonly Action<object> onExecute;

        //---Конструкторы
        public RelayCommand(Action<object> execute)
        {
            this.onExecute = execute;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.onExecute = execute;
        }
        //---

        public bool CanExecute(object parameter)
        {
            if (canExecute == null || canExecute(parameter))
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            if (onExecute != null)
            {
                onExecute(parameter);                
            }
            
        }
    }
}
