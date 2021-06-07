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
using System.Data.SqlClient;

namespace ProjetAnimaux
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private DatabaseContext db;
        public User User;
        public Login(DatabaseContext db)
        {
            InitializeComponent();
            this.db = db;
        }
        private void CancelButton(object sender, RoutedEventArgs eventArgs)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void LogButton(object sender, RoutedEventArgs eventArgs)
        {
            string login = LoginBox.Text;
            string password = PassBox.Password;
            //User = db.Users.FirstOrDefault((u) => { return u.Login == login && u.Password == password; });
            User = (from u in db.Users where u.Login == login && u.Password == password select u).FirstOrDefault();
            if (User != null) this.DialogResult = true;
            this.Close();
        }
    }
}
