using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace RuTiKeyOne.WeatherAppWithMVVM.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {
        //Interface implementation INotifyPropertyChanged
        protected bool SetProperty<T>(ref T field, T value, string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
