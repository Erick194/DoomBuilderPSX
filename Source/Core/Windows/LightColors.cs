using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Rendering;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeImp.DoomBuilder.Windows
{
    public partial class LightColors : DelayedForm
    {
        public LightColors()
        {
            InitializeComponent();
        }

        public int IindexCol;// { get { return IindexCol; } set { IindexCol = value; } }
        public int IdxCol { get { return IindexCol; } set { IindexCol = value; } }//[GEC]

        private void LightColors_Load(object sender, EventArgs e)
        {
            PixelColor rgb = Lights.GetColor(0); // [GEC]

            int index = 0;
            for (index = 0; index < 256; index++)//set color on boxes
            {
                foreach (Control control in Controls)
                {
                    if (control.TabIndex == index)
                    {
                        rgb = Lights.GetColor(index); // [GEC]
                        control.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);
                        control.Click += new System.EventHandler(this.Box_Click);
                        control.Cursor = System.Windows.Forms.Cursors.Hand;
                        break;
                    }
                }
            }

            //update color
            foreach (Control control in Controls)
            {
                if (control.TabIndex == IindexCol)
                {
                    ColorIndex.Text = IdxCol.ToString();
                    rgb = Lights.GetColor(IindexCol); // [GEC]
                    panel257.Location = new System.Drawing.Point(control.Location.X + 2, control.Location.Y + 2);
                    panel257.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);
                    break;
                }
            }
        }

        private void Box_Click(object sender, EventArgs e)
        {
            panel256.BackColor = Color.FromArgb(255, 255, 0);
            Control control = (Control)sender;

            PixelColor rgb = Lights.GetColor(control.TabIndex); // [GEC]
            panel256.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);

            //update color
            IindexCol = control.TabIndex;
            ColorIndex.Text = IdxCol.ToString();
            panel257.Location = new System.Drawing.Point(control.Location.X + 2, control.Location.Y + 2);
            panel257.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);
        }

        private void apply_Click(object sender, EventArgs e)
        {
            // Done
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            // And be gone
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
