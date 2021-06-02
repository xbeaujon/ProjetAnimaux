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

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public enumSpecies species { get; set; }

        [ForeignKey("RaceID")]
        virtual public Race Race { get; set; }

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
            this.species = species;
            Race = race;
            Gender = gender;
            Region = region;
        }


    }
}
