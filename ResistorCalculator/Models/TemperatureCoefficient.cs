using System.Collections.Generic;

namespace ResistorCalculator.Models
{
    /// <summary>
    /// Données de coefficient de température
    /// </summary>
    public class TemperatureCoefficient
    {
        #region properties
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Valeur
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Valeur affichée
        /// </summary>
        public string Display
        {
            get
            {
                return ToString();
            }
        }
        #endregion

        #region publics methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString() + " ppm/°C";
        }

        /// <summary>
        /// Récupération de la liste des coefficients de  température
        /// </summary>
        public static List<TemperatureCoefficient> GetTemperatureCoefficients()
        {
            return new List<TemperatureCoefficient>()
            {
                new TemperatureCoefficient(){ Index = 0, Value = 200 },
                new TemperatureCoefficient(){ Index = 1, Value = 100 },
                new TemperatureCoefficient(){ Index = 2, Value = 50 },
                new TemperatureCoefficient(){ Index = 3, Value = 25 },
                new TemperatureCoefficient(){ Index = 4, Value = 15 },
                new TemperatureCoefficient(){ Index = 5, Value = 10 },
                new TemperatureCoefficient(){ Index = 6, Value = 5 },
                new TemperatureCoefficient(){ Index = 7, Value = 1 }
            };
        }
        #endregion
    }
}
