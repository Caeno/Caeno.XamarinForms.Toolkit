using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{

	/// <summary>
	/// A XAML Binding Value Converter to load images from embbeded-resources.
	/// </summary>
	public class ImageResourceConverter : IValueConverter
	{

		private static Assembly _sourceAssembly;

		public static Assembly SourceAssembly {
			get { return _sourceAssembly; }
			set { _sourceAssembly = value; }
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			var sourceText = value as string;
			if (sourceText == null)
				return null;

			// Ensure that the resource is loaded from the correctly setup assembly.
			ImageSource source;
			if (SourceAssembly != null)
				source = ImageSource.FromResource(sourceText, SourceAssembly);
			else
				source = ImageSource.FromResource(sourceText);

			return source;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotSupportedException("The type can't be cast back.");
		}
	}
}

