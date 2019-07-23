using DogsTracker.Interfaces;
using DogsTracker.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DogsTracker.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        OddsTable oddsTable;
        public ObservableCollection<IOdd> Odds => oddsTable.Odds;


        public MainWindowViewModel()
        {
            oddsTable = new OddsTable();            
            oddsTable.PropertyChanged += (s, e) => { OnPropertyChanged(e.PropertyName); };
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
