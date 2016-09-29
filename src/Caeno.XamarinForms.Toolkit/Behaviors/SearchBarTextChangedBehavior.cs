using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	public class SearchBarTextChangedBehavior : Behavior<SearchBar>
	{

		public static readonly BindableProperty TextChangedCommandProperty =
			BindableProperty.Create("TextChangedCommand",
				typeof(ICommand),
				typeof(SearchBarTextChangedBehavior),
				null);

		public ICommand TextChangedCommand {
			get { return (ICommand)GetValue(TextChangedCommandProperty); }
			set { SetValue(TextChangedCommandProperty, value); }
		}

		public SearchBar AssociatedObject { get; private set; }

		protected override void OnAttachedTo(SearchBar bindable) {
			base.OnAttachedTo(bindable);
			AssociatedObject = bindable;
			bindable.BindingContextChanged += OnBindingContextChanged;
			bindable.TextChanged += OnTextChanged;
		}

		protected override void OnDetachingFrom(SearchBar bindable) {
			base.OnDetachingFrom(bindable);
			bindable.TextChanged -= OnTextChanged;
		}

		protected override void OnBindingContextChanged() {
			base.OnBindingContextChanged();
			BindingContext = AssociatedObject.BindingContext;
		}

		void OnBindingContextChanged(object sender, EventArgs e) {
			OnBindingContextChanged();
		}

		void OnTextChanged(object sender, TextChangedEventArgs e) {
			if (TextChangedCommand == null)
				return;

			var param = AssociatedObject.Text;
			if (TextChangedCommand.CanExecute(param))
				TextChangedCommand.Execute(param);
		}

	}
}

