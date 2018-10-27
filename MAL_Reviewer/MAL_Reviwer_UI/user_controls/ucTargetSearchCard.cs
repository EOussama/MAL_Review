﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MAL_Reviwer_UI.user_controls
{
    public partial class ucTargetSearchCard : UserControl
    {
        public event EventHandler<int> CardMouseClickEvent;
        private int _targetId;

        public ucTargetSearchCard()
        {
            InitializeComponent();

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

        public void UpdateUI (int targetId, string targetTitle, string targetType, string targetImageUrl)
        {
            this.targetId = targetId;
            lTargetTitle.Text = targetTitle.Length > 17 ? targetTitle.Substring(0, 17) + "..." : targetTitle;
            lTargetType.Text = targetType;
            pbTargetImage.Load(targetImageUrl);
        }

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
