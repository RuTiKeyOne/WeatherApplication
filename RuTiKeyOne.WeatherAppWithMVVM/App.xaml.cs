using RuTiKeyOne.WeatherAppWithMVVM.Model;
using RuTiKeyOne.WeatherAppWithMVVM.View;
using RuTiKeyOne.WeatherAppWithMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RuTiKeyOne.WeatherAppWithMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
   public partial class App : Application
    {
        internal DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        MainViewModel mainWindowViewModel;

        public App()
        {
            displayRootRegistry.RegisterWindowType<MainViewModel, MainWindow>();
            displayRootRegistry.RegisterWindowType<DataViewModel, DataWindow>();
            displayRootRegistry.RegisterWindowType<MessageViewModel, MessageWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mainWindowViewModel = new MainViewModel();

            await displayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}
