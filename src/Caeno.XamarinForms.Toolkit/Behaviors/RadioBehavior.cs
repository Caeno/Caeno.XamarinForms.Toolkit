using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	
	public class RadioBehavior : Behavior<View>
	{
		TapGestureRecognizer tapRecognizer;
		static List<RadioBehavior> defaultGroup = new List<RadioBehavior>();
		static Dictionary<string, List<RadioBehavior>> radioGroups = new Dictionary<string, List<RadioBehavior>>();

		#region Properties

		public static readonly BindableProperty IsCheckedProperty =
			BindableProperty.Create("IsChecked",
									typeof(bool),
									typeof(RadioBehavior),
									false,
									BindingMode.TwoWay,
									propertyChanged: OnIsCheckedChanged);

		public bool IsChecked
		{
			get { return (bool)GetValue(IsCheckedProperty); }
			set { SetValue(IsCheckedProperty, value); }
		}

		static void OnIsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var behavior = (RadioBehavior)bindable;

			if ((bool)newValue)
			{
				var groupName = behavior.GroupName;
				List<RadioBehavior> behaviors = null;

				if (string.IsNullOrEmpty(groupName))
					behaviors = defaultGroup;
				else
					behaviors = radioGroups[groupName];

				foreach (var otherBehavior in behaviors)
				{
					if (otherBehavior != behavior)
						otherBehavior.IsChecked = false;
				}
			}

			behavior.CheckedChanged?.Invoke(behavior, new RadioCheckedChangedEventArgs {
				IsChecked = behavior.IsChecked,
				Value = behavior.Value
			});
		}

		public static readonly BindableProperty ValueProperty =
			BindableProperty.Create("Value",
								    typeof(object),
									typeof(RadioBehavior),
									null,
									BindingMode.TwoWay);

		public object Value {
			get { return GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value);}
		}

		public static readonly BindableProperty GroupNameProperty =
			BindableProperty.Create("GroupName",
									typeof(string),
									typeof(RadioBehavior),
									null,
									BindingMode.TwoWay,
								   	propertyChanged: OnGroupNameChanged);

		public string GroupName
		{
			get { return (string)GetValue(GroupNameProperty); }
			set { SetValue(GroupNameProperty, value); }
		}

		static void OnGroupNameChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var behavior = (RadioBehavior)bindable;
			string oldGroupName = (string)oldValue;
			string newGroupName = (string)newValue;

			if (string.IsNullOrEmpty(oldGroupName))
			{
				// Remove the Behavior from the default group
				defaultGroup.Remove(behavior);
			}
			else {
				// Remove the RadioBehavior from the radioGroups collection.
				var behaviors = radioGroups[oldGroupName];
				behaviors.Remove(behavior);

				// Get rid of the collection if it's empty.
				if (behaviors.Count == 0)
					radioGroups.Remove(oldGroupName);
			}

			if (string.IsNullOrEmpty(newGroupName))
			{
				// Add the new Behavior to the default group.
				defaultGroup.Add(behavior);
			}
			else {
				List<RadioBehavior> behaviors = null;

				if (radioGroups.ContainsKey(newGroupName))
				{
					// Get the named group.
					behaviors = radioGroups[newGroupName];
				}
				else {
					// If that group doesn't exist, create it.
					behaviors = new List<RadioBehavior>();
					radioGroups.Add(newGroupName, behaviors);
				}

				// Add the Behavior to the group.
				behaviors.Add(behavior);
			}
		}

		public event EventHandler<RadioCheckedChangedEventArgs> CheckedChanged;

		#endregion

		public RadioBehavior()
		{
			defaultGroup.Add(this);
		}

		protected override void OnAttachedTo(View view) {
			base.OnAttachedTo(view);

            if (view is Button) {
                ((Button)view).Clicked += ItemSelectedHandler;
            } else {
                tapRecognizer = new TapGestureRecognizer();
                tapRecognizer.Tapped += ItemSelectedHandler;
                view.GestureRecognizers.Add(tapRecognizer);
            }
        }

		protected override void OnDetachingFrom(View view) {
			base.OnDetachingFrom(view);

            if (view is Button) {
                ((Button)view).Clicked -= ItemSelectedHandler;
            } else {
                view.GestureRecognizers.Remove(tapRecognizer);
                tapRecognizer.Tapped -= ItemSelectedHandler;
            }
		}

		void ItemSelectedHandler(object sender, EventArgs args) {
			IsChecked = true;
		}

	}

	public class RadioCheckedChangedEventArgs : EventArgs {

		public bool IsChecked { get; set; }

		public object Value { get; set; }

	}

}
