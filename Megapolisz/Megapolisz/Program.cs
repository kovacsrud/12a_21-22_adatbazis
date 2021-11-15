using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megapolisz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Polisz> poliszok = new List<Polisz>();
            try
            {
                var sorok = File.ReadAllLines("megapoliszok.txt", Encoding.UTF8);
                for (int i = 1; i < sorok.Length; i++)
                {
                    poliszok.Add(new Polisz(sorok[i]));
                }
                Console.WriteLine("Lista kész!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.WriteLine($"3.feladat: Megapoliszok száma:{poliszok.Count} db");

            var indiaiVarosok = poliszok.FindAll(x=>x.Orszag=="India").Count;
            Console.WriteLine($"4.feladat: Indiai nagyvárosok száma:{indiaiVarosok} db");

            var usaAtlag = poliszok.FindAll(x => x.Orszag == "Egyesült Államok").Average(x=>x.Nepesseg2);

            Console.WriteLine($"5.feladat: A keresett átlag:{usaAtlag}");

            var kinaiVarosok = poliszok.FindAll(x => x.Orszag == "Kína");

            var maxKinaiVaros = kinaiVarosok.Find(x=>x.Nepesseg1==kinaiVarosok.Max(y=>y.Nepesseg1));

            Console.WriteLine($@"6.feladat: A legnépesebb kínai nagyváros
            Név:{maxKinaiVaros.Varos}
            Népesség elővárosokkal:{maxKinaiVaros.Nepesseg1} fő
            Népesség elővárosok nélkül:{maxKinaiVaros.Nepesseg2} fő");

            if (poliszok.Any(x=>x.Varos=="Budapest"))
            {
                Console.WriteLine("Budapest szerepel az adatok között");
            } else
            {
                Console.WriteLine("Budapest nem szerepel az adatok között");
            }

            var stat = poliszok.ToLookup(x=>x.Orszag);

            foreach (var i in stat)
            {
                if (i.Count()>2)
                {
                    Console.WriteLine($"{i.Key},{i.Count()}");
                }
                
            }

            var brazilVarosok = poliszok.FindAll(x=>x.Orszag=="Brazília");
            try
            {
                FileStream fajl = new FileStream("brazil.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(fajl, Encoding.UTF8);

                writer.WriteLine("varos;nepesseg1;nepesseg2");

                foreach (var i in brazilVarosok)
                {
                    writer.WriteLine($"{i.Varos};{i.Nepesseg1};{i.Nepesseg2}");
                }

                writer.Close();
                Console.WriteLine("Kiírás kész!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.ReadKey();
        }
    }
}
