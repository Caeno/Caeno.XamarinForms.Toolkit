using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{

	/// <summary>
	/// An Enhanced version of Xamarin.Forms Picker that allows Binding to Items and Selected Value.
	/// </summary>
	public class EnhancedPicker : Picker
	{

		IList _sourceData;

		public EnhancedPicker() : base() {
			SelectedIndexChanged += (sender, e) => {
				if (_sourceData != null) {
					if (SelectedIndex == -1)
						SetValue(SelectedValueProperty, null);
					else {
						var value = _sourceData[SelectedIndex];
						SetValue(SelectedValueProperty, value);
					}
				}
			};
		}

		#region Properties

		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create("ItemsSource",
									typeof(IEnumerable),
									typeof(EnhancedPicker),
									null,
				propertyChanged: (bindable, oldValue, newValue) => {
					((EnhancedPicker)bindable).OnItemsSourceSet((IEnumerable)newValue);
				});

		public IEnumerable ItemsSource {
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		void OnItemsSourceSet(IEnumerable data) {
			// Reset internal data structure
			var objects = new List<object>();
			foreach (var o in data)
				objects.Add(o);

			_sourceData = objects;

			// Reset the items structure
			Items.Clear();
			foreach (var i in _sourceData) {
				Items.Add(i.ToString());
			}

			UpdateSelectedValue();
		}

		public static readonly BindableProperty SelectedValueProperty =
			BindableProperty.Create("SelectedValue",
				typeof(object),
				typeof(EnhancedPicker),
				null,
				propertyChanged: (bindable, oldValue, newValue) => {
					var picker = (EnhancedPicker)bindable;
					if (newValue != null &&
						picker._sourceData != null &&
						picker._sourceData.Contains(newValue)) {

						var newValueIndex = picker._sourceData.IndexOf(newValue);
						if (picker.SelectedIndex != newValueIndex)
							picker.SelectedIndex = newValueIndex;
					}
				});

		public object SelectedValue {
			get { return GetValue(SelectedValueProperty); }
			set { SetValue(SelectedValueProperty, value); }
		}

		#endregion


		void UpdateSelectedValue() {
			if (SelectedValue != null &&
			    _sourceData != null &&
			    _sourceData.Contains(SelectedValue)) {

				SelectedIndex = _sourceData.IndexOf(SelectedValue);
			}
		}

	}
}

