using System;

using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	public class CircularImage : Image
	{


		#region Properties

		public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
			propertyName: "BorderWidth",
			returnType: typeof(float),
			declaringType: typeof(CircularImage),
			defaultValue: 0.0f);

		public float BorderWidth {
			get { return (float)GetValue(BorderWidthProperty); }
			set { SetValue(BorderWidthProperty, value); }
		}


		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
			propertyName: "BorderColor",
			returnType: typeof(Color),
			declaringType: typeof(CircularImage),
			defaultValue: Color.Transparent);

		public Color BorderColor {
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		#endregion

	}
}


