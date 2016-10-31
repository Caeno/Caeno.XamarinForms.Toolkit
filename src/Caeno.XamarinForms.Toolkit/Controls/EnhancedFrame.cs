using System;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	public class EnhancedFrame : ContentView
	{

		public readonly static BindableProperty CornerRadiusProperty = 
            BindableProperty.Create("BorderRadius", 
                typeof(int), 
                typeof(EnhancedFrame), 5, 
                BindingMode.OneWay);

		public readonly static BindableProperty BorderColorProperty = 
            BindableProperty.Create("OutlineColor", 
                typeof(Color), 
                typeof(EnhancedFrame), 
                Color.Default, 
                BindingMode.OneWay);

		public readonly static BindableProperty BorderWidthProperty = 
            BindableProperty.Create("BorderWidth", 
                typeof(int), 
                typeof(EnhancedFrame), 2, 
                BindingMode.OneWay);

        /// <summary>
        /// The Border Width.
        /// </summary>
		public int BorderWidth {
			get { return (int)GetValue(EnhancedFrame.BorderWidthProperty); }
			set { SetValue(EnhancedFrame.BorderWidthProperty, value); }
		}

        /// <summary>
        /// The Color of the Border.
        /// </summary>
		public Color BorderColor {
			get { return (Color)GetValue(EnhancedFrame.BorderColorProperty); }
			set { SetValue(EnhancedFrame.BorderColorProperty, value); }
		}

        /// <summary>
        /// The Border Corners Radius.
        /// </summary>
		public int CornerRadius {
			get { return (int)GetValue(EnhancedFrame.CornerRadiusProperty); }
			set { SetValue(EnhancedFrame.CornerRadiusProperty, value); }
		}

	}

}
