using System;
using System.Globalization;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit.Temp
{
	public class EmptyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}
