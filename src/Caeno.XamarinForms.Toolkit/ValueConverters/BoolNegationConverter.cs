using System;
using System.Globalization;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	
	public class BoolNegationConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			return !(bool)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			return !(bool)value;
		}
	}

}
