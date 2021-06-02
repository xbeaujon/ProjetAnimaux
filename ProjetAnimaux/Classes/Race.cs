using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAnimaux
{
    public class Race
    {
        public int ID { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int recorded;
        public int Recorded
        {
            get { return recorded; }
            set { recorded = value; }
        }

        private int toKill;
        public int ToKill
        {
            get { return toKill; }
            set { toKill = value; }
        }

        public Race(string name, int recorded, int toKill)
        {
            Name = name;
            Recorded = recorded;
            ToKill = toKill;
        }

        [InverseProperty("Animals")]
        public virtual ICollection<Animal> Animals { get; set; }


    }
}
