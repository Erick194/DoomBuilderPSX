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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.GroupBox groupfloorceiling;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.GroupBox groupeffect;
            System.Windows.Forms.Label label8;
            this.label10 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.idxcolor = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.heightoffset = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.brightness = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.ceilingheight = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.sectorheightlabel = new System.Windows.Forms.Label();
            this.sectorheight = new System.Windows.Forms.Label();
            this.floortex = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.floorheight = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.ceilingtex = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.browseeffect = new System.Windows.Forms.Button();
            this.effect = new CodeImp.DoomBuilder.Controls.ActionSelectorControl();
            this.tagSelector = new CodeImp.DoomBuilder.Controls.TagSelector();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.apply = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flags = new CodeImp.DoomBuilder.Controls.CheckboxArrayControl();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupfloorceiling = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupeffect = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            groupfloorceiling.SuspendLayout();
            groupeffect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(271, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 16);
            label1.TabIndex = 15;
            label1.Text = "Floor";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(363, 18);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 16);
            label3.TabIndex = 14;
            label3.Text = "Ceiling";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupfloorceiling
            // 
            groupfloorceiling.BackColor = System.Drawing.Color.Transparent;
            groupfloorceiling.Controls.Add(this.label10);
            groupfloorceiling.Controls.Add(this.panel);
            groupfloorceiling.Controls.Add(this.idxcolor);
            groupfloorceiling.Controls.Add(label7);
            groupfloorceiling.Controls.Add(label5);
            groupfloorceiling.Controls.Add(label6);
            groupfloorceiling.Controls.Add(this.heightoffset);
            groupfloorceiling.Controls.Add(this.brightness);
            groupfloorceiling.Controls.Add(this.ceilingheight);
            groupfloorceiling.Controls.Add(label9);
            groupfloorceiling.Controls.Add(label2);
            groupfloorceiling.Controls.Add(this.sectorheightlabel);
            groupfloorceiling.Controls.Add(label4);
            groupfloorceiling.Controls.Add(this.sectorheight);
            groupfloorceiling.Controls.Add(this.floortex);
            groupfloorceiling.Controls.Add(this.floorheight);
            groupfloorceiling.Controls.Add(this.ceilingtex);
            groupfloorceiling.Location = new System.Drawing.Point(3, 3);
            groupfloorceiling.Name = "groupfloorceiling";
            groupfloorceiling.Size = new System.Drawing.Size(436, 214);
            groupfloorceiling.TabIndex = 0;
            groupfloorceiling.TabStop = false;
            groupfloorceiling.Text = "Floor and ceiling ";
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
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel.Location = new System.Drawing.Point(178, 188);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(20, 20);
            this.panel.TabIndex = 29;
            this.panel.Click += new System.EventHandler(this.drawfrom);
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
            // label7
            // 
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            label7.Location = new System.Drawing.Point(16, 100);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(78, 14);
            label7.TabIndex = 25;
            label7.Text = "Height offset:";
            label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tooltip.SetToolTip(label7, "Changes floor and ceiling height by given value.\r\nUse \"++\" to raise by sector hei" +
        "ght.\r\nUse \"--\" to lower by sector height.");
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(16, 70);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(78, 14);
            label5.TabIndex = 17;
            label5.Text = "Floor height:";
            label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.Location = new System.Drawing.Point(16, 40);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(78, 14);
            label6.TabIndex = 19;
            label6.Text = "Ceiling height:";
            label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            label9.Location = new System.Drawing.Point(15, 159);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(78, 14);
            label9.TabIndex = 2;
            label9.Text = "Brightness:";
            label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(196, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(114, 16);
            label2.TabIndex = 15;
            label2.Text = "Floor";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label4.Location = new System.Drawing.Point(316, 16);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(114, 16);
            label4.TabIndex = 14;
            label4.Text = "Ceiling";
            label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            groupeffect.BackColor = System.Drawing.Color.Transparent;
            groupeffect.Controls.Add(this.browseeffect);
            groupeffect.Controls.Add(this.effect);
            groupeffect.Controls.Add(label8);
            groupeffect.Controls.Add(this.tagSelector);
            groupeffect.Location = new System.Drawing.Point(4, 223);
            groupeffect.Name = "groupeffect";
            groupeffect.Size = new System.Drawing.Size(436, 92);
            groupeffect.TabIndex = 1;
            groupeffect.TabStop = false;
            groupeffect.Text = "Effect and identification";
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
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(12, 31);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(45, 13);
            label8.TabIndex = 0;
            label8.Text = "Special:";
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
            this.apply.Location = new System.Drawing.Point(225, 415);
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
            this.cancel.Location = new System.Drawing.Point(343, 415);
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
            this.panel1.Controls.Add(groupfloorceiling);
            this.panel1.Controls.Add(groupeffect);
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
            this.groupBox3.Size = new System.Drawing.Size(443, 73);
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
            this.flags.Size = new System.Drawing.Size(422, 46);
            this.flags.TabIndex = 0;
            this.flags.VerticalSpacing = 1;
            // 
            // SectorEditFormPSX
            // 
            this.AcceptButton = this.apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(466, 451);
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
            groupfloorceiling.ResumeLayout(false);
            groupfloorceiling.PerformLayout();
            groupeffect.ResumeLayout(false);
            groupeffect.PerformLayout();
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
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.CheckboxArrayControl flags;
    }
}