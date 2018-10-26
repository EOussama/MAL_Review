using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAL_Reviwer_UI.user_controls
{
    public partial class ucTargetSearchCard : UserControl
    {
        public event EventHandler<int> CardMouseClickEvent;
        private int _targetId;

        public ucTargetSearchCard(int targetId, string targetTitle, string targetType, string targetImage)
        {
            InitializeComponent();

            this.targetId = targetId;
            lTargetTitle.Text = targetTitle;
            lTargetType.Text = targetType;
            pbTargetImage.Load(targetImage);

            this.Click += CardMouseClickEventHandler;
            this.pbTargetImage.Click += CardMouseClickEventHandler;
            this.lTargetTitle.Click += CardMouseClickEventHandler;
            this.lTargetType.Click += CardMouseClickEventHandler;

            this.MouseEnter += CardMouseEnter;
            this.pbTargetImage.MouseEnter += CardMouseEnter;
            this.lTargetTitle.MouseEnter += CardMouseEnter;
            this.lTargetType.MouseEnter += CardMouseEnter;

            this.MouseLeave += CardMouseLeave;
            this.pbTargetImage.MouseLeave += CardMouseLeave;
            this.lTargetTitle.MouseLeave += CardMouseLeave;
            this.lTargetType.MouseLeave += CardMouseLeave;
        }

        public int targetId { get => _targetId; set => _targetId = value; }

        private void CardMouseClickEventHandler(object sender, EventArgs e)
        {
            CardMouseClickEvent?.Invoke(sender, targetId);
        }

        private void CardMouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        private void CardMouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ControlLight;
        }
    }
}
