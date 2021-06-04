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
    /// Logique d'interaction pour Animals.xaml
    /// </summary>
    public partial class Animals : Page
    {
        private DatabaseContext DB;
        public Animals()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DB = ((MainWindow)App.Current.MainWindow).DB;
            AnimalsLW.ItemsSource = DB.Animals.Local.ToObservableCollection();
            DB.Animals.ToArray();
        }
    }
}
