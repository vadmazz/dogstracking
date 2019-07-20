using DogsTracker.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DogsTracker.Models
{
    class FootballPrediction : IPrediction, INotifyPropertyChanged
    {
        public double FirstWinChance { get; set; }

        public double DrawChance { get; set; }

        public double SecondWinChance { get; set; }

        public FootballPrediction(double first, double draw, double second)
        {
            FirstWinChance = first;
            DrawChance = draw;
            SecondWinChance = second;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
