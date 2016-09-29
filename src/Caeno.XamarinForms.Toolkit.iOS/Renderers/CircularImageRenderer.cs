using Caeno.XamarinForms.Toolkit;
using Caeno.XamarinForms.Toolkit.iOS.Renderers;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircularImage), typeof(CircularImageRenderer))]

namespace Caeno.XamarinForms.Toolkit.iOS.Renderers
{
	
	public class CircularImageRenderer : ImageRenderer
	{
		
		public CircularImageRenderer() {
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Image> e) {
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null)
				return;

			CreateCircle();
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
				e.PropertyName == VisualElement.WidthProperty.PropertyName)
				CreateCircle();
		}

		void CreateCircle() {
			try {
				var source = (CircularImage)Element;

				double min = Math.Min(Element.Width, Element.Height);
				Control.Layer.CornerRadius = (float)(min / 2.0);
				Control.Layer.MasksToBounds = false;
				Control.Layer.BorderColor = source.BorderColor.ToCGColor();
				Control.Layer.BorderWidth = source.BorderWidth;
				Control.ClipsToBounds = true;
			} catch (Exception ex) {
				Debug.WriteLine("Unable to create circle image: " + ex);
			}
		}

        internal static void Initialize() {
            var dt = DateTime.Now;
        }

    }

}

