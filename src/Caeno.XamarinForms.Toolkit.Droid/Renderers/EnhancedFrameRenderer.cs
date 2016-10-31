using System;
using System.ComponentModel;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Caeno.XamarinForms.Toolkit.Droid.Renderers;
using Caeno.XamarinForms.Toolkit;

[assembly: Xamarin.Forms.ExportRenderer(typeof(EnhancedFrame), typeof(EnhancedFrameRenderer))]

namespace Caeno.XamarinForms.Toolkit.Droid.Renderers
{
	
	public class EnhancedFrameRenderer : VisualElementRenderer<EnhancedFrame>
	{
		private GradientDrawable backgroundDrawable;

		protected override void OnElementChanged(ElementChangedEventArgs<EnhancedFrame> e) {
            // Create a drawable for the background and set the Attributes
            var frame = e.NewElement as EnhancedFrame;
            backgroundDrawable = new GradientDrawable();
			backgroundDrawable.SetColor(frame.BackgroundColor.ToAndroid());
			backgroundDrawable.SetStroke(DensityPointsToPixels(frame.BorderWidth), frame.BorderColor.ToAndroid());
			backgroundDrawable.SetCornerRadius(DensityPointsToPixels(frame.CornerRadius));
            this.SetBackground(backgroundDrawable);

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
			base.OnElementPropertyChanged(sender, e);
		}

        internal static void Initialize() {
            var dt = DateTime.Now;
        }

        int DensityPointsToPixels(int dps) {
            var scale = Resources.DisplayMetrics.Density;
            var dpAsPixels = (int)(dps * scale + 0.5f);
            return dpAsPixels;
        }

    }

}
