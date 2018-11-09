using System.Windows.Forms;
using System.Collections.Generic;

namespace MAL_Reviewer_UI.classes
{
    /// <summary>
    /// Everything that has to do with controling loading animation.
    /// Works best with panel controls.
    /// </summary>
    public static class Loader
    {
        /// <summary>
        /// Toggles a control's loading animation.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="state"></param>
        /// <param name="loaderControl"></param>
        /// <param name="exceptions"></param>
        public static void ToggleLoad(this Control control, bool state, user_controls.LoaderControl loaderControl)
        {
            // Ensuring the targeted control is visible.
            control.Visible = true;

            // Toggling the visibility of all sub controls of the targeted control.
            foreach (Control subControl in control.Controls)
            {
                subControl.Visible = !state;
            }

            // Adding or removing the loader user control to the targeted control.
            if (state)
            {
                control.Controls.Add(loaderControl);

                // Centering the loader user control.
                loaderControl.Top = control.Height / 2 - loaderControl.Height / 2;
                loaderControl.Left = control.Width / 2 - loaderControl.Width / 2;
            }
            else
            {
                control.Controls.Remove(loaderControl);
            }

            
            // Toggling the loader user control's visibility.
            loaderControl.Visible = state;
        }
    }
}
