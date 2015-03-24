using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Kabel.DemoWPF.Converters.Assets.Converters
{
    public class TrafficLightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var percentage = System.Convert.ToInt16(value);

                if (percentage > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (percentage <= 60)
                {
                    return new SolidColorBrush(Colors.Green);
                }
                else if (percentage > 60 && percentage <= 75)
                {
                    return new SolidColorBrush(Colors.DarkOrange);
                }
                else
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
