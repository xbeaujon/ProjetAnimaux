using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProjetAnimaux
{
    public class Animal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChange(string c)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(c));
        }


        public int ID { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; PropertyChange("Name"); }
        }

        private enumSpecies species { get; set; }
        public enumSpecies Species
        {
            get { return species; }
            set { species = value; PropertyChange("Species"); }
        }

    private Race race;
        virtual public Race Race 
        {
            get { return race; } 
            set { race = value; PropertyChange("Race"); }
        }

        private enumGender gender { get; set; }
        public enumGender Gender
        {
            get { return gender; }
            set { gender = value; PropertyChange("Gender"); }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; PropertyChange("Age"); }
        }


        private string region;
        public string Region
        {
            get { return region; }
            set { region = value; PropertyChange("Region"); }
        }

    }
}
