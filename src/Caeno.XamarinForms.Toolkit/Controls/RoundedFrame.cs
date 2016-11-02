using System;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	public class RoundedFrame : ContentView
	{

		public readonly static BindableProperty CornerRadiusProperty = 
            BindableProperty.Create("BorderRadius", 
                typeof(int), 
                typeof(RoundedFrame), 5, 
                BindingMode.OneWay);

		public readonly static BindableProperty BorderColorProperty = 
            BindableProperty.Create("OutlineColor", 
                typeof(Color), 
                typeof(RoundedFrame), 
                Color.Default, 
                BindingMode.OneWay);

		public readonly static BindableProperty BorderWidthProperty = 
            BindableProperty.Create("BorderWidth", 
                typeof(int), 
                typeof(RoundedFrame), 2, 
                BindingMode.OneWay);

        /// <summary>
        /// The Border Width.
        /// </summary>
		public int BorderWidth {
			get { return (int)GetValue(RoundedFrame.BorderWidthProperty); }
			set { SetValue(RoundedFrame.BorderWidthProperty, value); }
		}

        /// <summary>
        /// The Color of the Border.
        /// </summary>
		public Color BorderColor {
			get { return (Color)GetValue(RoundedFrame.BorderColorProperty); }
			set { SetValue(RoundedFrame.BorderColorProperty, value); }
		}

        /// <summary>
        /// The Border Corners Radius.
        /// </summary>
		public int CornerRadius {
			get { return (int)GetValue(RoundedFrame.CornerRadiusProperty); }
			set { SetValue(RoundedFrame.CornerRadiusProperty, value); }
		}

	}

}
