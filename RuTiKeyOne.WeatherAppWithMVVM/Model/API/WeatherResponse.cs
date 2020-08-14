namespace RuTiKeyOne.WeatherAppWithMVVM.Model.API
{
    //Helper class
    class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }

        public WindInfo Wind { get; set; }
        public string Name { get; set; }
    }
}
