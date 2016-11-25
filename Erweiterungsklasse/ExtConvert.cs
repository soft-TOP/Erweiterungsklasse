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
        /// Wandelt eine Zeichenkette in einen Wahrheitswert. 
        /// Versucht die Standardumwandlungen zu nutzen. 
        /// Wenn das nicht klappt, werden insbesondere die deutschen Begriffe berücksichtigt.
        /// Kann der Wert nicht ermittelt werden wird eine Ausnahme ausgelöst
        /// </summary>
        /// <param name="value">Wahrheitswert als Zeichenkette</param>
        /// <returns>true oder false</returns>
        public static Boolean ToBoolean(this String value)
        {
            Boolean rückgabe = false;
            // erst einmal den Standard probieren
            if (Boolean.TryParse(value, out rückgabe))
            {
                System.Diagnostics.Debug.WriteLine("Boolean.TryParse: " + value);
            }
            else
            {
                // ein Integer wäre auch einfach und klar
                Int32 i;
                if (Int32.TryParse(value, out i))
                {
                    System.Diagnostics.Debug.WriteLine("Int32.TryParse: " + value);
                    rückgabe = Convert.ToBoolean(i);
                }
                else
                {
                    // man könnte auch gleich auf Double prüfen, dürfte aber eher selten sein
                    Double d;
                    if (Double.TryParse(value, out d))
                    {
                        System.Diagnostics.Debug.WriteLine("Double.TryParse: " + value);
                        rückgabe = Convert.ToBoolean(d);
                    }
                    else
                    {
                        // eine Zeichenkette -> klare deutsche Begriffe; englische wurden ja schon im Standard behandelt
                        System.Diagnostics.Debug.WriteLine("switch (value.Trim().ToLower()): " + value);
                        switch (value.Trim().ToLower())
                        {
                            case "wahr":
                            case "w":
                            case "ja":
                            case "richtig": rückgabe = true; break;
                            case "falsch":
                            case "f":
                            case "nein":
                            case "unwahr":
                            case "unrichtig": rückgabe = false; break;
                            default: throw new InvalidCastException($"{value} kann nicht in einen Booleschen Wert gewandelt werden.");
                        }
                    }
                }
            }
            return rückgabe;
        }

        /// <summary>
        /// Wandelt eine Zeichenkette in einen Wahrheitswert. 
        /// Insbesondere die deutschen Begriffe und Zahlen werden berücksichtigt
        /// Kann der Wert nicht ermittelt werden wird false zurückgegeben
        /// </summary>
        /// <param name="value">Wahrheitswert als Zeichenkette</param>
        /// <param name="result">Ergebnis der Umwandlung. Ist der Rückgabewert der Methode FALSE, ist "result" immer false</param>
        /// <returns>TRUE: Umwandlung erfolgreich</returns>
        public static Boolean TryToBoolean(this String value, out Boolean result)
        {
            try
            {
                result = value.ToBoolean();
                return true;
            }
            catch (Exception)
            {
                result = false;
                return false;
            }
        }

        /// <summary>
        /// gibt die deutsche Schreibweise des Wahrheitswertes zurück
        /// </summary>
        /// <param name="boolean">der auszugebende Boolesche Wert</param>
        /// <param name="deutsch">TRUE: die deutsche Schreibweise soll ausgegeben werden</param>
        /// <returns>deutsche Schreibweise oder Original des Wahrheitswertes</returns>
        private static String toString(Boolean boolean, Boolean deutsch) => deutsch ? (boolean ? "Wahr" : "Falsch") : boolean.ToString();

        /// <summary>
        /// Erweitert die Zeichenausgabe eines Booleschen Wertes um die deutsche Schreibweise
        /// </summary>
        /// <param name="boolean">der auszugebende Boolesche Wert</param>
        /// <param name="culture">die zu verwendende Kultur in der Schreibweise "de-DE"</param>
        /// <returns>Zeichenkette mit "Wahr" oder "Falsch", sofern die Kultur = "de-DE" übergeben wurde</returns>
        public static String ToString(this Boolean boolean, String culture) => 
            toString(boolean, System.Globalization.CultureInfo.GetCultureInfo(culture) == System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

        /// <summary>
        /// Erweitert die Zeichenausgabe eines Booleschen Wertes um die deutsche Schreibweise
        /// </summary>
        /// <param name="boolean">der auszugebende Boolesche Wert</param>
        /// <param name="LCID">die zu verwendende Kultur, für Deutschland 1031</param>
        /// <returns>Zeichenkette mit "Wahr" oder "Falsch", sofern die Kultur = 1031 übergeben wurde</returns>
        public static String ToString(this Boolean boolean, Int32 LCID) => 
            toString(boolean, System.Globalization.CultureInfo.GetCultureInfo(LCID) == System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
    }
}