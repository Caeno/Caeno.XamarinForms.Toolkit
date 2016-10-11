using System;
using Xamarin.Forms;
using System.Linq;
using System.Text;

namespace Caeno.XamarinForms.Toolkit.Temp {

	/// <summary>
	/// A Xamarin.Forms Behavior to enhance Entries with masked entry, such as allowing
	/// 	just numeric input, define a Maximum input lenght and determining a component
	/// 	to send focus to when maximum size is reached.
	/// </summary>
	public class MaskedEntryBehavior : Behavior<Entry> {

		static char[] _digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

		#region Properties

		public static readonly BindableProperty MaxLenghtProperty =
			BindableProperty.Create("MaxLenght",
				typeof(int), typeof(MaskedEntryBehavior), 0);

		/// <summary>
		/// Gets or sets the max lenght that this input should allow.
		/// </summary>
		public int MaxLenght {
			get { return (int)GetValue(MaxLenghtProperty); }
			set { SetValue(MaxLenghtProperty, value); }
		}

		public static readonly BindableProperty InputTypeProperty =
			BindableProperty.Create("InputType",
				typeof(MaskedInputType),
					  typeof(MaskedEntryBehavior),
					  MaskedInputType.Alphanumeric);

		/// <summary>
		/// Gets or sets the Input Type of this Entry. Defaults for Alphanumeric.
		/// </summary>
		public MaskedInputType InputType {
			get { return (MaskedInputType)GetValue(InputTypeProperty); }
			set { SetValue(InputTypeProperty, value); }
		}


		public static readonly BindableProperty NextElementProperty =
			BindableProperty.Create("NextElement",
				typeof(View),
                typeof(MaskedEntryBehavior),
				null);

		/// <summary>
		/// Determine the next element to focus when MaxLenght is Reached.
		/// </summary>
		public View NextElement {
			get { return (View)GetValue(NextElementProperty); }
			set { SetValue(NextElementProperty, value); }
		}

		#endregion


		void EntryChangedHandler(object sender, TextChangedEventArgs e) {
			var entry = (Entry)sender;

			//
			// Check if there's only numeric inputs in case of Numeric Input Type
			if (InputType == MaskedInputType.Numeric) {
				var newString = new StringBuilder();
				foreach (var c in entry.Text) {
					if (_digits.Any(d => d == c))
						newString.Append(c);
				}

				entry.Text = newString.ToString();
			}

			//
			// Check if there's a Max Lenght and if it's reached
			if (MaxLenght > 0) {
				if (entry.Text.Length > MaxLenght) {
					entry.Text = entry.Text.Substring(0, MaxLenght);
				}
			}

			// Last, check if there's a last element
			if (NextElement != null && entry.Text.Length == MaxLenght)
				NextElement.Focus();
		}

		void EntryCompletedHandler(object sender, EventArgs e) {
			if (NextElement != null)
				NextElement.Focus();
		}

		protected override void OnAttachedTo(Entry entry) {
			base.OnAttachedTo(entry);

			entry.TextChanged += EntryChangedHandler;
			entry.Completed += EntryCompletedHandler;
		}

		protected override void OnDetachingFrom(Entry entry) {
			base.OnDetachingFrom(entry);

			entry.TextChanged -= EntryChangedHandler;
			entry.Completed -= EntryCompletedHandler;
		}

	}

	public enum MaskedInputType {
		Alphanumeric,
		Numeric
	}

}
