using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{

    /// <summary>
    /// A special Entry for Brazilian CNPJ Numbers with Validation.
    /// </summary>
    public partial class CnpjEntry : StackLayout
    {

        bool _isTypedValue = false;        

        public static readonly BindableProperty CnpjProperty =
            BindableProperty.Create("Cnpj",
                typeof(string),
                typeof(CnpjEntry),
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((CnpjEntry)bindable).LoadCnpj((string)newValue);
                });

        public string Cnpj {
            get { return (string)GetValue(CnpjProperty); }
            set { SetValue(CnpjProperty, value); }
        }

        public static readonly BindablePropertyKey IsValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(CnpjEntry), true);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }

        void LoadCnpj(string cnpj) {
            // First try to validate the input
            IsValid = string.IsNullOrWhiteSpace(cnpj) || cnpj.IsValidCnpj();

            // Check if the value was passed via typing, so ignore loading
            if (_isTypedValue) {
                _isTypedValue = false;
                return;
            }


        }

        public CnpjEntry() {
            InitializeComponent();
        }

        void TextChanged(object sender, TextChangedEventArgs e) {
            _isTypedValue = true;
            Cnpj = $"{CnpjSegment1Entry.Text}{CnpjSegment2Entry.Text}{CnpjSegment3Entry.Text}{CnpjSegment4Entry.Text}{CnpjSegment5Entry}";
        }

    }
}
