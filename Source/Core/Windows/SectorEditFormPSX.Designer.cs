namespace CodeImp.DoomBuilder.Windows
{
    partial class SectorEditFormPSX
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupfloorceiling = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlSectorColor = new System.Windows.Forms.Panel();
            this.pnlSectorColorCeil = new System.Windows.Forms.Panel();
            this.idxcolor = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.idxcolorCeil = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.heightoffset = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.brightness = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.ceilingheight = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sectorheightlabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sectorheight = new System.Windows.Forms.Label();
            this.floortex = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.floorheight = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.ceilingtex = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.groupeffect = new System.Windows.Forms.GroupBox();
            this.browseeffect = new System.Windows.Forms.Button();
            this.effect = new CodeImp.DoomBuilder.Controls.ActionSelectorControl();
            this.label8 = new System.Windows.Forms.Label();
            this.tagSelector = new CodeImp.DoomBuilder.Controls.TagSelector();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.apply = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flags = new CodeImp.DoomBuilder.Controls.CheckboxArrayControl();
            this.groupfloorceiling.SuspendLayout();
            this.groupeffect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(271, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Floor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(363, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ceiling";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupfloorceiling
            // 
            this.groupfloorceiling.BackColor = System.Drawing.Color.Transparent;
            this.groupfloorceiling.Controls.Add(this.label10);
            this.groupfloorceiling.Controls.Add(this.label11);
            this.groupfloorceiling.Controls.Add(this.pnlSectorColor);
            this.groupfloorceiling.Controls.Add(this.pnlSectorColorCeil);
            this.groupfloorceiling.Controls.Add(this.idxcolor);
            this.groupfloorceiling.Controls.Add(this.idxcolorCeil);
            this.groupfloorceiling.Controls.Add(this.label7);
            this.groupfloorceiling.Controls.Add(this.label5);
            this.groupfloorceiling.Controls.Add(this.label6);
            this.groupfloorceiling.Controls.Add(this.heightoffset);
            this.groupfloorceiling.Controls.Add(this.brightness);
            this.groupfloorceiling.Controls.Add(this.ceilingheight);
            this.groupfloorceiling.Controls.Add(this.label9);
            this.groupfloorceiling.Controls.Add(this.label2);
            this.groupfloorceiling.Controls.Add(this.sectorheightlabel);
            this.groupfloorceiling.Controls.Add(this.label4);
            this.groupfloorceiling.Controls.Add(this.sectorheight);
            this.groupfloorceiling.Controls.Add(this.floortex);
            this.groupfloorceiling.Controls.Add(this.floorheight);
            this.groupfloorceiling.Controls.Add(this.ceilingtex);
            this.groupfloorceiling.Location = new System.Drawing.Point(3, 3);
            this.groupfloorceiling.Name = "groupfloorceiling";
            this.groupfloorceiling.Size = new System.Drawing.Size(436, 214);
            this.groupfloorceiling.TabIndex = 0;
            this.groupfloorceiling.TabStop = false;
            this.groupfloorceiling.Text = "Floor and ceiling ";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 27);
            this.label10.TabIndex = 30;
            this.label10.Text = "Sector color by index:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(234, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 27);
            this.label11.TabIndex = 31;
            this.label11.Text = "Ceiling sector color by index:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlSectorColor
            // 
            this.pnlSectorColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlSectorColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSectorColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSectorColor.Location = new System.Drawing.Point(178, 188);
            this.pnlSectorColor.Name = "pnlSectorColor";
            this.pnlSectorColor.Size = new System.Drawing.Size(20, 20);
            this.pnlSectorColor.TabIndex = 29;
            this.pnlSectorColor.Click += new System.EventHandler(this.drawfrom);
            // 
            // pnlSectorColorCeil
            // 
            this.pnlSectorColorCeil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlSectorColorCeil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSectorColorCeil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSectorColorCeil.Location = new System.Drawing.Point(398, 188);
            this.pnlSectorColorCeil.Name = "pnlSectorColorCeil";
            this.pnlSectorColorCeil.Size = new System.Drawing.Size(20, 20);
            this.pnlSectorColorCeil.TabIndex = 30;
            this.pnlSectorColorCeil.Click += new System.EventHandler(this.drawfromCeil);
            // 
            // idxcolor
            // 
            this.idxcolor.AllowDecimal = false;
            this.idxcolor.AllowExpressions = false;
            this.idxcolor.AllowNegative = true;
            this.idxcolor.AllowRelative = true;
            this.idxcolor.ButtonStep = 1;
            this.idxcolor.ButtonStepBig = 16F;
            this.idxcolor.ButtonStepFloat = 1F;
            this.idxcolor.ButtonStepSmall = 1F;
            this.idxcolor.ButtonStepsUseModifierKeys = true;
            this.idxcolor.ButtonStepsWrapAround = false;
            this.idxcolor.Location = new System.Drawing.Point(99, 184);
            this.idxcolor.Name = "idxcolor";
            this.idxcolor.Size = new System.Drawing.Size(73, 24);
            this.idxcolor.StepValues = null;
            this.idxcolor.TabIndex = 28;
            this.idxcolor.WhenTextChanged += new System.EventHandler(this.IdxColor_WhenTextChanged);
            // 
            // idxcolorCeil
            // 
            this.idxcolorCeil.AllowDecimal = false;
            this.idxcolorCeil.AllowExpressions = false;
            this.idxcolorCeil.AllowNegative = true;
            this.idxcolorCeil.AllowRelative = true;
            this.idxcolorCeil.ButtonStep = 1;
            this.idxcolorCeil.ButtonStepBig = 16F;
            this.idxcolorCeil.ButtonStepFloat = 1F;
            this.idxcolorCeil.ButtonStepSmall = 1F;
            this.idxcolorCeil.ButtonStepsUseModifierKeys = true;
            this.idxcolorCeil.ButtonStepsWrapAround = false;
            this.idxcolorCeil.Location = new System.Drawing.Point(319, 184);
            this.idxcolorCeil.Name = "idxcolorCeil";
            this.idxcolorCeil.Size = new System.Drawing.Size(73, 24);
            this.idxcolorCeil.StepValues = null;
            this.idxcolorCeil.TabIndex = 32;
            this.idxcolorCeil.WhenTextChanged += new System.EventHandler(this.IdxColorCeil_WhenTextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(16, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "Height offset:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tooltip.SetToolTip(this.label7, "Changes floor and ceiling height by given value.\r\nUse \"++\" to raise by sector hei" +
        "ght.\r\nUse \"--\" to lower by sector height.");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "Floor height:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ceiling height:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // heightoffset
            // 
            this.heightoffset.AllowDecimal = false;
            this.heightoffset.AllowExpressions = true;
            this.heightoffset.AllowNegative = true;
            this.heightoffset.AllowRelative = true;
            this.heightoffset.ButtonStep = 8;
            this.heightoffset.ButtonStepBig = 16F;
            this.heightoffset.ButtonStepFloat = 1F;
            this.heightoffset.ButtonStepSmall = 1F;
            this.heightoffset.ButtonStepsUseModifierKeys = true;
            this.heightoffset.ButtonStepsWrapAround = false;
            this.heightoffset.Location = new System.Drawing.Point(99, 95);
            this.heightoffset.Name = "heightoffset";
            this.heightoffset.Size = new System.Drawing.Size(88, 24);
            this.heightoffset.StepValues = null;
            this.heightoffset.TabIndex = 26;
            this.heightoffset.WhenTextChanged += new System.EventHandler(this.heightoffset_WhenTextChanged);
            // 
            // brightness
            // 
            this.brightness.AllowDecimal = false;
            this.brightness.AllowExpressions = false;
            this.brightness.AllowNegative = true;
            this.brightness.AllowRelative = true;
            this.brightness.ButtonStep = 8;
            this.brightness.ButtonStepBig = 16F;
            this.brightness.ButtonStepFloat = 1F;
            this.brightness.ButtonStepSmall = 1F;
            this.brightness.ButtonStepsUseModifierKeys = true;
            this.brightness.ButtonStepsWrapAround = false;
            this.brightness.Location = new System.Drawing.Point(99, 154);
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(73, 24);
            this.brightness.StepValues = null;
            this.brightness.TabIndex = 24;
            this.brightness.WhenTextChanged += new System.EventHandler(this.brightness_WhenTextChanged);
            // 
            // ceilingheight
            // 
            this.ceilingheight.AllowDecimal = false;
            this.ceilingheight.AllowExpressions = true;
            this.ceilingheight.AllowNegative = true;
            this.ceilingheight.AllowRelative = true;
            this.ceilingheight.ButtonStep = 8;
            this.ceilingheight.ButtonStepBig = 16F;
            this.ceilingheight.ButtonStepFloat = 1F;
            this.ceilingheight.ButtonStepSmall = 1F;
            this.ceilingheight.ButtonStepsUseModifierKeys = true;
            this.ceilingheight.ButtonStepsWrapAround = false;
            this.ceilingheight.Location = new System.Drawing.Point(99, 35);
            this.ceilingheight.Name = "ceilingheight";
            this.ceilingheight.Size = new System.Drawing.Size(88, 24);
            this.ceilingheight.StepValues = null;
            this.ceilingheight.TabIndex = 22;
            this.ceilingheight.WhenTextChanged += new System.EventHandler(this.ceilingheight_TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(15, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "Brightness:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(196, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Floor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sectorheightlabel
            // 
            this.sectorheightlabel.Location = new System.Drawing.Point(16, 130);
            this.sectorheightlabel.Name = "sectorheightlabel";
            this.sectorheightlabel.Size = new System.Drawing.Size(78, 14);
            this.sectorheightlabel.TabIndex = 20;
            this.sectorheightlabel.Text = "Sector height:";
            this.sectorheightlabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(316, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ceiling";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sectorheight
            // 
            this.sectorheight.AutoSize = true;
            this.sectorheight.Location = new System.Drawing.Point(100, 130);
            this.sectorheight.Name = "sectorheight";
            this.sectorheight.Size = new System.Drawing.Size(13, 13);
            this.sectorheight.TabIndex = 21;
            this.sectorheight.Text = "0";
            // 
            // floortex
            // 
            this.floortex.Location = new System.Drawing.Point(196, 35);
            this.floortex.MultipleTextures = false;
            this.floortex.Name = "floortex";
            this.floortex.Size = new System.Drawing.Size(114, 138);
            this.floortex.TabIndex = 2;
            this.floortex.TextureName = "";
            this.floortex.OnValueChanged += new System.EventHandler(this.floortex_OnValueChanged);
            // 
            // floorheight
            // 
            this.floorheight.AllowDecimal = false;
            this.floorheight.AllowExpressions = true;
            this.floorheight.AllowNegative = true;
            this.floorheight.AllowRelative = true;
            this.floorheight.ButtonStep = 8;
            this.floorheight.ButtonStepBig = 16F;
            this.floorheight.ButtonStepFloat = 1F;
            this.floorheight.ButtonStepSmall = 1F;
            this.floorheight.ButtonStepsUseModifierKeys = true;
            this.floorheight.ButtonStepsWrapAround = false;
            this.floorheight.Location = new System.Drawing.Point(99, 65);
            this.floorheight.Name = "floorheight";
            this.floorheight.Size = new System.Drawing.Size(88, 24);
            this.floorheight.StepValues = null;
            this.floorheight.TabIndex = 23;
            this.floorheight.WhenTextChanged += new System.EventHandler(this.floorheight_TextChanged);
            // 
            // ceilingtex
            // 
            this.ceilingtex.Location = new System.Drawing.Point(316, 35);
            this.ceilingtex.MultipleTextures = false;
            this.ceilingtex.Name = "ceilingtex";
            this.ceilingtex.Size = new System.Drawing.Size(114, 138);
            this.ceilingtex.TabIndex = 3;
            this.ceilingtex.TextureName = "";
            this.ceilingtex.OnValueChanged += new System.EventHandler(this.ceilingtex_OnValueChanged);
            // 
            // groupeffect
            // 
            this.groupeffect.BackColor = System.Drawing.Color.Transparent;
            this.groupeffect.Controls.Add(this.browseeffect);
            this.groupeffect.Controls.Add(this.effect);
            this.groupeffect.Controls.Add(this.label8);
            this.groupeffect.Controls.Add(this.tagSelector);
            this.groupeffect.Location = new System.Drawing.Point(4, 223);
            this.groupeffect.Name = "groupeffect";
            this.groupeffect.Size = new System.Drawing.Size(436, 92);
            this.groupeffect.TabIndex = 1;
            this.groupeffect.TabStop = false;
            this.groupeffect.Text = "Effect and identification";
            // 
            // browseeffect
            // 
            this.browseeffect.Image = global::CodeImp.DoomBuilder.Properties.Resources.List;
            this.browseeffect.Location = new System.Drawing.Point(402, 26);
            this.browseeffect.Name = "browseeffect";
            this.browseeffect.Size = new System.Drawing.Size(28, 25);
            this.browseeffect.TabIndex = 1;
            this.browseeffect.Text = " ";
            this.browseeffect.UseVisualStyleBackColor = true;
            this.browseeffect.Click += new System.EventHandler(this.browseeffect_Click);
            // 
            // effect
            // 
            this.effect.BackColor = System.Drawing.Color.Transparent;
            this.effect.Cursor = System.Windows.Forms.Cursors.Default;
            this.effect.Empty = false;
            this.effect.GeneralizedCategories = null;
            this.effect.GeneralizedOptions = null;
            this.effect.Location = new System.Drawing.Point(61, 28);
            this.effect.Name = "effect";
            this.effect.Size = new System.Drawing.Size(335, 21);
            this.effect.TabIndex = 0;
            this.effect.Value = 402;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Special:";
            // 
            // tagSelector
            // 
            this.tagSelector.Location = new System.Drawing.Point(19, 52);
            this.tagSelector.Name = "tagSelector";
            this.tagSelector.Size = new System.Drawing.Size(414, 34);
            this.tagSelector.TabIndex = 0;
            // 
            // tooltip
            // 
            this.tooltip.AutomaticDelay = 10;
            this.tooltip.AutoPopDelay = 10000;
            this.tooltip.InitialDelay = 10;
            this.tooltip.ReshowDelay = 100;
            // 
            // apply
            // 
            this.apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apply.Location = new System.Drawing.Point(225, 445);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(112, 25);
            this.apply.TabIndex = 1;
            this.apply.Text = "OK";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(343, 445);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(112, 25);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.groupfloorceiling);
            this.panel1.Controls.Add(this.groupeffect);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 320);
            this.panel1.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flags);
            this.groupBox3.Location = new System.Drawing.Point(12, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(443, 103);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Flags ";
            // 
            // flags
            // 
            this.flags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flags.AutoScroll = true;
            this.flags.Columns = 2;
            this.flags.Location = new System.Drawing.Point(15, 21);
            this.flags.Name = "flags";
            this.flags.Size = new System.Drawing.Size(422, 76);
            this.flags.TabIndex = 0;
            this.flags.VerticalSpacing = 1;
            // 
            // SectorEditFormPSX
            // 
            this.AcceptButton = this.apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(466, 481);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SectorEditFormPSX";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Sector";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.SectorEditFormPSX_HelpRequested);
            this.groupfloorceiling.ResumeLayout(false);
            this.groupfloorceiling.PerformLayout();
            this.groupeffect.ResumeLayout(false);
            this.groupeffect.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button apply;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl floortex;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl ceilingtex;
        private System.Windows.Forms.Label sectorheight;
        private CodeImp.DoomBuilder.Controls.ActionSelectorControl effect;
        private System.Windows.Forms.Button browseeffect;
        private System.Windows.Forms.Label sectorheightlabel;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox ceilingheight;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox floorheight;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox brightness;
        private CodeImp.DoomBuilder.Controls.TagSelector tagSelector;
        private System.Windows.Forms.Panel panel1;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox heightoffset;
        private System.Windows.Forms.ToolTip tooltip;
        private Controls.ButtonsNumericTextbox idxcolor;
        private System.Windows.Forms.Panel pnlSectorColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.CheckboxArrayControl flags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupfloorceiling;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupeffect;
        private System.Windows.Forms.Label label8;
        private Controls.ButtonsNumericTextbox idxcolorCeil;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlSectorColorCeil;
    }
}