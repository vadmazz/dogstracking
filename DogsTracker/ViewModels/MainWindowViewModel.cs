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
        public ICommand ExitCommand { get; set; }
        OddsTable oddsTable;
        public ObservableCollection<IOdd> Odds => oddsTable.Odds;


        public MainWindowViewModel()
        {
            oddsTable = new OddsTable();
            RefreshCommand = new RelayCommand(Refresh);
            ExitCommand = new RelayCommand(Close);
            oddsTable.PropertyChanged += (s, e) => { OnPropertyChanged(e.PropertyName); };
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        //вынести в модель
        public void Refresh(object parametr)
        {
            oddsTable = new OddsTable();
            oddsTable.ParseOdds(new object());
            OnPropertyChanged("Odds");
        }

        public void Close(object parametr)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
