using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using Caeno.XamarinForms.Toolkit;
using Caeno.XamarinForms.Toolkit.iOS.Renderers;

[assembly: ExportRenderer(typeof(EnhancedTabbedPage), typeof(EnhancedTabbedRenderer))]

namespace Caeno.XamarinForms.Toolkit.iOS.Renderers
{
	public class EnhancedTabbedRenderer : TabbedRenderer
	{

		bool _didSetup = false;

		public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear(animated);

			// Customize the Appearance of the UITabBar
			if (!_didSetup) {
				var formsPage = (EnhancedTabbedPage)Element;
				if (formsPage != null) {
					if (formsPage.TabBarColor != Color.Default)
						TabBar.BackgroundColor = formsPage.TabBarColor.ToUIColor();

					if (formsPage.SelectColor != Color.Default)
						TabBar.SelectedImageTintColor = formsPage.TabBarColor.ToUIColor();

					if (!formsPage.IsTabBarVisible)
						TabBar.Hidden = true;
				}
				_didSetup = true;
			}
		}

        internal static void Initialize() {
            var dt = DateTime.Now;
        }

    }
}

