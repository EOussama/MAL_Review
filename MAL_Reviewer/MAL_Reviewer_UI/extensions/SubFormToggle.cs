using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MAL_Reviewer_UI.extensions
{
    /// <summary>
    /// Everything about toggeling sub forms.
    /// </summary>
    public static class SubFormToggle
    {
        /// <summary>
        /// Toggles a sub form ON/OFF
        /// </summary>
        /// <param name="formToToggle"></param>
        /// <param name="sender"></param>
        /// <param name="panels"></param>
        public static void ToggleSubForm(this Form formToToggle, Button sender, params Control[] panels)
        {
            if (!formToToggle.Visible)
            {
                // Showing the sub form.
                formToToggle.Show();

                // Hiding all other sub forms.
                formToToggle.HideAllExcept(panels[0].Controls.OfType<Form>().ToList());

                // Highlighting the sender button.
                sender.Highlight(Color.White, Color.Transparent, panels[1].Controls.OfType<Button>().Where(btn => btn != sender).ToList());
            }
        }

        /// <summary>
        /// Hides all of the sub forms except for the passed one.
        /// </summary>
        /// <param name="exceptionForm"></param>
        public static void HideAllExcept(this Form exceptionForm, List<Form> forms)
        {
            forms.ForEach(form => 
            {
                if (form != exceptionForm)
                {
                    form.Hide();
                }
            });
        }
    }
}
