using System.Collections.Generic;

namespace ResistorCalculator.Models
{
    /// <summary>
    /// Données de tolérances
    /// </summary>
    public class Tolerance
    {
        #region properties
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Valeur
        /// </summary>
        public double Value { get; set; }

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
        public override string ToString()
        {
            return string.Concat("± ", Value * 100, "%");
        }

        /// <summary>
        /// Récupération de la liste des tolérances
        /// </summary>
        public static List<Tolerance> GetTolerances()
        {
            return new List<Tolerance>()
            {
                new Tolerance(){ Index = 0, Value = 0.2 },
                new Tolerance(){ Index = 1, Value = 0.1 },
                new Tolerance(){ Index = 2, Value = 0.05 },
                new Tolerance(){ Index = 3, Value = 0.02 },
                new Tolerance(){ Index = 4, Value = 0.01 },
                new Tolerance(){ Index = 5, Value = 0.005 },
                new Tolerance(){ Index = 6, Value = 0.0025 },
                new Tolerance(){ Index = 7, Value = 0.0010 },
                new Tolerance(){ Index = 8, Value = 0.0005 }
            };
        }
        #endregion
    }
}
