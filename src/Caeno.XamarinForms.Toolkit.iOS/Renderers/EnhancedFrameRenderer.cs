using Caeno.XamarinForms.Toolkit;
using Caeno.XamarinForms.Toolkit.iOS.Renderers;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EnhancedFrame), typeof(EnhancedFrameRenderer))]

namespace Caeno.XamarinForms.Toolkit.iOS.Renderers
{
	public class EnhancedFrameRenderer : VisualElementRenderer<EnhancedFrame>
	{

		private EnhancedFrame _control;

		public EnhancedFrameRenderer() {
		}

		protected override void OnElementChanged(ElementChangedEventArgs<EnhancedFrame> e) {
			base.OnElementChanged(e);
			if (e.NewElement != null) {
				_control = e.NewElement as EnhancedFrame;
				this.SetupLayer(_control.BorderWidth, _control?.CornerRadius ?? 5);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == EnhancedFrame.BorderColorProperty.PropertyName || e.PropertyName == EnhancedFrame.BorderWidthProperty.PropertyName) {
				this.SetupLayer(_control?.BorderWidth ?? 5, _control?.CornerRadius ?? 5);
			}
		}

		private void SetupLayer(int borderWidth, nfloat borderRadius) {

			Layer.CornerRadius = borderRadius;
			if (Element.BackgroundColor != Color.Default) {
				Layer.BackgroundColor = Element.BackgroundColor.ToCGColor();
			} else {
				Layer.BackgroundColor = UIColor.White.CGColor;
			}
			//if (!base.Element.HasShadow) 
			//{ 
			//  this.get_Layer().set_ShadowOpacity(0f); 
			//} 
			//else 
			//{ 
			//  this.get_Layer().set_ShadowRadius(5); 
			//  this.get_Layer().set_ShadowColor(UIColor.get_Black().get_CGColor()); 
			//  this.get_Layer().set_ShadowOpacity(0.8f); 
			//  this.get_Layer().set_ShadowOffset(new SizeF()); 
			//} 
			if (Element.BorderColor != Color.Default) {
				this.Layer.BorderColor = base.Element.BorderColor.ToCGColor();
				this.Layer.BorderWidth = borderWidth / 2;
			} else {
				this.Layer.BorderColor = UIColor.Clear.CGColor;
			}
			this.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
			this.Layer.ShouldRasterize = true;
			this.Layer.MasksToBounds = true;
		}

        internal static void Initialize() {
            var dt = DateTime.Now;
        }

    }
}
