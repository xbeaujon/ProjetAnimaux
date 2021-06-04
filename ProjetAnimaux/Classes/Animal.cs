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
            set { name = value; }
        }

        public enumSpecies Species { get; set; }

        private Race race;
        virtual public Race Race 
        {
            get { return race; } 
            set { race = value; PropertyChange("Race"); }
        }

        public enumGender Gender { get; set; }

        private string region;

        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        public Animal (){}

        public Animal(string name, enumSpecies species, Race race, enumGender gender, string region)
        {
            Name = name;
            Species = species;
            Race = race;
            Gender = gender;
            Region = region;
        }


    }
}
