namespace CodeImp.DoomBuilder.Windows
{
	partial class AboutForm
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
			if(disposing && (components != null))
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.PictureBox pictureBox1;
            System.Windows.Forms.PictureBox pictureBox3;
            System.Windows.Forms.PictureBox pictureBox5;
            this.close = new System.Windows.Forms.Button();
            this.builderlink = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.codeimplink = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gitPsyDoomlink = new System.Windows.Forms.LinkLabel();
            this.MasterEditionlink = new System.Windows.Forms.LinkLabel();
            this.gitBuilderPSXlink = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.gitlink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.zdoomorglink = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            label1.Location = new System.Drawing.Point(11, 98);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(349, 50);
            label1.TabIndex = 2;
            label1.Text = "Doom Builder is designed and programmed by Pascal vd Heiden.\r\nSeveral game config" +
    "urations were written by various members of the Doom community. See the website " +
    "for a complete list of credits.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = global::CodeImp.DoomBuilder.Properties.Resources.Splash3_small;
            pictureBox1.Location = new System.Drawing.Point(6, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(226, 80);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = global::CodeImp.DoomBuilder.Properties.Resources.GZDB_Logo_small;
            pictureBox3.Location = new System.Drawing.Point(6, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(226, 80);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = global::CodeImp.DoomBuilder.Properties.Resources.PSXDB_Logo_small;
            pictureBox5.Location = new System.Drawing.Point(3, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(226, 80);
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox5.TabIndex = 11;
            pictureBox5.TabStop = false;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(285, 245);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(116, 25);
            this.close.TabIndex = 5;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            // 
            // builderlink
            // 
            this.builderlink.ActiveLinkColor = System.Drawing.Color.Firebrick;
            this.builderlink.AutoSize = true;
            this.builderlink.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.builderlink.Location = new System.Drawing.Point(8, 156);
            this.builderlink.Name = "builderlink";
            this.builderlink.Size = new System.Drawing.Size(114, 13);
            this.builderlink.TabIndex = 3;
            this.builderlink.TabStop = true;
            this.builderlink.Text = "www.doombuilder.com";
            this.builderlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.builderlink_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CodeImp.DoomBuilder.Properties.Resources.CLogo;
            this.pictureBox2.Location = new System.Drawing.Point(289, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(88, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // codeimplink
            // 
            this.codeimplink.ActiveLinkColor = System.Drawing.Color.Firebrick;
            this.codeimplink.AutoSize = true;
            this.codeimplink.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.codeimplink.Location = new System.Drawing.Point(8, 176);
            this.codeimplink.Name = "codeimplink";
            this.codeimplink.Size = new System.Drawing.Size(97, 13);
            this.codeimplink.TabIndex = 4;
            this.codeimplink.TabStop = true;
            this.codeimplink.Text = "www.codeimp.com";
            this.codeimplink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.codeimplink_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(24, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(391, 227);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gitPsyDoomlink);
            this.tabPage3.Controls.Add(this.MasterEditionlink);
            this.tabPage3.Controls.Add(this.gitBuilderPSXlink);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.version);
            this.tabPage3.Controls.Add(pictureBox5);
            this.tabPage3.Controls.Add(this.pictureBox6);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(383, 201);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About Doom Builder PSX";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gitPsyDoomlink
            // 
            this.gitPsyDoomlink.AutoSize = true;
            this.gitPsyDoomlink.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.gitPsyDoomlink.Location = new System.Drawing.Point(283, 180);
            this.gitPsyDoomlink.Name = "gitPsyDoomlink";
            this.gitPsyDoomlink.Size = new System.Drawing.Size(88, 13);
            this.gitPsyDoomlink.TabIndex = 22;
            this.gitPsyDoomlink.TabStop = true;
            this.gitPsyDoomlink.Text = "PsyDoom Project";
            this.gitPsyDoomlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitPsyDoomlink_LinkClicked);
            // 
            // MasterEditionlink
            // 
            this.MasterEditionlink.AutoSize = true;
            this.MasterEditionlink.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.MasterEditionlink.Location = new System.Drawing.Point(11, 180);
            this.MasterEditionlink.Name = "MasterEditionlink";
            this.MasterEditionlink.Size = new System.Drawing.Size(110, 13);
            this.MasterEditionlink.TabIndex = 21;
            this.MasterEditionlink.TabStop = true;
            this.MasterEditionlink.Text = "Master Edition Project";
            this.MasterEditionlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MasterEditionlink_LinkClicked);
            // 
            // gitBuilderPSXlink
            // 
            this.gitBuilderPSXlink.AutoSize = true;
            this.gitBuilderPSXlink.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.gitBuilderPSXlink.Location = new System.Drawing.Point(132, 164);
            this.gitBuilderPSXlink.Name = "gitBuilderPSXlink";
            this.gitBuilderPSXlink.Size = new System.Drawing.Size(134, 13);
            this.gitBuilderPSXlink.TabIndex = 20;
            this.gitBuilderPSXlink.TabStop = true;
            this.gitBuilderPSXlink.Text = "Project page at github.com";
            this.gitBuilderPSXlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitBuilderPSXlink_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(369, 26);
            this.label3.TabIndex = 18;
            this.label3.Text = "This version is exclusively for creating maps for Psx Doom, for real hardware\r\nan" +
    "d projects such as Psx Doom Master Edition and PsyDoom by BodbDearg.";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.version.Location = new System.Drawing.Point(17, 103);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(225, 13);
            this.version.TabIndex = 13;
            this.version.Text = "GZDoom Builder (Bugfix) 2.3.0.3003 (a0ef520)";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::CodeImp.DoomBuilder.Properties.Resources.GECLOGO;
            this.pictureBox6.Location = new System.Drawing.Point(228, 19);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(156, 50);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.gitlink);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(pictureBox3);
            this.tabPage1.Controls.Add(this.pictureBox4);
            this.tabPage1.Controls.Add(this.zdoomorglink);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(383, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "About GZDoom Builder";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "GZDoom Builder (Bugfix) 2.3.0.3003 (a0ef520)";
            // 
            // gitlink
            // 
            this.gitlink.AutoSize = true;
            this.gitlink.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.gitlink.Location = new System.Drawing.Point(169, 181);
            this.gitlink.Name = "gitlink";
            this.gitlink.Size = new System.Drawing.Size(134, 13);
            this.gitlink.TabIndex = 18;
            this.gitlink.TabStop = true;
            this.gitlink.Text = "Project page at github.com";
            this.gitlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitlink_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 39);
            this.label2.TabIndex = 17;
            this.label2.Text = "GZDoom Builder is designed and programmed by MaxED.\r\nGZDoom Builder uses game con" +
    "figurations created by Gez.\r\nThis version (GZDB-Bugfix) is maintained by ZZYZX.";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CodeImp.DoomBuilder.Properties.Resources.MLogo;
            this.pictureBox4.Location = new System.Drawing.Point(291, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(86, 88);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // zdoomorglink
            // 
            this.zdoomorglink.AutoSize = true;
            this.zdoomorglink.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.zdoomorglink.Location = new System.Drawing.Point(14, 181);
            this.zdoomorglink.Name = "zdoomorglink";
            this.zdoomorglink.Size = new System.Drawing.Size(140, 13);
            this.zdoomorglink.TabIndex = 15;
            this.zdoomorglink.TabStop = true;
            this.zdoomorglink.Text = "Official thread at ZDoom.org";
            this.zdoomorglink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.zdoomorglink_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(pictureBox1);
            this.tabPage2.Controls.Add(this.codeimplink);
            this.tabPage2.Controls.Add(label1);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.builderlink);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(383, 201);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "About Doom Builder";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(413, 277);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button close;
		private System.Windows.Forms.LinkLabel builderlink;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.LinkLabel codeimplink;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.LinkLabel zdoomorglink;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel gitlink;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel gitPsyDoomlink;
        private System.Windows.Forms.LinkLabel MasterEditionlink;
        private System.Windows.Forms.LinkLabel gitBuilderPSXlink;
    }
}