using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DogsTracker.Models
{
    class WindowManager : INotifyPropertyChanged
    {
        private Visibility oddsVisiblity = Visibility.Visible;
        public Visibility OddsVisibility
        {
            get { return oddsVisiblity; }
            set
            {
                oddsVisiblity = value;
                OnPropertyChanged("OddsVisibility");
            }
        }

        private Visibility settingsVisiblity = Visibility.Hidden;
        public Visibility SettingsVisibility {
            get { return settingsVisiblity; }
            set
            {
                settingsVisiblity = value;
                OnPropertyChanged("SettingsVisibility");
            }
        }

        private Visibility helpVisiblity = Visibility.Hidden;
        public Visibility HelpVisibility
        {
            get { return helpVisiblity; }
            set
            {
                helpVisiblity = value;
                OnPropertyChanged("HelpVisibility");
            }
        }

        private bool isDarkModeEnabled = true; 
        public bool IsDarkModeEnabled
        {
            get { return isDarkModeEnabled; }
            set //логика смены темного и светлого режимов статическими метода класса Theme
            {
                isDarkModeEnabled = value;
                if (value)
                    Theme.SetDarkTheme();
                else
                    Theme.SetLightTheme();
                OnPropertyChanged("IsDarkModeEnabled");
            }
        }

        public string HelpText { get; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,\n" +
            " sed do eiusmod tempor incididunt ut labore et dolore\n" +
            " magna aliqua. Ut enim ad minim veniam, quis nostrud\n" +
            " exercitation ullamco laboris nisi ut aliquip ex ea\n" +
            " commodo consequat. Duis aute irure dolor in reprehenderit in\n" +
            " voluptate velit esse cillum dolore eu" +
            " fugiat nulla pariatur. Excepteur sint occaecat cupidatat\n" +
            " non proident, sunt in culpa qui officia deserunt mollit\n" +
            " anim id est laborum.";
        /// <summary>
        /// Закрыть приложение
        /// </summary>
        /// <param name="parametr"></param>
        public void Close(object parametr)
        {
            Application.Current.MainWindow.Close();
        }        
        /// <summary>
        /// Отобразить окно настроек
        /// </summary>
        /// <param name="par"></param>
        public void ShowSettingsWindow(object par)
        {
            if (SettingsVisibility == Visibility.Hidden)
            {
                HideAllWindows();
                SettingsVisibility = Visibility.Visible;
            }
        }

        public void ShowOddsWindow(object par)
        {
            if (OddsVisibility == Visibility.Hidden)
            {
                HideAllWindows();
                OddsVisibility = Visibility.Visible;
            }
        }

        public void ShowHelpWindow(object par)
        {
            if (HelpVisibility == Visibility.Hidden)
            {
                HideAllWindows();
                HelpVisibility = Visibility.Visible;
            }                
        }
        public void HideAllWindows()
        {
            OddsVisibility = Visibility.Hidden;
            HelpVisibility = Visibility.Hidden;
            SettingsVisibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
