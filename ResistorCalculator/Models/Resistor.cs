namespace ResistorCalculator.Models
{
    /// <summary>
    /// Données d'une résistance
    /// </summary>
    public class Resistor
    {
        #region properties
        /// <summary>
        /// Valeur
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Valeur affichée
        /// </summary>
        public string DisplayValue { get; set; }

        /// <summary>
        /// Tolérance
        /// </summary>
        public Tolerance Tolerance { get; set; }

        /// <summary>
        /// Multiple
        /// </summary>
        public Multiple Multiple { get; set; }

        /// <summary>
        /// Coefficient de température
        /// </summary>
        public TemperatureCoefficient TemperatureCoefficient { get; set; }

        /// <summary>
        /// Valeur minimale
        /// </summary>
        public string MinValue { get; set; }

        /// <summary>
        /// Valeur maximale
        /// </summary>
        public string MaxValue { get; set; } 
        #endregion
    }
}
