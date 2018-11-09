using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAL_Reviewer_UI.user_controls
{
    public partial class TargetSearchCardControl : UserControl
    {
        public event EventHandler<int> CardMouseClickEvent;
        private int _targetId;

        public TargetSearchCardControl()
        {
            InitializeComponent();

            // Wiring up the click event.
            this.MouseClick += UcTargetSearchCard_MouseClick; ;
            this.pbTargetImage.MouseClick += UcTargetSearchCard_MouseClick;
            this.lTargetTitle.MouseClick += UcTargetSearchCard_MouseClick;
            this.lTargetType.MouseClick += UcTargetSearchCard_MouseClick;

            // Wiring up the hover event.
            this.MouseEnter += CardMouseEnter;
            this.pbTargetImage.MouseEnter += CardMouseEnter;
            this.lTargetTitle.MouseEnter += CardMouseEnter;
            this.lTargetType.MouseEnter += CardMouseEnter;

            this.MouseLeave += CardMouseLeave;
            this.pbTargetImage.MouseLeave += CardMouseLeave;
            this.lTargetTitle.MouseLeave += CardMouseLeave;
            this.lTargetType.MouseLeave += CardMouseLeave;
        }

        public int TargetId { get => _targetId; set => _targetId = value; }

        public void UpdateUI (int targetId, string targetTitle, string targetType, string targetImageUrl, string searchType)
        {
            StringBuilder sb = new StringBuilder();

            this.TargetId = targetId;
            lTargetTitle.Text = targetTitle.Length > 17 ? sb.Append(targetTitle.Substring(0, 17) + "...").ToString() : sb.Append(targetTitle).ToString(); sb.Clear();
            lTargetType.Text = sb.Append(targetType).ToString(); sb.Clear();
            pbTargetImage.Load(targetImageUrl);

            ttTitle.ToolTipTitle = sb.Append($"{ searchType } information").ToString(); sb.Clear();
            ttTitle.SetToolTip(this, targetTitle);
            ttTitle.SetToolTip(this.lTargetTitle, targetTitle);
            ttTitle.SetToolTip(this.lTargetType, targetTitle);
            ttTitle.SetToolTip(this.pbTargetImage, targetTitle);
        }

        private void UcTargetSearchCard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CardMouseClickEvent?.Invoke(sender, TargetId);
        }

        private void CardMouseEnter(object sender, EventArgs e) => this.BackColor = SystemColors.Control;

        private void CardMouseLeave(object sender, EventArgs e) => this.BackColor = SystemColors.ControlLight;
    }
}
