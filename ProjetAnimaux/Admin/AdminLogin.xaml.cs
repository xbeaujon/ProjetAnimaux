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
using System.Windows.Shapes;

namespace ProjetAnimaux
{
    /// <summary>
    /// Logique d'interaction pour AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        private DatabaseContext db;
        private User UserSelected;
        private bool newUser;
        public AdminLogin(DatabaseContext db, User userSelected = null)
        {
            InitializeComponent();
            this.db = db;
            if (userSelected == null)
            {
                userSelected = new User();
                this.newUser = true;
            }
            this.UserSelected = userSelected;
            UserGrid.DataContext = this.UserSelected;
            Password.Password = this.UserSelected.Password;
            RightBox.ItemsSource = Enum.GetValues(typeof(UserRight));
        }
        private void CancelButton(object sender, RoutedEventArgs eventArgs)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void SaveButton(object sender, RoutedEventArgs eventArgs)
        {
            this.UserSelected.Password = Password.Password;
            if (newUser)
            {
                db.Users.Add(this.UserSelected);
            }

            db.SaveChanges();
            this.DialogResult = true;
            this.Close();
        }
    }
}
