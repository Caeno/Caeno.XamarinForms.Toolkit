using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
	public class ImageButton : Image
	{


        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command",
            typeof(ICommand),
            typeof(ImageButton),
            null);

        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter",
            typeof(object),
            typeof(ImageButton),
            null);

        public object CommandParameter {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        public event EventHandler Clicked;


        ICommand TransitionCommand { get; set; }


        void CreateTransitionCommand() {
            TransitionCommand = new Command(async () => {
                Clicked?.Invoke(this, EventArgs.Empty);
                Command?.Execute(CommandParameter);

                AnchorX = 0.48;
                AnchorY = 0.48;

                await this.ScaleTo(0.8, 50, Easing.Linear);
                await Task.Delay(100);
                await this.ScaleTo(1, 50, Easing.Linear);
            });
        }


        public ImageButton() {
            CreateTransitionCommand();
            GestureRecognizers.Add(new TapGestureRecognizer {
                Command = TransitionCommand
            });
        }

    }
}
