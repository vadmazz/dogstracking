using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
namespace DogsTracker.Models
{
    class WindowManager : INotifyPropertyChanged
    {
        private Visibility settingsVisiblity = Visibility.Hidden;
        public Visibility SettingsVisibility {
            get { return settingsVisiblity; }
            set
            {
                settingsVisiblity = value;
                OnPropertyChanged("SettingsVisibility");
            }
        }

        public void Close(object parametr)
        {
            Application.Current.MainWindow.Close();
        }        

        public void SettingsShow(object par)
        {
            if (SettingsVisibility == Visibility.Hidden)
                SettingsVisibility = Visibility.Visible;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
