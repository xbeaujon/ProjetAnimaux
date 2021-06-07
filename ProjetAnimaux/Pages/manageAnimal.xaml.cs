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
    /// Logique d'interaction pour manageAnimal.xaml
    /// </summary>
    public partial class manageAnimal : Page
    {
        DatabaseContext animalData;
        public manageAnimal()
        {
            InitializeComponent();
            animalData = new DatabaseContext();
            AnimalGrid.ItemsSource = animalData.Animals.Local.ToObservableCollection();
            animalData.Animals.ToList();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Modify(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
