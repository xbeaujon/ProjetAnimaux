using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetAnimaux
{
    /// <summary>
    /// Logique d'interaction pour racePage.xaml
    /// </summary>
    public partial class racePage : Page
    {
        DatabaseContext raceData;
        public racePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            raceData = ((MainWindow)App.Current.MainWindow).DB;
            RaceLV.ItemsSource = raceData.Races.Local.ToObservableCollection();
            raceData.Races.ToArray();
        }

        private void RaceLV_Selected(object sender, RoutedEventArgs e)
        {
            Race selected = (Race)RaceLV.SelectedItem;
            if (selected != null)
            {
                RaceDetails.DataContext = selected;
            }
            else
            {
                RaceDetails.DataContext = null;
            }
        }

    }
}
