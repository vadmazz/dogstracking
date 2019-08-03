using DogsTracker.Interfaces;
using DogsTracker.Models;
using DogsTracker.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace DogsTracker.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string HelpText => windowManager.HelpText; //текст, отображающийся в окне помощи

        public ICommand RefreshCommand { get; private set; }

        public ICommand ExitCommand { get; private set; }

        public ICommand SettingsShowCommand { get; private set; }

        public ICommand HelpShowCommand { get; private set; }

        public OddsTable oddsTable;

        WindowManager windowManager;

        public ObservableCollection<IOdd> Odds => oddsTable.Odds;

        public Visibility OddsVisibility => windowManager.OddsVisibility;

        public Visibility SettingsVisibility => windowManager.SettingsVisibility;

        public Visibility HelpVisibility => windowManager.HelpVisibility;       

        public bool IsDarkModeEnabled
        {
            get { return windowManager.IsDarkModeEnabled; }
            set { windowManager.IsDarkModeEnabled = value; }
        }

        public MainWindowViewModel()
        {
            oddsTable = new OddsTable();
            windowManager = new WindowManager();
            RefreshCommand = new RelayCommand(Refresh);
            ExitCommand = new RelayCommand(windowManager.Close);
            SettingsShowCommand = new RelayCommand(windowManager.ShowSettingsWindow);
            HelpShowCommand = new RelayCommand(windowManager.ShowHelpWindow);

            oddsTable.PropertyChanged += (s, e) => { OnPropertyChanged(e.PropertyName); };
            windowManager.PropertyChanged += (s, e) => { OnPropertyChanged(e.PropertyName); };
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void Refresh(object parameter)
        {
            oddsTable = new OddsTable();
            windowManager.ShowOddsWindow(null);
            OnPropertyChanged("Odds");
        }
    }
}