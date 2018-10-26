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
        private int _targetId;

        public ucTargetSearchCard(int targetId, string targetTitle, string targetType, string targetImage)
        {
            InitializeComponent();

            this.targetId = targetId;
            lTargetTitle.Text = targetTitle;
            lTargetType.Text = targetType;
            pbTargetImage.Load(targetImage);

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
