using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Caeno.XamarinForms.Toolkit.Android.Renderers;

namespace Caeno.XamarinForms.Toolkit.Android
{
    public static class Toolkit
    {

        public static void Initialize() {
            CircularImageRenderer.Initialize();
            EnhancedFrameRenderer.Initialize();
        }

    }
}