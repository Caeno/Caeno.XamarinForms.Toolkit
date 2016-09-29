using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	public class BaseAsyncActivityContentPage : ContentPage
	{

		static ControlTemplate BaseTemplate = new ControlTemplate(typeof(BaseAsyncActivityTemplate));

		#region Properties

		public static readonly BindableProperty IsActivityRunningProperty =
			BindableProperty.Create("IsActivityRunning",
				typeof(bool),
				typeof(BaseAsyncActivityContentPage),
				false);

		public bool IsActivityRunning {
			get { return (bool)GetValue(IsActivityRunningProperty); }
			set { SetValue(IsActivityRunningProperty, value); }
		}

		public static readonly BindableProperty ActivityDescriptionProperty =
			BindableProperty.Create("ActivityDescription",
				typeof(string),
				typeof(BaseAsyncActivityContentPage),
				null);

		public string ActivityDescription {
			get { return (string)GetValue(ActivityDescriptionProperty); }
			set { SetValue(ActivityDescriptionProperty, value); }
		}

		#endregion

		public BaseAsyncActivityContentPage() {
			ControlTemplate = BaseTemplate;
		}


		#region Utility Methods


		protected async void RunOnBackground(Func<Task> action) {
			IsActivityRunning = true;
			await action();
			IsActivityRunning = false;
		}


		#endregion


		#region Inner Types

		class BaseAsyncActivityTemplate : Grid
		{

			public BaseAsyncActivityTemplate() {
				// Adds the Content Presenter
				var contentPresenter = new ContentPresenter();
				Children.Add(contentPresenter, 0, 0);

				// The overlay that is presented when an Activity is Running
				var overlayGrid = new Grid { BackgroundColor = Color.FromHex("#CCCCCCCC") };
				overlayGrid.SetBinding(IsVisibleProperty, new TemplateBinding("IsActivityRunning"));

				var descriptionLabel = new Label { TextColor = Color.White };
				descriptionLabel.SetBinding(Label.TextProperty, new TemplateBinding("ActivityDescription"));

				var activityIndicator = new ActivityIndicator { Color = Color.White };
				activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, new TemplateBinding("IsActivityRunning"));

				// A layout to hold the Activity Indicator and Description
				var activityIndicatorLayout = new StackLayout {
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
				};
				activityIndicatorLayout.Children.Add(activityIndicator);
				activityIndicatorLayout.Children.Add(descriptionLabel);

				// Finally add the indicator to the overlay and the overlay to the grid
				overlayGrid.Children.Add(activityIndicatorLayout, 0, 0);
				Children.Add(overlayGrid);
			}

		}

		#endregion

	}

}


