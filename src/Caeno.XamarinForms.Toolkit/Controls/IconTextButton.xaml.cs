using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{

    /// <summary>
    /// Declares a Button that haves a Left Icon and a Text.
    /// </summary>
    public partial class IconTextButton : ContentView
    {
        public event EventHandler Clicked;

        #region Properties

        public static readonly BindableProperty IsAnimateOnClickProperty = BindableProperty.Create("IsAnimateOnClick",
            typeof(bool),
            typeof(IconTextButton),
            true);

        /// <summary>
        /// A Flag indicating if the Button is animated when the user taps.
        /// </summary>
        public bool IsAnimateOnClick {
            get { return (bool)GetValue(IsAnimateOnClickProperty); }
            set { SetValue(IsAnimateOnClickProperty, value); }
        }


        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command",
            typeof(ICommand),
            typeof(IconTextButton),
            null);

        /// <summary>
        /// The Command associated with the Click of this Button.
        /// </summary>
        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter",
            typeof(object),
            typeof(IconTextButton),
            null);

        /// <summary>
        /// The Parameter passed to the Command of this Button.
        /// </summary>
        public object CommandParameter {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create("IconSource",
            typeof(FileImageSource),
            typeof(IconTextButton),
            null,
            propertyChanged: (bindable, oldValue, newValue) => {
                ((IconTextButton)bindable).TheImage.Source = (FileImageSource)newValue;
            });

        /// <summary>
        /// The Source of the Image that holds the Icon displayed by the Button.
        /// </summary>
        public FileImageSource IconSource {
            get { return (FileImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }


        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily",
            typeof(string),
            typeof(IconTextButton),
            null,
            propertyChanged: (bindable, oldValue, newValue) => {
                ((IconTextButton)bindable).TheText.FontFamily = (string)newValue;
            });


        /// <summary>
        /// The Font Family Applied to the Text.
        /// </summary>
        public string FontFamily {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }


        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize",
            typeof(double),
            typeof(IconTextButton),
            Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            propertyChanged: (bindable, oldValue, newValue) => {
                ((IconTextButton)bindable).TheText.FontSize = (double)newValue;
            });

        /// <summary>
        /// The Size of the Font Applied to the Text.
        /// </summary>
        public double FontSize {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }


        public static readonly BindableProperty NameProperty = BindableProperty.Create("Name",
            typeof(string),
            typeof(object),
            null);

        public string Name {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }


        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor",
            typeof(Color),
            typeof(IconTextButton),
            default(Color),
            propertyChanged: (bindable, oldValue, newValue) => {
                ((IconTextButton)bindable).TheText.TextColor = (Color)newValue;
            });

        /// <summary>
        /// The Color of the Text.
        /// </summary>
        public Color TextColor {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }


        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text",
            typeof(string),
            typeof(IconTextButton),
            null,
            propertyChanged: (bindable, oldValue, newValue) => {
                ((IconTextButton)bindable).TheText.Text = (string)newValue;
            });

        /// <summary>
        /// The Text Displayed by the BUtton.
        /// </summary>
        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion


        public IconTextButton() {
            InitializeComponent();

            // Creates the Gesture that will be handle the Taps
            var gesture = new TapGestureRecognizer();
            gesture.Tapped += (s, e) => {
                if (IsAnimateOnClick) {
                    Task.Run(async () => {
                        AnchorX = 0.48;
                        AnchorY = 0.48;

                        await ButtonPanel.ScaleTo(0.8, 50, Easing.Linear);
                        await Task.Delay(100);
                        await ButtonPanel.ScaleTo(1, 50, Easing.Linear);
                    });
                }

                Clicked?.Invoke(this, EventArgs.Empty);
                Command?.Execute(CommandParameter);
            };
            GestureRecognizers.Add(gesture);
        }
    }
}
