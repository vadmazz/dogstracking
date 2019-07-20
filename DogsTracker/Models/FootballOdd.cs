using DogsTracker.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DogsTracker.Models
{
    class FootballOdd : IOdd, INotifyPropertyChanged
    {
        public string Time { get; set; }

        public string Match { get; set; }

        public string Game { get; set; }

        public string FirstWinChange { get; set; }

        public string DrawChange { get; set; }

        public string SecondWinChange { get; set; }

        public IPrediction Prediction { get; set; }

        public FootballOdd(string t, string m, string f, string d, string s, IPrediction p)
        {
            Time = t;
            Game = "Football";
            Match = m;
            FirstWinChange = f;
            DrawChange = d;
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
