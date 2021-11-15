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

            Console.ReadKey();
        }
    }
}
