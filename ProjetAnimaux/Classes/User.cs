using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProjetAnimaux
{
    public enum UserRight
    {
        ANON,
        USER,
        ADMIN
    }
    public class User : INotifyPropertyChanged
    {
        public int ID { get; set; }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChange("Login"); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChange("Password"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private UserRight right;

        public UserRight Right
        {
            get { return right; }
            set { right = value; OnPropertyChange("Right"); }
        }

        private void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}