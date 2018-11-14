using System.Windows.Forms;
using System.Drawing;

namespace MAL_Reviewer_UI.classes
{
    /// <summary>
    /// Highlight a button.
    /// </summary>
    public static class ButtonHighlight
    {
        /// <summary>
        /// Highlights the active button.
        /// </summary>
        public static void Highlight(this Button button, Color highlightColor, Color normalColor, Button[] peers)
        {
            button.BackColor = highlightColor;

            foreach (Button btn in peers)
            {
                btn.BackColor = normalColor;
            }
        }
    }
}
