using Caeno.XamarinForms.Toolkit.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(BasePageRenderer))]
namespace Caeno.XamarinForms.Toolkit.iOS.Renderers
{

	/// <summary>
	/// An extended PageRenderer that allow setting UIBarButtonItems to the left.
	/// </summary>
	public class BasePageRenderer : PageRenderer
	{

		public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear(animated);

			// If there's no Navigation Controller exists
			if (NavigationController == null)
				return;

			// Retrieve all the items
			var navigationItem = NavigationController.TopViewController.NavigationItem;
			var leftNativeButtons = (navigationItem.LeftBarButtonItems ?? new UIBarButtonItem[] { }).ToList();
			var rightNativeButtons = (navigationItem.RightBarButtonItems ?? new UIBarButtonItem[] { }).ToList();

			// Check if there's items in the Right side, if don't just left
			if (rightNativeButtons.Count == 0)
				return;

			// Process what items should be moved to left
			var itemsInfo = (Element as Page).ToolbarItems;
			var buttonsToMove = new List<UIBarButtonItem>();
			rightNativeButtons.ForEach(nativeItem => {
				var info = GetToolbarItem(itemsInfo, nativeItem.Title);
				if (info == null || info.Priority != 0) {
					if (info?.Priority == 1)
						nativeItem.Style = UIBarButtonItemStyle.Done;

					return;
				}

				buttonsToMove.Add(nativeItem);
			});

			// Move items to left
			buttonsToMove.ForEach(nativeItem => {
				rightNativeButtons.Remove(nativeItem);
				leftNativeButtons.Add(nativeItem);
			});

			// Reconfigure the Buttons
			navigationItem.RightBarButtonItems = rightNativeButtons.ToArray();
			navigationItem.LeftBarButtonItems = leftNativeButtons.ToArray();
		}

		/// <summary>
		/// Get the ToolbarItem reference by it's name.
		/// </summary>
		/// <returns>The ToolbarItem object that references the UIBarButtonInfo.</returns>
		/// <param name="items">The list of Items.</param>
		/// <param name="title">The button title.</param>
		ToolbarItem GetToolbarItem(IList<ToolbarItem> items, string title) {
			if (string.IsNullOrEmpty(title) || items == null)
				return null;

			return items.ToList().FirstOrDefault(itemData => title.Equals(itemData.Text));
		}

        internal static void Initialize() {
            var dt = DateTime.Now;
        }

    }
}

