using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{
    public partial class CepEntry : StackLayout
    {

        bool _isTypedValue = false;

        public static readonly BindableProperty CepProperty =
            BindableProperty.Create("Cep",
                typeof(string),
                typeof(CepEntry),
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((CepEntry)bindable).LoadCep((string)newValue);
                });

        public string Cep {
            get { return (string)GetValue(CepProperty); }
            set { SetValue(CepProperty, value); }
        }


        public static readonly BindablePropertyKey IsValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(CpfEntry), true);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }


        void LoadCep(string cep) {
            // Apply validation
            IsValid = string.IsNullOrWhiteSpace(cep) || (cep.Length == 8);

            // Check if the value was typed or passed directly via bind
            if (_isTypedValue) {
                _isTypedValue = false;
                return;
            }

            // Split number into each segment
            if (cep.Length == 5) {
                CepSegment1Entry.Text = cep;
            } else if (cep.Length > 5) {
                CepSegment1Entry.Text = cep.Substring(0, 5);
                CepSegment2Entry.Text = cep.Substring(5, cep.Length - 3);
            }
        }

        void TextChanged(object sender, TextChangedEventArgs e) {
            _isTypedValue = true;
            Cep = $"{CepSegment1Entry.Text}{CepSegment2Entry.Text}";
        }


        public CepEntry() {
            InitializeComponent();
        }

    }
}
