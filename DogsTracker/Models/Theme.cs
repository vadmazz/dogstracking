using System.Windows;
using System.Windows.Media;

namespace DogsTracker.Models
{
    public static class Theme
    {
        //------[DarkThemeColors]-----------
        static readonly SolidColorBrush DarkBlueBG = new SolidColorBrush(Color.FromRgb(44, 62, 80));

        static readonly SolidColorBrush DarkHeaderBG = new SolidColorBrush(Color.FromRgb(52, 73, 94));

        static readonly SolidColorBrush DarkLabelForeground = new SolidColorBrush(Color.FromRgb(189, 195, 199));

        static readonly SolidColorBrush DarkContentLabelForeground = new SolidColorBrush(Color.FromRgb(236, 240, 241));
        //----------------------------------
        //------[LightThemeColors]----------
        static readonly SolidColorBrush LightBlueBG = new SolidColorBrush(Color.FromRgb(52, 152, 219));

        static readonly SolidColorBrush LightHeaderBG = new SolidColorBrush(Color.FromRgb(41, 128, 185));

        static readonly SolidColorBrush LightLabelForeground = new SolidColorBrush(Color.FromRgb(236, 240, 241));

        static readonly SolidColorBrush LightContentLabelForeground = new SolidColorBrush(Color.FromRgb(52, 73, 94));
        //----------------------------------

        public static void SetDarkTheme()
        {
            Application.Current.Resources["BG"] = DarkBlueBG;
            Application.Current.Resources["HeaderBG"] = DarkHeaderBG;
            Application.Current.Resources["LabelForeground"] = DarkLabelForeground;
            Application.Current.Resources["ContentLabelForeground"] = DarkContentLabelForeground;
        }

        public static void SetLightTheme()
        {
            Application.Current.Resources["BG"] = LightBlueBG;
            Application.Current.Resources["HeaderBG"] = LightHeaderBG;
            Application.Current.Resources["LabelForeground"] = LightLabelForeground;
            Application.Current.Resources["ContentLabelForeground"] = LightContentLabelForeground;
        }
            

               
    }
}
