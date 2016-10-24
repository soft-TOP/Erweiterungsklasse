using Erweiterungsklasse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erweiterungsklasse
{
    class Program
    {
        static void Main(string[] args)
        {
            String Name1 = "Torsten Pohling";
            String Name2 = "Torsten-Pohling";
            String Name3 = "Torsten:Pohling";
            String Name4 = "Torsten#Pohling";

            Console.WriteLine($"Vorname: {Name1.Vorname()}; Nachname: { Name1.Nachname()}");
            Console.WriteLine($"Vorname: {Name2.Vorname()}; Nachname: { Name2.Nachname()}");
            Console.WriteLine($"Vorname: {Name3.Vorname()}; Nachname: { Name3.Nachname()}");
            Console.WriteLine($"Vorname: {Name4.Vorname('#')}; Nachname: { Name4.Nachname('#')}");

            Console.ReadLine();
        }
    }
}
