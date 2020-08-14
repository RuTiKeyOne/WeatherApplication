using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RuTiKeyOne.WeatherAppWithMVVM.ViewModel.Base
{
    interface CloseWindow
    {
        //Create base method
        void CloseWindow(Window window);
    }
}
