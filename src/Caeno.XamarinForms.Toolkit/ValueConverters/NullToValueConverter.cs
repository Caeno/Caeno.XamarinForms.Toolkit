using System;
using System.Globalization;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{

	/// <summary>
	/// A XAML Value Converter that returns an Optional value when the binded value is null.
	/// </summary>
	public class NullToValueConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			// Check if the object is null, in that case return the Converter parameter
			if (value == null)
				return parameter;

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			// Just return the plain object because there's no back conversion
			return value;
		}

	}
}

