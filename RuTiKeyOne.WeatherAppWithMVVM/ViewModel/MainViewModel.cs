using GalaSoft.MvvmLight.Command;
using RuTiKeyOne.WeatherAppWithMVVM.Model;
using System.Windows;
using System.Windows.Input;
using RuTiKeyOne.WeatherAppWithMVVM.Model.API;
using RuTiKeyOne.WeatherAppWithMVVM.ViewModel.Base;

namespace RuTiKeyOne.WeatherAppWithMVVM.ViewModel
{
    class MainViewModel : BaseViewModel, CloseWindow
    {
        //Name Location help get location user

        #region Name Location
        private string nameLocation = null;

        public string NameLocation
        {
            get => nameLocation;
            set => SetProperty(ref nameLocation, value);
        }
        #endregion

        //Constructor passes command parameters 
        #region Ctor
        public MainViewModel()
        {
            ClearCommand = new ActionCommand(OnClearCommandExecute, CanClearCommandExecute);
            this.CloseMainCommand = new RelayCommand<Window>(this.CloseWindow);
        }

        #endregion

        //Command implementation clear

        #region Clear Command
        public ICommand ClearCommand { get; set; }

        public bool CanClearCommandExecute(object parameter) => true;
        public void OnClearCommandExecute(object parameter)
        {
            switch(NameLocation != null)
            {
                case true:
                    NameLocation = null;
                    OnPropertyChanged(NameLocation);
                    break;
                case false:
                    var DisplayRootRegistry = (Application.Current as App).displayRootRegistry;
                    var Message = new MessageViewModel("Fill in the field");
                    DisplayRootRegistry.ShowPresentation(Message);
                    break;
            }
        }
        #endregion

        //Window close implementation

        #region Close window
        public RelayCommand<Window> CloseMainCommand { get; private set; }
        public void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        #endregion


        //Command implementation open data window 

        #region Command open data window
        private ICommand _openChildWindow;
        public ICommand OpenChildWindow
        {
            get
            {
                if (_openChildWindow == null)
                {
                    _openChildWindow = new OpenChildWindowCommand(this);
                }
                return _openChildWindow;
            }
        }
        #endregion

    }

    //The helper class OpenChildWindowCommand inherits from MyCommand and helps to implement the opening of a new window
    #region Open child window command 
    class OpenChildWindowCommand : MyCommand
    {
        public OpenChildWindowCommand(MainViewModel mainWindowVeiwModel) : base(mainWindowVeiwModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
               if (parameter != null && parameter != string.Empty)
               {
                   switch (InternetConnection.CheckInternetConnection())
                   {
                       case true:
                           if (JsonWeatherApi.CreateJsonRequest((string)parameter))
                           {
                               var DisplayRootRegistryTry = (Application.Current as App).displayRootRegistry;
                               var DataTry = new DataViewModel();
                               DisplayRootRegistryTry.ShowPresentation(DataTry);
                           }
                           else
                           {
                               var DisplayRootRegistryError = (Application.Current as App).displayRootRegistry;
                               var Message404 = new MessageViewModel("Not Found");
                               DisplayRootRegistryError.ShowPresentation(Message404);
                           }
                           break;
                       case false:
                           var DisplayRootRegistryFalse = (Application.Current as App).displayRootRegistry;
                           var DataFalse = new MessageViewModel("Check your internet connection");
                           DisplayRootRegistryFalse.ShowPresentation(DataFalse);
                           break;
                   }
               }
               else
               {
                   var DisplayRootRegistryFalse = (Application.Current as App).displayRootRegistry;
                   var DataFalse = new MessageViewModel("Fill in the field");
                   DisplayRootRegistryFalse.ShowPresentation(DataFalse);
               }
        }
    }
    #endregion
}
