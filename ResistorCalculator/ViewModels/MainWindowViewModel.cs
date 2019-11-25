using ResistorCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ResistorCalculator.ViewModels
{
    /// <summary>
    /// View Model de vue principale
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region attributes
        private int firstNumber = -1;
        private int secondNumber = -1;
        private int thirdNumber = -1;
        private int tolerance = 0;
        private int multipleIndex = 0;
        private double multiplicator = Math.Pow(10, 0);
        private ICommand ring1ColorSelection;
        private ICommand ring2ColorSelection;
        private ICommand ring3ColorSelection;
        private ICommand ring4ColorSelection;
        private ICommand ring5ColorSelection;
        private ICommand ring6ColorSelection;
        public double? resistorValue;
        public double? volt;
        public double? ampere;
        public double? watt;
        private string e6 = string.Empty;
        private string e12 = string.Empty;
        private string e24 = string.Empty;
        private string e48 = string.Empty;
        private string e96 = string.Empty;
        private string resistorDisplay = string.Empty;
        private string resistorMinValueDisplay = string.Empty;
        private string resistorMaxValueDisplay = string.Empty;
        private string resistorTempCoefDisplay = string.Empty;
        private Resistor resistor = new Resistor();
        private int selectedResistorRing = 0;
        private int selectedMultiple = 0;
        private int selectedTolerance = 0;
        private int selectedTempCoef = 0;
        private Visibility ring3Visibility = Visibility.Hidden;
        private Visibility ring6Visibility = Visibility.Hidden;
        private Ring selectedRing1;
        private Ring selectedRing2;
        private Ring selectedRing3;
        private Ring selectedRing4;
        private Ring selectedRing5;
        private Ring selectedRing6;
        #endregion

        #region events
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion

        #region properties
        /// <summary>
        /// Anneau 1 selectionné
        /// </summary>
        public Ring SelectedRing1
        {
            get
            {
                return selectedRing1;
            }
            set
            {
                selectedRing1 = value;
                RaisePropertyChanged("SelectedRing1");
            }
        }

        /// <summary>
        /// Anneau 2 selectionné
        /// </summary>
        public Ring SelectedRing2
        {
            get
            {
                return selectedRing2;
            }
            set
            {
                selectedRing2 = value;
                RaisePropertyChanged("SelectedRing2");
            }
        }

        /// <summary>
        /// Anneau 3 selectionné
        /// </summary>
        public Ring SelectedRing3
        {
            get
            {
                return selectedRing3;
            }
            set
            {
                selectedRing3 = value;
                RaisePropertyChanged("SelectedRing3");
            }
        }

        /// <summary>
        /// Anneau 4 selectionné
        /// </summary>
        public Ring SelectedRing4
        {
            get
            {
                return selectedRing4;
            }
            set
            {
                selectedRing4 = value;
                RaisePropertyChanged("SelectedRing4");
            }
        }

        /// <summary>
        /// Anneau 5 selectionné
        /// </summary>
        public Ring SelectedRing5
        {
            get
            {
                return selectedRing5;
            }
            set
            {
                selectedRing5 = value;
                RaisePropertyChanged("SelectedRing5");
            }
        }

        /// <summary>
        /// Anneau 6 selectionné
        /// </summary>
        public Ring SelectedRing6
        {
            get
            {
                return selectedRing6;
            }
            set
            {
                selectedRing6 = value;
                RaisePropertyChanged("SelectedRing6");
            }
        }


        /// <summary>
        /// Liste des multiples
        /// </summary>
        public List<Multiple> Multiples { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Ring> Rings { get; set; }

        /// <summary>
        /// Liste des anneaux 1
        /// </summary>
        public List<Ring> Rings1 { get; set; }

        /// <summary>
        /// Liste des anneaux 2
        /// </summary>
        public List<Ring> Rings2 { get; set; }

        /// <summary>
        /// Liste des anneaux 3
        /// </summary>
        public List<Ring> Rings3 { get; set; }

        /// <summary>
        /// Liste des anneaux 4
        /// </summary>
        public List<Ring> Rings4 { get; set; }

        /// <summary>
        /// Liste des anneaux 5
        /// </summary>
        public List<Ring> Rings5 { get; set; }

        /// <summary>
        /// Liste des anneaux 6
        /// </summary>
        public List<Ring> Rings6 { get; set; }

        /// <summary>
        /// Liste des tolérances
        /// </summary>
        public List<Tolerance> Tolerances { get; set; }

        /// <summary>
        /// Liste des coefficients de température
        /// </summary>
        public List<TemperatureCoefficient> TemperatureCoefficients { get; set; }

        /// <summary>
        /// Liste des séries E
        /// </summary>
        public List<ESerie> ESeries { get; set; }

        /// <summary>
        /// Valeur de la résistance
        /// </summary>
        public double? ResistorValue
        {
            get
            {
                return resistorValue;
            }
            set
            {
                resistorValue = value;
                RaisePropertyChanged("Resistor");
            }
        }

        /// <summary>
        /// Voltage
        /// </summary>
        public double? Volt
        {
            get
            {
                return volt;
            }
            set
            {
                if (value.HasValue)
                {
                    volt = Convert.ToDouble(value, new CultureInfo("en-US"));
                    Ampere = CalculateAmpere();
                    Watt = CalculateWatt();
                }
                else
                {
                    Ampere = null;
                    Watt = null;
                }
                RaisePropertyChanged("Volt");
            }
        }

        /// <summary>
        /// Ampérage
        /// </summary>
        public double? Ampere
        {
            get
            {
                return ampere;
            }
            set
            {
                ampere = value;
                RaisePropertyChanged("Ampere");
            }
        }

        /// <summary>
        /// Puissance
        /// </summary>
        public double? Watt
        {
            get
            {
                return watt;
            }
            set
            {
                watt = value;
                RaisePropertyChanged("Watt");
            }
        }

        /// <summary>
        /// Valeur de la résistance pour la série E6
        /// </summary>
        public string E6Value
        {
            get
            {
                return e6;
            }
            set
            {
                e6 = value;
                RaisePropertyChanged("E6Value");
            }
        }

        /// <summary>
        /// Valeur de la résistance pour la série E12
        /// </summary>
        public string E12Value
        {
            get
            {
                return e12;
            }
            set
            {
                e12 = value;
                RaisePropertyChanged("E12Value");
            }
        }

        /// <summary>
        /// Valeur de la résistance pour la série E24
        /// </summary>
        public string E24Value
        {
            get
            {
                return e24;
            }
            set
            {
                e24 = value;
                RaisePropertyChanged("E24Value");
            }
        }

        /// <summary>
        /// Valeur de la résistance pour la série E48
        /// </summary>
        public string E48Value
        {
            get
            {
                return e48;
            }
            set
            {
                e48 = value;
                RaisePropertyChanged("E48Value");
            }
        }

        /// <summary>
        /// Valeur de la résistance pour la série E96
        /// </summary>
        public string E96Value
        {
            get
            {
                return e96;
            }
            set
            {
                e96 = value;
                RaisePropertyChanged("E96Value");
            }
        }

        /// <summary>
        /// Valeur affichée de la résistance
        /// </summary>
        public string ResistorDisplay
        {
            get
            {
                return resistorDisplay;
            }
            set
            {
                resistorDisplay = value;
                RaisePropertyChanged("ResistorDisplay");
            }
        }

        /// <summary>
        /// Valeur affichée de la résistance minimale
        /// </summary>
        public string ResistorMinValueDisplay
        {
            get
            {
                return resistorMinValueDisplay;
            }
            set
            {
                resistorMinValueDisplay = value;
                RaisePropertyChanged("ResistorMinValueDisplay");
            }
        }

        /// <summary>
        /// Valeur affichée de la résistance maximale
        /// </summary>
        public string ResistorMaxValueDisplay
        {
            get
            {
                return resistorMaxValueDisplay;
            }
            set
            {
                resistorMaxValueDisplay = value;
                RaisePropertyChanged("ResistorMaxValueDisplay");
            }
        }

        /// <summary>
        /// Valeur affichée du coefficient de température
        /// </summary>
        public string ResistorTempCoefDisplay
        {
            get
            {
                return resistorTempCoefDisplay;
            }
            set
            {
                resistorTempCoefDisplay = value;
                RaisePropertyChanged("ResistorTempCoefDisplay");
            }
        }

        /// <summary>
        /// Résistance
        /// </summary>
        public Resistor Resistor
        {
            get
            {
                return resistor;
            }
            set
            {
                resistor = value;
                RaisePropertyChanged("Resistor");
            }
        }

        /// <summary>
        /// Visibilité de l'anneau 3
        /// </summary>
        public Visibility Ring3Visibility
        {
            get
            {
                return ring3Visibility;
            }
            set
            {
                ring3Visibility = value;
                RaisePropertyChanged("Ring3Visibility");
            }
        }

        /// <summary>
        /// Visibilité de l'anneau 6
        /// </summary>
        public Visibility Ring6Visibility
        {
            get
            {
                return ring6Visibility;
            }
            set
            {
                ring6Visibility = value;
                RaisePropertyChanged("Ring6Visibility");
            }
        }

        /// <summary>
        /// Liste des anneaux des résistance
        /// </summary>
        public List<ResistorRing> ResistorRings
        {
            get;
            set;
        }

        /// <summary>
        /// Valeur selectionnée du nombre d'anneaux
        /// </summary>
        public int SelectedResistorRing
        {
            get
            {
                return selectedResistorRing;
            }
            set
            {
                selectedResistorRing = value;
                RaisePropertyChanged("SelectedResistorRing");
                ChangeNbRings();
            }
        }

        /// <summary>
        /// Valeur selectionnée du multiple
        /// </summary>
        public int SelectedMultiple
        {
            get
            {
                return selectedMultiple;
            }
            set
            {
                selectedMultiple = value;
                RaisePropertyChanged("SelectedMultiple");
            }
        }

        /// <summary>
        /// Valeur selectionnée de la tolérance
        /// </summary>
        public int SelectedTolerance
        {
            get
            {
                return selectedTolerance;
            }
            set
            {
                selectedTolerance = value;
                RaisePropertyChanged("SelectedTolerance");
            }
        }

        /// <summary>
        /// Valeur selectionnée du coefficient de température
        /// </summary>
        public int SelectedTempCoef
        {
            get
            {
                return selectedTempCoef;
            }
            set
            {
                selectedTempCoef = value;
                RaisePropertyChanged("SelectedTempCoef");
            }
        }
        #endregion

        #region commands
        /// <summary>
        /// Commande appelée lors de selection de l'anneau 1
        /// </summary>
        public ICommand Ring1ColorSelection
        {
            get
            {
                if (ring1ColorSelection == null)
                {
                    ring1ColorSelection = new RelayCommand(
                        param => SetRing1Color(param)
                    );
                }
                return ring1ColorSelection;
            }
        }

        /// <summary>
        /// Commande appelée lors de selection de l'anneau 2
        /// </summary>
        public ICommand Ring2ColorSelection
        {
            get
            {
                if (ring2ColorSelection == null)
                {
                    ring2ColorSelection = new RelayCommand(
                        param => SetRing2Color(param)
                    );
                }
                return ring2ColorSelection;
            }
        }

        /// <summary>
        /// Commande appelée lors de selection de l'anneau 3
        /// </summary>
        public ICommand Ring3ColorSelection
        {
            get
            {
                if (ring3ColorSelection == null)
                {
                    ring3ColorSelection = new RelayCommand(
                        param => SetRing3Color(param)
                    );
                }
                return ring3ColorSelection;
            }
        }

        /// <summary>
        /// Commande appelée lors de selection de l'anneau 4
        /// </summary>
        public ICommand Ring4ColorSelection
        {
            get
            {
                if (ring4ColorSelection == null)
                {
                    ring4ColorSelection = new RelayCommand(
                        param => SetRing4Color(param)
                    );
                }
                return ring4ColorSelection;
            }
        }

        /// <summary>
        /// Commande appelée lors de selection de l'anneau 5
        /// </summary>
        public ICommand Ring5ColorSelection
        {
            get
            {
                if (ring5ColorSelection == null)
                {
                    ring5ColorSelection = new RelayCommand(
                        param => SetRing5Color(param)
                    );
                }
                return ring5ColorSelection;
            }
        }

        /// <summary>
        /// Commande appelée lors de selection de l'anneau 6
        /// </summary>
        public ICommand Ring6ColorSelection
        {
            get
            {
                if (ring6ColorSelection == null)
                {
                    ring6ColorSelection = new RelayCommand(
                        param => SetRing6Color(param)
                    );
                }
                return ring6ColorSelection;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Constructeur vide par défaut
        /// </summary>
        public MainWindowViewModel()
        {
            Multiples = Multiple.GetMultiples();
            Tolerances = Tolerance.GetTolerances();
            TemperatureCoefficients = TemperatureCoefficient.GetTemperatureCoefficients();
            ESeries = ESerie.GetESeries();
            ResistorRings = ResistorRing.GetResistorRings();
            Rings1 = Ring.GetRings().Where(x => x.Digit != null).OrderBy(x => x.DigitOrder).ToList();
            Rings2 = Ring.GetRings().Where(x => x.Digit != null).OrderBy(x => x.DigitOrder).ToList();
            Rings3 = Ring.GetRings().Where(x => x.Digit != null).OrderBy(x => x.DigitOrder).ToList();
            Rings4 = Ring.GetRings().Where(x => x.Multiplicator != null).OrderBy(x => x.MultiplicatorOrder).ToList();
            Rings5 = Ring.GetRings().Where(x => x.Tolerance != null).OrderBy(x => x.ToleranceOrder).ToList();
            Rings6 = Ring.GetRings().Where(x => x.TemperatureCoefficient != null).OrderBy(x => x.TemperatureCoefficientOrder).ToList();

            Ring blackRing = Rings1.Where(x => x.Digit == 0).Single();
            List<Ring> except = new List<Ring>() { blackRing };

            SetRing5Color(Rings5.OrderBy(a => a.Tolerance.Index == 2).First());
            SetRing1Color(Rings1.Except(except).ToList().OrderBy(a => Guid.NewGuid()).First());
            SetRing2Color(Rings2.OrderBy(a => Guid.NewGuid()).First());
            SetRing4Color(Rings4.OrderBy(a => Guid.NewGuid()).First());
        }
        #endregion

        #region privates methods
        /// <summary>
        /// Notification du changement de valeur de la propriété
        /// </summary>
        /// <param name="propertyName"></param>
        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;
            handlers(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Calcul de la résistance
        /// </summary>
        private void CalculateResistor()
        {

            string first = firstNumber > -1 ? firstNumber.ToString() : string.Empty;
            string second = secondNumber > -1 ? secondNumber.ToString() : string.Empty;
            string third = thirdNumber > -1 ? thirdNumber.ToString() : string.Empty;
            string stringValue = string.Empty;
            double doubleValue = 0;

            if (SelectedResistorRing == 0) third = string.Empty;

            stringValue = string.Concat(first, second, third);
            double.TryParse(stringValue, out doubleValue);
            doubleValue = doubleValue * multiplicator;
            ResistorValue = doubleValue;

            multipleIndex = 0;
            while (doubleValue >= 1000)
            {
                doubleValue /= 1000;
                ++multipleIndex;
            }

            //SelectedMultiple = Multiples.Single(x => x.Index == multipleIndex).Index;
            //TbColorsValue.Text = doubleValue.ToString();

            Ampere = CalculateAmpere();
            Watt = CalculateWatt();
            E6Value = CalculateESerie(ESerie.ESeries.E6);
            E12Value = CalculateESerie(ESerie.ESeries.E12);
            E24Value = CalculateESerie(ESerie.ESeries.E24);
            E48Value = CalculateESerie(ESerie.ESeries.E48);
            E96Value = CalculateESerie(ESerie.ESeries.E96);

            Resistor.Multiple = Multiples.Where(x => x.Index == multipleIndex).Single();
            Resistor.Value = (double)ResistorValue;
            Resistor.DisplayValue = doubleValue.ToString();

            SetResistorDisplay();

        }

        private void SetResistorDisplay()
        {
            if (Resistor.Multiple != null)
            {
                double d = Resistor.Value * Resistor.Tolerance.Value;
                double min = Resistor.Value - d;
                double max = Resistor.Value + d;

                while (min >= 1000)
                {
                    min /= 1000;
                }

                while (max >= 1000)
                {
                    max /= 1000;
                }
                Resistor.MinValue = Math.Round(min, 2).ToString() + " " + Resistor.Multiple.Display;
                Resistor.MaxValue = Math.Round(max, 2).ToString() + " " + Resistor.Multiple.Display;
                ResistorMinValueDisplay = "Valeur min : " + Resistor.MinValue;
                ResistorMaxValueDisplay = "Valeur max : " + Resistor.MaxValue;

                ResistorDisplay = "Valeur : " + Resistor.DisplayValue + " " + Resistor.Multiple.Display + " " + Resistor.Tolerance.Display;

                if (SelectedResistorRing == 2)
                {
                    if (Resistor.TemperatureCoefficient != null)
                    {
                        ResistorTempCoefDisplay = "Coefficient de température : " + Resistor.TemperatureCoefficient.Display;
                    }
                    else
                    {
                        ResistorTempCoefDisplay = string.Empty;
                    }
                }
                else
                {
                    ResistorTempCoefDisplay = string.Empty;
                }
            }
        }

        private void SetRing1Color(object obj)
        {
            var ring = obj as Ring;
            SelectedRing1 = ring;
            firstNumber = (int)ring.Digit;
            CalculateResistor();
        }

        private void SetRing2Color(object obj)
        {
            var ring = obj as Ring;
            SelectedRing2 = ring;
            secondNumber = (int)ring.Digit;
            CalculateResistor();
        }

        private void SetRing3Color(object obj)
        {
            var ring = obj as Ring;
            SelectedRing3 = ring;
            thirdNumber = (int)ring.Digit;
            CalculateResistor();
        }

        private void SetRing4Color(object obj)
        {
            var ring = obj as Ring;
            SelectedRing4 = ring;
            multiplicator = (double)ring.Multiplicator;
            CalculateResistor();
        }

        private void SetRing5Color(object obj)
        {
            var ring = obj as Ring;
            SelectedRing5 = ring;
            tolerance = (int)ring.Tolerance.Index;
            SelectedTolerance = tolerance;
            Resistor.Tolerance = ring.Tolerance;
            SetResistorDisplay();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void SetRing6Color(object obj)
        {
            var ring = obj as Ring;
            SelectedRing6 = ring;
            SelectedTempCoef = ring.TemperatureCoefficient.Index;
            Resistor.TemperatureCoefficient = ring.TemperatureCoefficient;
            SetResistorDisplay();
        }

        /// <summary>
        /// Calcul de l'ampérage
        /// </summary>
        private double? CalculateAmpere()
        {
            if (ResistorValue.HasValue && Volt.HasValue)
            {
                double r;
                double v;
                if (double.TryParse(Resistor.Value.ToString(), out r) && double.TryParse(Volt.Value.ToString(), out v))
                {
                    return Math.Round(v / r, 6) * 1000;
                }
            }
            return null;
        }

        /// <summary>
        /// Calcul de la puissance
        /// </summary>
        private double? CalculateWatt()
        {
            if (Volt.HasValue && Ampere.HasValue)
            {
                double v;
                double a;
                if (double.TryParse(Volt.Value.ToString(), out v) && double.TryParse(Ampere.Value.ToString(), out a))
                {
                    return Math.Round(v * a, 6);
                }
            }
            return null;
        }

        /// <summary>
        /// Calcul de la serie E
        /// </summary>
        /// <param name="eSerie">Série E</param>
        private string CalculateESerie(ESerie.ESeries eSerie)
        {
            if (ResistorValue.HasValue)
            {
                double temp = Resistor.Value;
                int divisions = 0;
                while (temp >= 10)
                {
                    temp /= 10;
                    divisions++;
                }
                ESerie serie = ESeries.Where(x => x.Name == eSerie).Single();
                double closest = serie.Values.OrderBy(item => Math.Abs(temp - item)).First();
                double val = closest * Math.Pow(10, divisions);
                double gap = ((Resistor.Value - val) / Resistor.Value) * 100;

                int index = 0;
                while (val >= 1000)
                {
                    val /= 1000;
                    ++index;
                }
                return eSerie.ToString() + " : " + val + " " + Multiples[index].Display + " (écart : " + gap.ToString("n2") + " %)";
            }
            return string.Empty;
        }

        private void ChangeNbRings()
        {
            switch (SelectedResistorRing)
            {
                case 0:
                    Ring3Visibility = Visibility.Hidden;
                    Ring6Visibility = Visibility.Hidden;
                    break;
                case 1:
                    Ring3Visibility = Visibility.Visible;
                    Ring6Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Ring3Visibility = Visibility.Visible;
                    Ring6Visibility = Visibility.Visible;
                    break;
            }
            CalculateResistor();
        }
    }
    #endregion
}


