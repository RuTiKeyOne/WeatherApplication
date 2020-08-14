using GalaSoft.MvvmLight.CommandWpf;
using RuTiKeyOne.WeatherAppWithMVVM.Model.API;
using RuTiKeyOne.WeatherAppWithMVVM.ViewModel.Base;
using System;
using System.Windows;

namespace RuTiKeyOne.WeatherAppWithMVVM.ViewModel
{
    class DataViewModel : CloseWindow
    {
        //Properties displaying weather and location data

        #region Properties
        public string City { get; set; } = JsonWeatherApi.Wr.Name;

        public string Temperature { get; set; } = $"{Math.Round(JsonWeatherApi.Wr.Main.Temp, 0)} °С ";

        public string Humindity { get; set; } = $"{JsonWeatherApi.Wr.Main.Humidity} %";

        public string Pressure { get; set; } = JsonWeatherApi.Wr.Main.Pressure;

        public string WindSpeed { get; set; } = $"{Math.Round(JsonWeatherApi.Wr.Wind.Speed,1)} m/s";

        #endregion

        #region Simple constructor
        public DataViewModel()
        {
            this.CloseDataCommand = new RelayCommand<Window>(this.CloseWindow);
        }
        #endregion

        //Window close implementation

        #region Close data command
        public RelayCommand<Window> CloseDataCommand { get; private set; }


        public void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        #endregion
    }
}
