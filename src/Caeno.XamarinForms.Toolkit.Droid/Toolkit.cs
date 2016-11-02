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
using Caeno.XamarinForms.Toolkit.Droid.Renderers;

namespace Caeno.XamarinForms.Toolkit.Droid
{
    public static class Toolkit
    {

        public static void Initialize() {
            CircularImageRenderer.Initialize();
            RoundedFrameRenderer.Initialize();
            GridViewRenderer.Initialize();
        }

    }
}