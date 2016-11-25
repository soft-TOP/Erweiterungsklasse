using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erweiterungsklasse
{
    public static partial class Extensionen
    {
        /// <summary>
        /// Die Zeichen, welche als Trennzeichen zwischen Vornamen und Nachnamen 
        /// oder zwischen Wörtern allgemein angenommen werden
        /// </summary>
        static private Char[] chars = { ' ', '.', ',', ':', '-', '?' , '!' , ';'};


        /// <summary>
        /// Gibt die Anzahl der Wörter im String wieder.
        /// </summary>
        /// <param name="str">Die zu prüfende Zeichenfolge</param>
        /// <returns>Anzahl der Wörter in der Zeichenfolge</returns>
        public static int WordCount(this String str) => String.IsNullOrWhiteSpace(str) ? 0 : str.Split(chars, StringSplitOptions.RemoveEmptyEntries).Length;

        /// <summary>
        /// Trennt einen übergebenen Namen in Vornamen und Nachnamen
        /// </summary>
        /// <param name="Name">Der zu trennende Name</param>
        /// <returns>Vorname</returns>
        public static String Vorname(this String Name)
        {
            return Name.Substring(0, Name.IndexOfAny(chars));
        }

        /// <summary>
        /// Trennt einen übergebenen Namen in Vornamen und Nachnamen
        /// </summary>
        /// <param name="Name">Der zu trennende Name</param>
        /// <param name="Trennzeichen">Das Trennzeichen zwischen den Namen</param>
        /// <returns>Vorname</returns>
        public static String Vorname(this String Name, Char Trennzeichen)
        {
            return Name.Substring(0, Name.IndexOf(Trennzeichen));
        }

        /// <summary>
        /// Trennt einen übergebenen Namen in Vornamen und Nachnamen
        /// </summary>
        /// <param name="Name">Der zu trennende Name</param>
        /// <returns>Nachname</returns>
        public static String Nachname(this String Name)
        {
            return Name.Substring(Name.IndexOfAny(chars)+1);
        }

        /// <summary>
        /// Trennt einen übergebenen Namen in Vornamen und Nachnamen
        /// </summary>
        /// <param name="Name">Der zu trennende Name</param>
        /// <param name="Trennzeichen">Das Trennzeichen zwischen den Namen</param>
        /// <returns>Nachname</returns>
        public static String Nachname(this String Name, Char Trennzeichen)
        {
            return Name.Substring(Name.IndexOf(Trennzeichen)+1);
        }
    }
}
