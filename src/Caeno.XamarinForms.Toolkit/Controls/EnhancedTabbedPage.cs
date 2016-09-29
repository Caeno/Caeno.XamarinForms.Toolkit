using System;

using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{

	/// <summary>
	/// An enhanced version of the Xamarin.Forms TabbedPage
	/// </summary>
	public class EnhancedTabbedPage : TabbedPage
	{

		/// <summary>
		/// Gets or sets wheter the Tab Bar should be visible, defaults to true.
		/// </summary>
		public bool IsTabBarVisible { get; set; } = true;

		/// <summary>
		/// Gets or sets the color of the tab bar.
		/// </summary>
		public Color TabBarColor { get; set; } = Color.Default;

		/// <summary>
		/// Gets or sets the color of the selected tab item.
		/// </summary>
		public Color SelectColor { get; set; } = Color.Default;

	}
}


