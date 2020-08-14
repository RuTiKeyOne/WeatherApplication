using System;
using System.Windows.Input;

namespace RuTiKeyOne.WeatherAppWithMVVM.Model.Base
{

    //Creating an abstract base class with implementation ICommand
    abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
