using System;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Caeno.XamarinForms.Toolkit.Droid.Renderers;
using Caeno.XamarinForms.Toolkit;

[assembly: ExportRenderer(typeof(CircularImage), typeof(CircularImageRenderer))]

namespace Caeno.XamarinForms.Toolkit.Droid.Renderers
{
	public class CircularImageRenderer : ImageRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<Image> e) {
			base.OnElementChanged(e);

			if (e.OldElement == null) {
				if ((int)global::Android.OS.Build.VERSION.SdkInt < 18)
					SetLayerType(global::Android.Views.LayerType.Software, null);
			}
		}

		protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime) {
			try {
				// Extract properties
				var source = (CircularImage)Element;
				var borderWidth = source.BorderWidth;
				var borderColor = source.BorderColor.ToAndroid();

				var radius = Math.Min(Width, Height) / 2;
				var strokeWidth = 10;
				radius -= strokeWidth / 2;

				//Create path to clip
				var path = new Path();
				path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
				canvas.Save();
				canvas.ClipPath(path);

				var result = base.DrawChild(canvas, child, drawingTime);

				canvas.Restore();

				// Create path for circle border
				path = new Path();
				path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

				var paint = new Paint();
				paint.AntiAlias = true;
				paint.StrokeWidth = borderWidth;
				paint.SetStyle(Paint.Style.Stroke);
				paint.Color = borderColor;

				canvas.DrawPath(path, paint);

				//Properly dispose
				paint.Dispose();
				path.Dispose();
				return result;
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
			}

			return base.DrawChild(canvas, child, drawingTime);
		}

        internal static void Initialize() {
            var dt = DateTime.Now;
        }

	}
}

