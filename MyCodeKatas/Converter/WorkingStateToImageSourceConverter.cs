using System;
using System.Globalization;
using System.Windows.Data;

namespace MyCodeKatas.Converter
{
    class WorkingStateToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source;
            switch ((WorkingState)value)
            {
                case WorkingState.New:
                    source = "";
                    break;
                case WorkingState.Active:
                    source = "/Images/active.png";
                    break;
                case WorkingState.Resolved:
                    source = "/Images/resolved.png";
                    break;
                case WorkingState.Closed:
                    source = "/Images/closed.png";
                    break;
                default:
                    source = "/Images/problem.png";
                    break;
            }
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}