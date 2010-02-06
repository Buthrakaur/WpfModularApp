﻿namespace BackgroundProcessing.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class HiddenWhenHigherConverter : IValueConverter
    {
        public static HiddenWhenHigherConverter Instance = new HiddenWhenHigherConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = (int)value;
            var min = System.Convert.ToInt32(parameter);
            return count > min
                       ? Visibility.Hidden
                       : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}