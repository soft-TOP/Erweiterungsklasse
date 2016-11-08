using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erweiterungsklasse
{
    public static partial class Extensionen
    {
        private const Int32 diffK_C = 273;
        /// <summary>
        /// setzt eine Einheit an die Zahl
        /// </summary>
        /// <param name="Temperatur">Auszugebende Temperatur</param>
        /// <returns>Die Zahl als Temperaur mit der Einheit Kelvin</returns>
        public static String Kelvin(this Int32 Temperatur)
        {
            return Temperatur.ToString() + "K";
        }

        /// <summary>
        /// setzt eine Einheit an die Zahl
        /// </summary>
        /// <param name="Temperatur">Auszugebende Temperatur</param>
        /// <returns>Die Zahl als Temperaur mit der Einheit °C</returns>
        public static String Celsius(this Int32 Temperatur)
        {
            return Temperatur.ToString() + "°C";
        }

        /// <summary>
        /// wandelt eine Temperatur von Kelvin in °C (gerundet)
        /// </summary>
        /// <param name="Temperatur">zu wandelnde Temperatur</param>
        /// <returns>die Temperatur in °C</returns>
        public static Int32 ToCelsius(this Int32 Temperatur)
        {
            return Temperatur + diffK_C;
        }

        /// <summary>
        /// wandelt eine Temperatur von °C in Kelvin (gerundet)
        /// </summary>
        /// <param name="Temperatur">zu wandelnde Temperatur</param>
        /// <returns>die Temperatur in K</returns>
        public static Int32 ToKelvin(this Int32 Temperatur)
        {
            return Temperatur - diffK_C;
        }
    }
}
