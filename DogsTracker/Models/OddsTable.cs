using AngleSharp;
using DogsTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DogsTracker.Models
{
    class OddsTable : INotifyPropertyChanged
    {        
        private List<AngleSharp.Dom.IElement> Dates = new List<AngleSharp.Dom.IElement>();
        private List<AngleSharp.Dom.IElement> Matches = new List<AngleSharp.Dom.IElement>();
        private List<string> OddsChanges;

        private readonly ObservableCollection<IOdd> odds = new ObservableCollection<IOdd>();
        public ObservableCollection<IOdd> Odds
        {
            get
            {
                return odds;
            }
        }       

        private async void ParseOdds()
        {
            //Настраиваем AngleSharp
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://hot-odds.com/DroppingOdds";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            // Парсим таблицу
            Dates = document.QuerySelectorAll("td.cell-date").ToList();
            Matches = document.QuerySelectorAll("a.eventlink").ToList();
            var div1 = document.QuerySelectorAll("td.responsive.odds-container");
            OddsChanges = new List<string>();// массив всех изменений (кол-во ставок x3)

            //Заполняем массив с изменениями OddsChanges
            foreach (var item in div1)
            {
                try
                {
                    //Убираем ненужные символы после парса
                    var regexObj = new Regex(@"\n\t\t\t(.+?)\n\t\t\t\n");
                    var match = regexObj.Match(item.QuerySelector("div.odds>div.value").TextContent).Groups[1];
                    OddsChanges.Add(match.Value);
                }
                catch (NullReferenceException)
                {
                    OddsChanges.Add("null");
                    continue;
                }
            }

            //Заполняем массив Odds объектами TennisOdd и FootballOdd
            for (int i = 0; i < Dates.Count; i++)
            {
                if (OddsChanges[i * 3 + 1] == "null")
                {
                    AddOdd(new TennisOdd(Dates[i].TextContent,
                       Matches[i].TextContent,
                       OddsChanges[i * 3],
                       OddsChanges[i * 3 + 2],
                       new TennisPrediction(1.0, 1.0)));
                }
                else
                {
                    AddOdd(new FootballOdd(Dates[i].TextContent,
                    Matches[i].TextContent,
                    OddsChanges[i * 3],
                    OddsChanges[i * 3 + 1],
                    OddsChanges[i * 3 + 2],
                    new FootballPrediction(1.0, 1.0, 1.0)));
                }
            }
        }

        public OddsTable()
        {
            //Парсим наши ставки в массивы Dates, Matches, OddsChanges
            ParseOdds();            
        }

        public void AddOdd(IOdd odd)
        {
            odds.Add(odd);
            OnPropertyChanged("Odds");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
