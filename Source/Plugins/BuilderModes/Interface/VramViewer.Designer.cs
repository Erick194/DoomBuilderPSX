using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using CodeImp.DoomBuilder.Map;

namespace CodeImp.DoomBuilder.BuilderModes
{
    partial class VramViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VramViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 512);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1040, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1040, 550);
            this.Name = "VramViewerForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Vram Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VramViewerForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.ResumeLayout(false);

        }

        protected void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color rgb;
            Brush bgbrush;

            Bitmap image = General.Map.Data.GetTextureBitmap("STATUS");

            if (image != null)
            {
                g.PageUnit = GraphicsUnit.Pixel;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.None;
                g.DrawImage(image, 512, 0, image.Width / 2, image.Height);
            }

            if (mode.VramT.Count != 0)
            {
                for (int i = 0; i < mode.VramT.Count; i++)
                {
                    image = General.Map.Data.GetTextureBitmap(mode.VramT[i].TextureName);

                    if (image != null)
                    {
                        g.PageUnit = GraphicsUnit.Pixel;
                        g.InterpolationMode = InterpolationMode.NearestNeighbor;
                        g.PixelOffsetMode = PixelOffsetMode.None;
                        g.DrawImage(image, mode.VramT[i].X, mode.VramT[i].Y, image.Width / 2, image.Height);
                    }
                }
            }

            //MAIN SCREEN
            rgb = Color.FromArgb(48, 0x73, 0xDE, 0x6B);
            bgbrush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), rgb, rgb);
            g.FillRectangle(bgbrush, 0, 0, 256, 240);

            //SECOND SCREEN
            rgb = Color.FromArgb(48, 0xDE, 0xDF, 0x6D);
            bgbrush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), rgb, rgb);
            g.FillRectangle(bgbrush, 256, 0, 256, 240);

            //PALETTES
            rgb = Color.FromArgb(48, 0x00, 0x80, 0x00);
            bgbrush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), rgb, rgb);
            g.FillRectangle(bgbrush, 0, 240, 512, 16);

            //STATUS
            rgb = Color.FromArgb(48, 0x40, 0x40, 0xFF);
            bgbrush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), rgb, rgb);
            g.FillRectangle(bgbrush, 512, 0, 128, 256);

            //FLATS
            rgb = Color.FromArgb(48, 0xFF, 0x43, 0x43);
            bgbrush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), rgb, rgb);
            g.FillRectangle(bgbrush, 640, 0, 128, 256);

            //TESTURES
            rgb = Color.FromArgb(48, 0x93, 0x43, 0xFF);
            bgbrush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), rgb, rgb);
            g.FillRectangle(bgbrush, 768, 0, 256, 256);
            g.FillRectangle(bgbrush, 0, 256, 128, 256);

            //SPRITES
            rgb = Color.FromArgb(48, 0x00, 0x40, 0x40);
            bgbrush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), rgb, rgb);
            g.FillRectangle(bgbrush, 128, 256, 896, 256);

            //g.Dispose();
        }

        #endregion
    }
}