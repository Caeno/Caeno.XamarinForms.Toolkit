using System;
using System.ComponentModel;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Caeno.XamarinForms.Toolkit.Android.Renderers;
using Caeno.XamarinForms.Toolkit;

[assembly: Xamarin.Forms.ExportRenderer(typeof(EnhancedFrame), typeof(EnhancedFrameRenderer))]

namespace Caeno.XamarinForms.Toolkit.Android.Renderers
{
	
	public class EnhancedFrameRenderer : VisualElementRenderer<EnhancedFrame>
	{
		private GradientDrawable _normal, _pressed;

		protected override void OnElementChanged(ElementChangedEventArgs<EnhancedFrame> e) {

			EnhancedFrame customFram = e.NewElement as EnhancedFrame;
			// Create a drawable for the button's normal state 
			_normal = new GradientDrawable();
			_normal.SetColor(customFram.BackgroundColor.ToAndroid());
			_normal.SetStroke(customFram.BorderWidth, customFram.OutlineColor.ToAndroid());
			_normal.SetCornerRadius(customFram.BorderRadius);
			SetBackgroundDrawable(_normal);
			//SetBackgroundColor(customFram.BackgroundColor.ToAndroid()); 
			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
			base.OnElementPropertyChanged(sender, e);
		}

        internal static void Initialize() {
            var dt = DateTime.Now;
        }

    }

}
