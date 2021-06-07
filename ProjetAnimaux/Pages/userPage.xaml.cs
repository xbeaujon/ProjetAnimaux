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
    /// Logique d'interaction pour userPage.xaml
    /// </summary>
    public partial class userPage : Page
    {
        private DatabaseContext DB;
        public userPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DB = ((MainWindow)App.Current.MainWindow).DB;
            UserLV.ItemsSource = DB.Users.Local.ToObservableCollection();
            DB.Users.ToArray();
        }

        private void UserLV_Selected(object sender, RoutedEventArgs e)
        {
            User selected = (User)UserLV.SelectedItem;
            if (selected != null)
            {
                UserGrid.DataContext = selected;
            }
            else
            {
                UserGrid.DataContext = null;
            }
        }
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin bookEditionWindow = new AdminLogin(DB);
            if (bookEditionWindow.ShowDialog() == true)
            {
                MessageBox.Show("User bien ajouté");
            }
        }

            private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            User selected = (User)UserLV.SelectedItem;
            if (selected != null)
            {
                DB.Users.Remove(selected);
                DB.SaveChanges();
            }
        }


        private void Edition_Click(object sender, RoutedEventArgs e)
        {
            User selected = (User)UserLV.SelectedItem;
            if (selected != null)
            {
                AdminLogin bookEditionWindow = new AdminLogin(DB, selected);
                if (bookEditionWindow.ShowDialog() == true)
                {
                    UserLV_Selected(null, null);
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectioner un user");
            }

        }        
    }
}
