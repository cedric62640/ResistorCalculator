using System;
using System.Windows.Data;

namespace ResistorCalculator.Converter
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is double)
            {
                return value.ToString();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double v = 0;
            bool b = double.TryParse(value.ToString(), out v);
            if(b)
            {
                return v;
            }
            return value;
        }
    }
}
