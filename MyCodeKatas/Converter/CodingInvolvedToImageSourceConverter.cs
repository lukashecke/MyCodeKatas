using System;
using System.Globalization;
using System.Windows.Data;

namespace MyCodeKatas.Converter
{
    class CodingInvolvedToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((bool)value)==false)
            {
                return "/Images/thinking.png";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}