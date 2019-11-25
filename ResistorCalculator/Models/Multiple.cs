using System.Collections.Generic;

namespace ResistorCalculator.Models
{
    /// <summary>
    /// Multiple
    /// </summary>
    public class Multiple
    {
        #region properties
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Valeur affcihée
        /// </summary>
        public string Display { get; set; }
        #endregion

        #region publics methods
        /// <summary>
        /// Récupération de la liste des multiples
        /// </summary>
        public static List<Multiple> GetMultiples()
        {
            return new List<Multiple>()
            {
                new Multiple() { Index = 0, Display = "Ω"},
                new Multiple() { Index = 1, Display = "KΩ"},
                new Multiple() { Index = 2, Display = "MΩ"},
                new Multiple() { Index = 3, Display = "GΩ"}
            };
        }
        #endregion
    }
}
