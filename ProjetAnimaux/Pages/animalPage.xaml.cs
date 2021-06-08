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

namespace ProjetAnimaux.Pages
{
    /// <summary>
    /// Logique d'interaction pour animalPage.xaml
    /// </summary>
    public partial class animalPage : Page
    {
        DatabaseContext animalData;
        public animalPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            animalData = new DatabaseContext();
            AnimalGrid.ItemsSource = animalData.Animals.Local.ToObservableCollection();
            animalData.Animals.ToList();
        }

        private void filNo(object sender, RoutedEventArgs e)
        {
            if (FilterChoice != null)
            {
                FilterChoice.IsEnabled = false;
                FilterChoice.Items.Clear();
            }
        }

        private void filSexe(object sender, RoutedEventArgs e)
        {
            EnableFilter();
            FilterChoice.Items.Add("Female");
            FilterChoice.Items.Add("Male");
        }

        private void filRace(object sender, RoutedEventArgs e)
        {
            EnableFilter();

            var subfilter = (from race in animalData.Races
                             select race.Name);

            foreach (var item in subfilter)
            {
                FilterChoice.Items.Add(item);
            }
        }

        private void filRegion(object sender, RoutedEventArgs e)
        {
            EnableFilter();

            var subfilter = (from animal in animalData.Animals
                             select animal.Region).Distinct();
            foreach (var item in subfilter)
            {
                FilterChoice.Items.Add(item);
            }
        }

        private void EnableFilter()
        {
            FilterChoice.IsEnabled = true;
            FilterChoice.Items.Clear();
        }

        public void ApplyFilter(object sender, RoutedEventArgs e)
        {
            if (filterSelect.Text == "Tous")
            {
                ShowItems();
            }
            else
            {
                ShowItems(filterSelect.Text, FilterChoice.Text);
            }
        }
        private void ShowItems(string filter = "all", string subfilter = "all")
        {
            List<Animal> result = new List<Animal>();
            enumGender toSexe = 0;
            switch (filter)
            {
                case "all":
                    result = animalData.Animals.Local.ToList();
                    break;
                case "Région":
                    result = (from animal in animalData.Animals
                              where animal.Region == subfilter
                              select animal).ToList();
                    break;
                case "Sexe":
                    if (subfilter == "Male")
                    result = (from animal in animalData.Animals
                              where animal.Gender == toSexe
                              select animal).ToList();
                    break;
                case "Race":
                    result = (from animal in animalData.Animals
                              from race in animalData.Races
                              where animal.ID == race.ID && race.Name == subfilter
                              select animal).ToList();
                    break;
                default:
                    break;
            }
            AnimalGrid.ItemsSource = result;
            result.ToList();
        }

    }
}
