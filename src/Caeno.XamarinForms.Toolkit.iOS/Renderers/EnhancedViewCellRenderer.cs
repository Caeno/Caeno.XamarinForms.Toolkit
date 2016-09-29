using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using Caeno.XamarinForms.Toolkit;
using Caeno.XamarinForms.Toolkit.iOS.Renderers;

[assembly:ExportRenderer(typeof(EnhancedViewCell), typeof(EnhancedViewCellRenderer))]
namespace Caeno.XamarinForms.Toolkit.iOS.Renderers
{
	public class EnhancedViewCellRenderer : ViewCellRenderer
	{

		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {
			var cell = base.GetCell(item, reusableCell, tv);
			var nativeCell = (EnhancedViewCell)item;

			if (!nativeCell.IsSelectable)
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;

			return cell;
		}

        internal static void Initialize() {
            var dt = DateTime.Now;
        }

    }
}

