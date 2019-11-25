using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace ResistorCalculator.Models
{
    /// <summary>
    /// Données d'un anneau
    /// </summary>
    public class Ring
    {
        #region properties
        /// <summary>
        /// Couleur
        /// </summary>
        public SolidColorBrush Color { set; get; }

        /// <summary>
        /// Couleur du bord
        /// </summary>
        public SolidColorBrush ButtonBorderColor { set; get; }

        /// <summary>
        /// NOm
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Digit { get; set; }

        /// <summary>
        /// Multiplicateur
        /// </summary>
        public double? Multiplicator { get; set; }

        /// <summary>
        /// Tolérance
        /// </summary>
        public Tolerance Tolerance { get; set; }

        /// <summary>
        /// Coéfficient de température
        /// </summary>
        public TemperatureCoefficient TemperatureCoefficient { get; set; }

        /// <summary>
        /// Abreviation
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Ordre des valeurs
        /// </summary>
        public int DigitOrder { get; set; }

        /// <summary>
        /// Ordre des multiplicateur
        /// </summary>
        public int MultiplicatorOrder { get; set; }

        /// <summary>
        /// Ordre des tolérances
        /// </summary>
        public int ToleranceOrder { get; set; }

        /// <summary>
        /// Ordre des coéfficien de température
        /// </summary>
        public int TemperatureCoefficientOrder { get; set; }
        #endregion

        #region publics methods
        /// <summary>
        /// Récupération de la liste des anneeux
        /// </summary>
        public static List<Ring> GetRings()
        {
            Color _black = Colors.Black;
            Color _brown = (Color)ColorConverter.ConvertFromString("#FFA65858");
            Color _red = (Color)ColorConverter.ConvertFromString("#FFFF6262");
            Color _orange = (Color)ColorConverter.ConvertFromString("#FFFFC04C");
            Color _yellow = (Color)ColorConverter.ConvertFromString("#FFFFFF5E");
            Color _green = (Color)ColorConverter.ConvertFromString("#FF00DC00");
            Color _blue = (Color)ColorConverter.ConvertFromString("#FF0080FF");
            Color _purple = (Color)ColorConverter.ConvertFromString("#FFA805F3");
            Color _gray = (Color)ColorConverter.ConvertFromString("#FFE2E2E2");
            Color _white = Colors.White;
            Color _gold = Colors.Gold;
            Color _silver = Colors.Silver;
            Color _transparent = Colors.Transparent;
            
            return new List<Ring>()
            {
                new Ring()
                { 
                    Abbreviation = "BK", 
                    Color = new SolidColorBrush(_black),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 0, 
                    Multiplicator = Math.Pow(10, 0), 
                    Name = "Noir", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 0).Single(), 
                    TemperatureCoefficient =  TemperatureCoefficient.GetTemperatureCoefficients().Where(x => x.Index == 0).Single(),
                    DigitOrder = 1,
                    MultiplicatorOrder = 1,
                    ToleranceOrder = 3,
                    TemperatureCoefficientOrder = 1
                },
                new Ring()
                { 
                    Abbreviation = "BN", 
                    Color = new SolidColorBrush(_brown),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 1, 
                    Multiplicator = Math.Pow(10, 1), 
                    Name = "Marron", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 4).Single(), 
                    TemperatureCoefficient =  TemperatureCoefficient.GetTemperatureCoefficients().Where(x => x.Index == 1).Single(),
                    DigitOrder = 2,
                    MultiplicatorOrder = 2,
                    ToleranceOrder = 4,
                    TemperatureCoefficientOrder = 2
                },
                new Ring()
                { 
                    Abbreviation = "RD", 
                    Color = new SolidColorBrush(_red),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 2, 
                    Multiplicator = Math.Pow(10, 2), 
                    Name = "Rouge", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 3).Single(), 
                    TemperatureCoefficient = TemperatureCoefficient.GetTemperatureCoefficients().Where(x => x.Index == 2).Single(),
                    DigitOrder = 3,
                    MultiplicatorOrder = 3,
                    ToleranceOrder = 5,
                    TemperatureCoefficientOrder = 3
                },
                new Ring()
                { 
                    Abbreviation = "OG", 
                    Color = new SolidColorBrush(_orange),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 3, 
                    Multiplicator = Math.Pow(10, 3), 
                    Name = "Orange", 
                    Tolerance = null, 
                    TemperatureCoefficient = TemperatureCoefficient.GetTemperatureCoefficients().Where(x => x.Index == 3).Single(),
                    DigitOrder = 4,
                    MultiplicatorOrder = 4,
                    ToleranceOrder = 0,
                    TemperatureCoefficientOrder = 4
                },
                new Ring()
                { 
                    Abbreviation = "YW", 
                    Color = new SolidColorBrush(_yellow),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 4, 
                    Multiplicator = Math.Pow(10, 4), 
                    Name = "Jaune", 
                    Tolerance = null, 
                    TemperatureCoefficient = TemperatureCoefficient.GetTemperatureCoefficients().Where(x => x.Index == 4).Single(),
                    DigitOrder = 5,
                    MultiplicatorOrder = 5,
                    ToleranceOrder = 0,
                    TemperatureCoefficientOrder = 5
                },
                new Ring()
                { 
                    Abbreviation = "GN", 
                    Color = new SolidColorBrush(_green), 
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 5, 
                    Multiplicator = Math.Pow(10, 5), 
                    Name = "Vert", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 5).Single(), 
                    TemperatureCoefficient = null,
                    DigitOrder = 6,
                    MultiplicatorOrder = 6,
                    ToleranceOrder = 6,
                    TemperatureCoefficientOrder = 0
                },
                new Ring()
                { 
                    Abbreviation = "BU", 
                    Color = new SolidColorBrush(_blue),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 6, 
                    Multiplicator = Math.Pow(10, 6), 
                    Name = "Bleu", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 6).Single(), 
                    TemperatureCoefficient = TemperatureCoefficient.GetTemperatureCoefficients().Where(x => x.Index == 5).Single(),
                    DigitOrder = 7,
                    MultiplicatorOrder = 7,
                    ToleranceOrder = 7,
                    TemperatureCoefficientOrder = 6
                },
                new Ring()
                { 
                    Abbreviation = "VT", 
                    Color = new SolidColorBrush(_purple), 
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 7, 
                    Multiplicator = Math.Pow(10, 7), 
                    Name = "Violet", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 7).Single(), 
                    TemperatureCoefficient = TemperatureCoefficient.GetTemperatureCoefficients().Where(x => x.Index == 6).Single(),
                    DigitOrder = 8,
                    MultiplicatorOrder = 8,
                    ToleranceOrder = 8,
                    TemperatureCoefficientOrder = 7
                },
                new Ring()
                { 
                    Abbreviation = "GY", 
                    Color = new SolidColorBrush(_gray),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 8, 
                    Multiplicator = null, 
                    Name = "Gris", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 8).Single(), 
                    TemperatureCoefficient = null,
                    DigitOrder = 9,
                    MultiplicatorOrder = 0,
                    ToleranceOrder = 9,
                    TemperatureCoefficientOrder = 0
                },
                new Ring()
                { 
                    Abbreviation = "WT", 
                    Color = new SolidColorBrush(_white),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = 9, 
                    Multiplicator = null, 
                    Name = "Blanc", 
                    Tolerance = null, 
                    TemperatureCoefficient = TemperatureCoefficient.GetTemperatureCoefficients().Where(x => x.Index == 7).Single(),
                    DigitOrder = 10,
                    MultiplicatorOrder = 0,
                    ToleranceOrder = 0,
                    TemperatureCoefficientOrder = 8
                },
                new Ring()
                { 
                    Abbreviation = "GD", 
                    Color = new SolidColorBrush(_gold),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = null, 
                    Multiplicator = 0.1, 
                    Name = "Or", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 2).Single(), 
                    TemperatureCoefficient = null,
                    DigitOrder = 0,
                    MultiplicatorOrder = 10,
                    ToleranceOrder = 2,
                    TemperatureCoefficientOrder = 0
                },
                new Ring()
                { 
                    Abbreviation = "SR", 
                    Color = new SolidColorBrush(_silver),
                    ButtonBorderColor = new SolidColorBrush(Colors.DarkGray),
                    Digit = null, 
                    Multiplicator = 0.01, 
                    Name = "Argent", 
                    Tolerance = Tolerance.GetTolerances().Where(x => x.Index == 1).Single(), 
                    TemperatureCoefficient = null,
                    DigitOrder = 0,
                    MultiplicatorOrder = 9,
                    ToleranceOrder = 1,
                    TemperatureCoefficientOrder = 0
                }
            };
        }
        #endregion
    }
}
