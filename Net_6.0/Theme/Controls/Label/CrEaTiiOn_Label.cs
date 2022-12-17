﻿#region Imports

using System.ComponentModel;

#endregion

namespace CBH.Controls
{
    #region CrEaTiiOn_Label

    public class CrEaTiiOn_Label : System.Windows.Forms.Label
    {
        #region Field Region

        private bool _autoUpdateHeight;
        private bool _isGrowing;

        #endregion

        #region Property Region

        [Category("Layout")]
        [Description("Enables automatic height sizing based on the contents of the label.")]
        [DefaultValue(false)]
        public bool AutoUpdateHeight
        {
            get => _autoUpdateHeight;
            set
            {
                _autoUpdateHeight = value;

                if (_autoUpdateHeight)
                {
                    AutoSize = false;
                    ResizeLabel();
                }
            }
        }

        public new bool AutoSize
        {
            get => base.AutoSize;
            set
            {
                base.AutoSize = value;

                if (AutoSize)
                {
                    AutoUpdateHeight = false;
                }
            }
        }

        #endregion

        #region Constructor Region

        public CrEaTiiOn_Label()
        {
            ForeColor = Color.White;
        }

        #endregion

        #region Method Region

        private void ResizeLabel()
        {
            if (!_autoUpdateHeight || _isGrowing)
            {
                return;
            }

            try
            {
                _isGrowing = true;
                Size sz = new(Width, int.MaxValue);
                sz = TextRenderer.MeasureText(Text, Font, sz, TextFormatFlags.WordBreak);
                Height = sz.Height + Padding.Vertical;
            }
            finally
            {
                _isGrowing = false;
            }
        }

        #endregion

        #region Event Handler Region

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ResizeLabel();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ResizeLabel();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeLabel();
        }

        #endregion
    }

    #endregion
}