﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Task2.Utils
{
    public sealed class TileColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int v = value is int i ? i : 0;
            string hex = v switch
            {
                0 => "#CEC3B2",
                2 => "#EEE4DA",
                4 => "#EDE0C8",
                8 => "#F2B179",
                16 => "#F59563",
                32 => "#F67C5F",
                64 => "#F65E3B",
                128 => "#EDCF72",
                256 => "#EDCC61",
                512 => "#EDC850",
                1024 => "#EDC53F",
                2048 => "#EDC22E",
                _ => "#3C3A32"
            };
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(hex)!);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
