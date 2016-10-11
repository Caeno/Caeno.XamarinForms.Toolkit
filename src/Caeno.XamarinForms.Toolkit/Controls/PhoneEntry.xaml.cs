using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit.Controls
{

    public partial class PhoneEntry : StackLayout
    {

        bool _isTypedValue = false;

        public static readonly BindableProperty PhoneProperty =
            BindableProperty.Create("Phone",
                typeof(string),
                typeof(PhoneEntry),
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((PhoneEntry)bindable).LoadPhone((string)newValue);
                });

        public string Phone {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }


        public static readonly BindablePropertyKey IsValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(CpfEntry), true);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }


        void LoadPhone(string phone) {
            // Apply validation
            IsValid = string.IsNullOrWhiteSpace(phone) || (phone.Length >= 10 && phone.Length <= 11);

            // Check if the value was typed or passed directly via bind
            if (_isTypedValue) {
                _isTypedValue = false;
                return;
            }

            // Split number into each segment
            if (phone.Length == 2) {
                PhonePrefix.Text = phone;
            } else if (phone.Length > 2) {
                PhonePrefix.Text = phone.Substring(0, 2);
                PhoneNumber.Text = phone.Substring(2, phone.Length - 2);
            }
        }


        void TextChanged(object sender, TextChangedEventArgs e) {
            _isTypedValue = true;
            Phone = $"{PhonePrefix.Text}{PhoneNumber.Text}";
        }

        public PhoneEntry() {
            InitializeComponent();
        }

    }

}
