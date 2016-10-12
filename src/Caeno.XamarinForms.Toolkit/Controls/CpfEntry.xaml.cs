using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Caeno.XamarinForms.Toolkit
{

    /// <summary>
    /// A special Entry for Brazilian CPF Numbers with Validation.
    /// </summary>
    public partial class CpfEntry : StackLayout
    {

        bool _isTypedValue = false;

        public static readonly BindableProperty CpfProperty =
            BindableProperty.Create("Cpf",
                typeof(string),
                typeof(CpfEntry),
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((CpfEntry)bindable).LoadCpf((string)newValue);
                });

        public string Cpf {
            get { return (string)GetValue(CpfProperty); }
            set { SetValue(CpfProperty, value); }
        }


        public static readonly BindablePropertyKey IsValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(CpfEntry), false);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }


        void LoadCpf(string cpf) {
            // First try to validate if the typed CPF is valid
            IsValid = cpf.IsValidCPF();

            // Check if the CPF was passed via typing, so ignore loading the segments
            if (_isTypedValue) {
                _isTypedValue = false;
                return;
            }

            // Load each part of the CPF into it's own segment
            var currentSegmentText = "";
            int currentSegment = 1;

            for (int i = 0; i < cpf.Length && i <= 11; i++) {
                currentSegmentText += cpf[i];

                if ((currentSegment <= 3 && currentSegmentText.Length == 3) ||
                    (currentSegment == 4 && currentSegmentText.Length == 2)) {
                    switch (currentSegment) {
                        case 1:
                            CpfSegment1Entry.Text = currentSegmentText;
                            break;
                        case 2:
                            CpfSegment2Entry.Text = currentSegmentText;
                            break;
                        case 3:
                            CpfSegment3Entry.Text = currentSegmentText;
                            break;
                        case 4:
                            CpfSegment4Entry.Text = currentSegmentText;
                            break;
                    }
                    currentSegment++;
                    currentSegmentText = string.Empty;
                }
            }
        }

        void TextChanged(object sender, TextChangedEventArgs e) {
            _isTypedValue = true;
            Cpf = $"{CpfSegment1Entry.Text}{CpfSegment2Entry.Text}{CpfSegment3Entry.Text}{CpfSegment4Entry.Text}";
        }

        public CpfEntry() {
            InitializeComponent();
        }
    }
}
