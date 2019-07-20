using System.Windows.Controls;

namespace DogsTracker.Interfaces
{
    public interface IOdd
    {
        string Time { get; set; }

        string Game { get; set; }

        string Match { get; set; }        

        string FirstWinChange { get; set; }

        string DrawChange { get; set; }

        string SecondWinChange { get; set; }

        IPrediction Prediction { get; set; }
        
    }
}
