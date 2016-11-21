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
        /// Insbesondere die deutschen Begriffe und Zahlen werden berücksichtigt
        /// Kann der Wert nicht ermittelt werden wird eine Ausnahme ausgelöst
        /// </summary>
        /// <param name="value">Wahrheitswert als Zeichenkette</param>
        /// <returns>true oder false</returns>
        public static Boolean ToBoolean(this String value)
        {
            Boolean rückgabe = false;
            if (Boolean.TryParse(value, out rückgabe))
            {
                System.Diagnostics.Debug.WriteLine("Boolean.TryParse: " + value);
                return rückgabe;
            }
            else
            {
                Int32 i;
                if (Int32.TryParse(value, out i))
                {
                    System.Diagnostics.Debug.WriteLine("Int32.TryParse: " + value);
                    return 0 < i;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("switch (value.Trim().ToLower()): " + value);
                    switch (value.Trim().ToLower())
                    {
                        case "wahr":
                        case "w":
                        case "ja":
                        case "richtig": return true;
                        case "falsch":
                        case "f":
                        case "nein":
                        case "unrichtig": return false;
                        default: throw new InvalidCastException($"{value} kann nicht in einen Booleschen Wert gewandelt werden.");
                    }
                }
            }
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
    }
}