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

        public ICommand RefreshCommand { get; private set; }

        public ICommand ExitCommand { get; private set; }

        public ICommand SettingsCommand { get; private set; }

        public OddsTable oddsTable;

        WindowManager windowManager;

        public ObservableCollection<IOdd> Odds => oddsTable.Odds;

        public Visibility SettingsVisibility => windowManager.SettingsVisibility;

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
            SettingsCommand = new RelayCommand(windowManager.SettingsShow);

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
            OnPropertyChanged("Odds");
        }
    }
}