using System;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	public class EnhancedFrame : ContentView
	{

		public readonly static BindableProperty BorderRadiusProperty = BindableProperty.Create("BorderRadius", typeof(int), typeof(EnhancedFrame), 5, BindingMode.OneWay, null, null, null, null, null);

		public readonly static BindableProperty OutlineColorProperty = BindableProperty.Create("OutlineColor", typeof(Color), typeof(EnhancedFrame), Color.Default, BindingMode.OneWay, null, null, null, null, null);

		public readonly static BindableProperty BorderWidthProperty = BindableProperty.Create("BorderWidth", typeof(int), typeof(EnhancedFrame), 2, BindingMode.OneWay, null, null, null, null, null);

		public int BorderWidth {
			get {
				return (int)base.GetValue(EnhancedFrame.BorderWidthProperty);
			}
			set {
				base.SetValue(EnhancedFrame.BorderWidthProperty, value);
			}
		}

		public Color OutlineColor {
			get {
				return (Color)base.GetValue(EnhancedFrame.OutlineColorProperty);
			}
			set {
				base.SetValue(EnhancedFrame.OutlineColorProperty, value);
			}
		}

		public int BorderRadius {
			get {
				return (int)base.GetValue(EnhancedFrame.BorderRadiusProperty);
			}
			set {
				base.SetValue(EnhancedFrame.BorderRadiusProperty, value);
			}
		}

	}

}
