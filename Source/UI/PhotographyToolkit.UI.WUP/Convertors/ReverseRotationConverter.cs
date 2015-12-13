namespace PhotographyToolkit.UI.WUP.Convertors
{
    using System;

    using Windows.UI.Xaml.Data;

    public class ReverseRotationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double)
            {
                return 360 - (double)value;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is double)
            {
                return 360 - (double)value;
            }

            return value;
        }
    }
}
