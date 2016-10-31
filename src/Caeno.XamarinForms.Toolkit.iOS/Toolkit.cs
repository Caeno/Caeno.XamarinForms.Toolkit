using Caeno.XamarinForms.Toolkit.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Caeno.XamarinForms.Toolkit.iOS
{
    public static class Toolkit
    {

        public static void Initialize() {
            BasePageRenderer.Initialize();
            CircularImageRenderer.Initialize();
            EnhancedFrameRenderer.Initialize();
            EnhancedTabbedRenderer.Initialize();
            EnhancedViewCellRenderer.Initialize();
            GridViewRenderer.Initialize();
        }

    }
}