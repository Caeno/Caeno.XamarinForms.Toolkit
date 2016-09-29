using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Caeno.XamarinForms.Toolkit
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        private static Assembly _sourceAssembly;

        public static Assembly SourceAssembly {
            get { return _sourceAssembly; }
            set { _sourceAssembly = value; }
        }

        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Source == null)
                return null;

            // Ensure that the resource is loaded from the correctly setup assembly.
            ImageSource source;
            if (SourceAssembly != null)
                source = ImageSource.FromResource(Source, SourceAssembly);
            else
                source = ImageSource.FromResource(Source);

            return source;
        }

    }
}
