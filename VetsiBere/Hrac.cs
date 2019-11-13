using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere
{
    class Hrac
    {
        public int id;
        public string name;
        public List<Karta> balicek = new List<Karta>();


        public Hrac(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void PrijmoutKartu(Karta k)
        {
            balicek.Add(k);
        }
    }
}
