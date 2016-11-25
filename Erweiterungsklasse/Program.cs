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
            const Int32 platz1 = 10;
            String Name1 = "Torsten Pohling";
            String Name2 = "Torsten-Pohling";
            String Name3 = "Torsten:Pohling";
            String Name4 = "Torsten#Pohling";

            Console.WriteLine($"Vorname: {Name1.Vorname(),platz1}; Nachname: {Name1.Nachname(),platz1}");
            Console.WriteLine($"Vorname: {Name2.Vorname(),platz1}; Nachname: {Name2.Nachname(),platz1}");
            Console.WriteLine($"Vorname: {Name3.Vorname(),platz1}; Nachname: {Name3.Nachname(),platz1}");
            Console.WriteLine($"Vorname: {Name4.Vorname('#'),platz1}; Nachname: {Name4.Nachname('#'),platz1}");
            Console.WriteLine();

            const Int32 platz2 = 10;
            Int32 temp1 = 77;
            Console.WriteLine($"{temp1.Celsius(),platz2}; {temp1.Kelvin(),platz2}");
            Console.WriteLine($"{temp1.ToCelsius().Celsius(),platz2}; {temp1.ToKelvin().Kelvin(),platz2}");
            Console.WriteLine();
            Console.WriteLine($"{(-14).Celsius(),platz2}; {(-18).Kelvin(),platz2}");
            Console.WriteLine($"{14.ToCelsius().Celsius(),platz2}; {18.ToKelvin().Kelvin(),platz2}");


            // verschiedene Wahrheitswerte sammeln
            List<String> wahrheit = new List<String> { "wahr", "w", "ja", "Platz da","richtig", "falsch", "f", "nein", "niemals", "unrichtig", "0", "1", "10000", "-1", "-77,5", "0,1", "0.1", "true", false.ToString() };


            Boolean bb = false;
            foreach (var w in wahrheit)
            {
                Console.WriteLine((w.PadRight(9) + "-").PadRight(11) + (w.TryToBoolean(out bb) ? bb.ToString().PadRight(6) 
                    + " DEU: " + bb.ToString("de-DE").PadRight(6)
                    + " deu: " + bb.ToString(1031).PadRight(6) : "xx".PadLeft(6)));
            }


            Console.ReadLine();
        }
    }
}
