using System.Collections.Generic;

namespace ResistorCalculator.Models
{
    public class ResistorRing
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
        /// Récupération de la liste
        /// </summary>
        public static List<ResistorRing> GetResistorRings()
        {
            return new List<ResistorRing>()
            {
                new ResistorRing() { Index = 0, Display = "4 anneaux"},
                new ResistorRing() { Index = 1, Display = "5 anneaux"},
                new ResistorRing() { Index = 2, Display = "6 anneaux"},
            };
        }
        #endregion
    }
}
