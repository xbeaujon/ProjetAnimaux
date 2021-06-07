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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User User;
        public DatabaseContext DB;
        public MainWindow()
        {
            InitializeComponent();
            DB = new DatabaseContext();
            User = null;
            UpdateUI();
        }

        private void UpdateUI()
        {   
            if (User != null)
            {
                switch (User.Right)
                {
                    case UserRight.ANON:
                        TabCtrl.Visibility = Visibility.Collapsed;
                        loginBtn.Visibility = Visibility.Visible;
                        logoutBtn.Visibility = Visibility.Collapsed;
                        break;
                    case UserRight.USER:
                        TabCtrl.Visibility = Visibility.Visible;
                        ModifUser.Visibility = Visibility.Collapsed;
                        ModifAnimaux.Visibility = Visibility.Collapsed;
                        ModifRace.Visibility = Visibility.Collapsed;
                        loginBtn.Visibility = Visibility.Collapsed;
                        logoutBtn.Visibility = Visibility.Visible;
                        break;
                    case UserRight.ADMIN:
                        TabCtrl.Visibility = Visibility.Visible;
                        loginBtn.Visibility = Visibility.Collapsed;
                        logoutBtn.Visibility = Visibility.Visible;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                TabCtrl.Visibility = Visibility.Collapsed;
                loginBtn.Visibility = Visibility.Visible;
                logoutBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void Login()
        {
            Login lw = new Login(DB);
            if (lw.ShowDialog() == true)
            {
                User = lw.User;
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Identification Invalide");
            }
        }
        private void Logout()
        {
            User = null;
            UpdateUI();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }

    }
}
