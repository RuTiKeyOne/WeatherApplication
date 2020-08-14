using GalaSoft.MvvmLight.CommandWpf;
using RuTiKeyOne.WeatherAppWithMVVM.ViewModel.Base;
using System.ComponentModel;
using System.Windows;

namespace RuTiKeyOne.WeatherAppWithMVVM.ViewModel
{
    class MessageViewModel : BaseViewModel ,INotifyPropertyChanged, CloseWindow
    {
        //MessageError helps to determine the name of the error and display

        #region Message error
        private string messageError;
        public string MessageError
        {
            get => messageError;
            set
            {
                messageError = value;
                OnPropertyChanged(MessageError);
            }
        }
        #endregion

        #region Simple constructor
        public MessageViewModel(string message)
        {
            MessageError = message;

            this.CloseMessageCommand = new RelayCommand<Window>(this.CloseWindow);
        }
        #endregion

        //Window close implementation

        #region Close message command
        public RelayCommand<Window> CloseMessageCommand { get; private set; }

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
