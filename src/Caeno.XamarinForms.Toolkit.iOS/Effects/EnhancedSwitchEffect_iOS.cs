using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using System.Linq;
using Caeno.XamarinForms.Toolkit.iOS.Effects;

[assembly: ResolutionGroupName("Caeno.XamarinForms.Toolkit")]
[assembly: ExportEffect(typeof(EnhancedSwitchEffect_iOS), "EnhancedSwitchEffect")]

namespace Caeno.XamarinForms.Toolkit.iOS.Effects
{

    public class EnhancedSwitchEffect_iOS : PlatformEffect {

		protected override void OnAttached() {
			var theSwitch = (UISwitch)Control;
			var effect = (EnhancedSwitchEffect)Element.Effects
                                  .FirstOrDefault(e => e is EnhancedSwitchEffect);

			theSwitch.OnTintColor = effect.EnabledBackgroundColor.ToUIColor();
		}

		protected override void OnDetached() {
		}

	}

}
