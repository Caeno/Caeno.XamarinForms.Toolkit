using System;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	public class EnhancedViewCell : ViewCell
	{
		
		public static readonly BindableProperty IsSelectableProperty =
			BindableProperty.Create("IsSelectable",
				typeof(bool),
				typeof(EnhancedViewCell),
				true);

		public bool IsSelectable {
			get { return (bool)GetValue(IsSelectableProperty); }
			set { SetValue(IsSelectableProperty, value); }
		}

	}
}

