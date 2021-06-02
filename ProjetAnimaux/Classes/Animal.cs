using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAnimaux
{
    public class Animal
    {
        public int ID { get; set; }

        public enumSpecies species;

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Race race;

        public Race Race
        {
            get { return race; }
            set { race = value; }
        }


        private string region;
        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        public Animal (){}





    }
}
