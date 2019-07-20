using DogsTracker.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace DogsTracker.Models
{
    class TennisOdd : IOdd, INotifyPropertyChanged
    {
        public string Time { get; set; }

        public string Match { get; set; }

        public string Game { get; set; }

        public string FirstWinChange { get; set; }

        public string DrawChange { get; set; }

        public string SecondWinChange { get; set; }

        public IPrediction Prediction { get; set; }        

        public TennisOdd(string t, string m, string f, string s, IPrediction p)
        {
            Time = t;
            Game = "Tennis";
            Match = m;
            FirstWinChange = f;
            DrawChange = "-";
            SecondWinChange = s;
            Prediction = p;            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
