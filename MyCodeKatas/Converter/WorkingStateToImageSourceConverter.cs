using System;
using System.Globalization;
using System.Windows.Data;

namespace MyCodeKatas.Converter
{
    class WorkingStateToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source = string.Empty;
            switch ((WorkingState)value)
            {
                case WorkingState.NotStarted:
                    source = "";
                    break;
                case WorkingState.InProgress:
                    source = "/Images/in_progress.png";
                    break;
                case WorkingState.Finished:
                    source = "/Images/finished.png";
                    break;
                default:
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