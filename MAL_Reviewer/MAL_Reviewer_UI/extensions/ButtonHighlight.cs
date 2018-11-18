using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MAL_Reviewer_UI.extensions
{
    /// <summary>
    /// Highlight a button.
    /// </summary>
    public static class ButtonHighlight
    {
        /// <summary>
        /// Highlights the active button.
        /// </summary>
        public static void Highlight(this Button button, Color highlightColor, Color normalColor, List<Button> peers)
        {
            // Highlighting the button.
            button.BackColor = highlightColor;

            // Unhighlighting the other buttons.
            peers.ForEach(btn => btn.BackColor = normalColor);
        }
    }
}
