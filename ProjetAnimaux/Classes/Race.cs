using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ProjetAnimaux
{
    public class Race : INotifyPropertyChanged
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

        private int recorded;
        public int Recorded
        {
            get { return recorded; }
            set { recorded = value; PropertyChange("Recorded"); }
        }

        private int toKill;
        public int ToKill
        {
            get { return toKill; }
            set { toKill = value; PropertyChange("toKill"); }
        }

        [InverseProperty("Race")]
        public virtual ObservableCollection<Animal> Animals { get; set; }

    }
}
