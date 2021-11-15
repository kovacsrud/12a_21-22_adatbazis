using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megapolisz
{
    public class Polisz
    {
        public string Orszag { get; set; }
        public string Varos { get; set; }
        public int Nepesseg1 { get; set; }
        public int Nepesseg2 { get; set; }

        public Polisz(string sor)
        {
            var e = sor.Split(';');
            Orszag = e[0];
            Varos = e[1];
            Nepesseg1 = Convert.ToInt32(e[2]);
            Nepesseg2 = Convert.ToInt32(e[3]);
        }
    }
}
