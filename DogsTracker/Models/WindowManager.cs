using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

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

        private bool isDarkModeEnabled = true;
        public bool IsDarkModeEnabled
        {
            get { return isDarkModeEnabled; }
            set
            {
                isDarkModeEnabled = value;
                if (value)
                    Theme.SetDarkTheme();
                else
                    Theme.SetLightTheme();
                OnPropertyChanged("IsDarkModeEnabled");
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

        public void SetColorScheme(object parameter)
        {
            if (isDarkModeEnabled)
                isDarkModeEnabled = false;
            else
                isDarkModeEnabled = true;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
