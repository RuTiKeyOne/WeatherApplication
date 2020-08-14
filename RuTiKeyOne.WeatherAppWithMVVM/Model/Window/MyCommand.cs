using RuTiKeyOne.WeatherAppWithMVVM.ViewModel;
using System;
using System.Windows.Input;

namespace RuTiKeyOne.WeatherAppWithMVVM.Model
{
    //Create base command 
    abstract class MyCommand : ICommand
    {
        protected MainViewModel _mainWindowVeiwModel;

        public MyCommand(MainViewModel mainWindowVeiwModel)
        {
            _mainWindowVeiwModel = mainWindowVeiwModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
