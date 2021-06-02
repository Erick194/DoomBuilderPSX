
#region ================== Namespaces

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CodeImp.DoomBuilder.Windows;
using System.Reflection;
using System.Globalization;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;

#endregion

namespace CodeImp.DoomBuilder.BuilderModes
{
    public partial class VramViewerForm : DelayedForm
    {
        private VramViewerMode mode; //mxd
        private Font hintfont; //mxd

        public VramViewerForm()
        {
            InitializeComponent();

            //mxd. Create hint font
            hintfont = new Font(this.Font, FontStyle.Underline);

            //resultslist = new List<ErrorResult>();
        }

        #region ================== Methods

        // Window closing
        private void VramViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the user closes the form, then just cancel the mode
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                General.Interface.Focus();
                General.Editing.CancelMode();
            }

            //mxd
            hintfont.Dispose();
        }

        // Close button clicked
        private void closebutton_Click(object sender, EventArgs e)
        {
            General.Interface.Focus();
            General.Editing.CancelMode();
        }

        // This shows the window
        public void Show(Form owner, VramViewerMode mode)
        {
            //mxd
            this.mode = mode;

            // Show window
            base.Show(owner);
        }

        // This hides the window
        new public void Hide()
        {
            base.Hide();
        }
        #endregion
    }
}
