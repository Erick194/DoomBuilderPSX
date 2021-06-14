
#region ================== Copyright (c) 2007 Pascal vd Heiden

/*
 * Copyright (c) 2007 Pascal vd Heiden, www.codeimp.com
 * This program is released under GNU General Public License
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 */

#endregion

#region ================== Namespaces

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Types;
using CodeImp.DoomBuilder.Rendering;
using CodeImp.DoomBuilder.Controls;

#endregion

namespace CodeImp.DoomBuilder.Windows
{
    internal partial class SectorEditFormPSX : DelayedForm
    {
        #region ================== Events

        public event EventHandler OnValuesChanged; //mxd

        #endregion

        #region ================== Variables

        private ICollection<Sector> sectors;
        private List<SectorProperties> sectorprops; //mxd
        private bool preventchanges; //mxd
        private bool undocreated; //mxd

        private struct SectorProperties //mxd
        {
            public readonly int IdxColor;//[GEC]
            public readonly int IdxColorCeil;//[GEC]
            public readonly int Brightness;
            public readonly int FloorHeight;
            public readonly int CeilHeight;
            public readonly string FloorTexture;
            public readonly string CeilTexture;

            public SectorProperties(Sector s)
            {
                IdxColor = s.IdxColor;//[GEC]
                IdxColorCeil = s.IdxColorCeil;//[GEC]
                Brightness = s.Brightness;
                FloorHeight = s.FloorHeight;
                CeilHeight = s.CeilHeight;
                FloorTexture = s.FloorTexture;
                CeilTexture = s.CeilTexture;
            }
        }

        #endregion

        #region ================== Constructor

        // Constructor
        public SectorEditFormPSX()
        {
            // Initialize
            InitializeComponent();

            // Fill effects list
            effect.GeneralizedOptions = General.Map.Config.GenEffectOptions; //mxd
            effect.AddInfo(General.Map.Config.SortedSectorEffects.ToArray());

            // Initialize image selectors
            floortex.Initialize();
            ceilingtex.Initialize();

            // Set steps for brightness field
            brightness.StepValues = General.Map.Config.BrightnessLevels;
            //idxcolor.StepValues = General.Map.Config.IdxColorLevels;//[GEC]

            idxcolor.StepValues = new StepsList();//[GEC]
            idxcolorCeil.StepValues = new StepsList();//[GEC]

            for (int i = 0; i < 256; i++)
            {
                idxcolor.StepValues.Add(i);
                idxcolorCeil.StepValues.Add(i);
            }

            // Fill flags list
            foreach (KeyValuePair<string, string> lf in General.Map.Config.SectorFlags)
                flags.Add(lf.Value, lf.Key);
            flags.Enabled = General.Map.Config.SectorFlags.Count > 0;
        }

        #endregion

        #region ================== Methods

        // This sets up the form to edit the given sectors
        public void Setup(ICollection<Sector> sectors)
        {
            preventchanges = true; //mxd
            undocreated = false;
            // Keep this list
            this.sectors = sectors;
            if (sectors.Count > 1) this.Text = "Edit Sectors (" + sectors.Count + ")";
            sectorprops = new List<SectorProperties>(); //mxd

            //mxd. Set default height offset
            heightoffset.Text = "0";

            ////////////////////////////////////////////////////////////////////////
            // Set all options to the first sector properties
            ////////////////////////////////////////////////////////////////////////

            // Get first sector
            Sector sc = General.GetByIndex(sectors, 0);

            // Flags
            foreach (CheckBox c in flags.Checkboxes)
                if (sc.Flags.ContainsKey(c.Tag.ToString())) c.Checked = sc.Flags[c.Tag.ToString()];

            // Effects
            effect.Value = sc.Effect;
            brightness.Text = sc.Brightness.ToString();
            idxcolor.Text = sc.IdxColor.ToString();//[GEC]
            idxcolorCeil.Text = sc.IdxColorCeil.ToString();//[GEC]

            // Floor/ceiling
            floorheight.Text = sc.FloorHeight.ToString();
            ceilingheight.Text = sc.CeilHeight.ToString();
            floortex.TextureName = sc.FloorTexture;
            ceilingtex.TextureName = sc.CeilTexture;

            // Action
            tagSelector.Setup(UniversalType.SectorTag); //mxd
            tagSelector.SetTag(sc.Tag);//mxd

            ////////////////////////////////////////////////////////////////////////
            // Now go for all sectors and change the options when a setting is different
            ////////////////////////////////////////////////////////////////////////

            // Go for all sectors
            foreach (Sector s in sectors)
            {
                // Flags
                SetupFlags(flags, s);

                // Effects
                if (s.Effect != effect.Value) effect.Empty = true;
                if (s.Brightness.ToString() != brightness.Text) brightness.Text = "";
                if (s.IdxColor.ToString() != idxcolor.Text) idxcolor.Text = "";//[GEC]
                if (s.IdxColorCeil.ToString() != idxcolorCeil.Text) idxcolorCeil.Text = "";//[GEC]

                // Floor/Ceiling
                if (s.FloorHeight.ToString() != floorheight.Text) floorheight.Text = "";
                if (s.CeilHeight.ToString() != ceilingheight.Text) ceilingheight.Text = "";
                if (s.FloorTexture != floortex.TextureName)
                {
                    floortex.MultipleTextures = true; //mxd
                    floortex.TextureName = "";
                }
                if (s.CeilTexture != ceilingtex.TextureName)
                {
                    ceilingtex.MultipleTextures = true; //mxd
                    ceilingtex.TextureName = "";
                }

                // Action
                if (s.Tag != sc.Tag) tagSelector.ClearTag(); //mxd

                //mxd. Store initial properties
                sectorprops.Add(new SectorProperties(s));

                // [GEC] Apply new color
                PixelColor rgb = Lights.GetColor(s.IdxColor);
                PixelColor rgbCeil = Lights.GetColor(s.IdxColorCeil);
                pnlSectorColor.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);
                pnlSectorColorCeil.BackColor = Color.FromArgb(rgbCeil.r, rgbCeil.g, rgbCeil.b);
            }

            // Enable or disable the ceiling color setting depending on whether dual colored lighting is allowed
            bool useDualColoredLighting = General.Map.Config.PSXDOOM_DCLIGHTS;

            this.pnlSectorColorCeil.Visible = useDualColoredLighting;
            this.idxcolorCeil.Visible = useDualColoredLighting;
            this.lblSectorColorCeil.Visible = useDualColoredLighting;

            // Show sector height
            UpdateSectorHeight();

            preventchanges = false; //mxd
        }

        //mxd
        private static void SetupFlags(CheckboxArrayControl control, Sector s)
        {
            foreach (CheckBox c in control.Checkboxes)
            {
                if (c.CheckState == CheckState.Indeterminate) continue; //mxd
                if (s.IsFlagSet(c.Tag.ToString()) != c.Checked)
                {
                    c.ThreeState = true;
                    c.CheckState = CheckState.Indeterminate;
                }
            }
        }

        //mxd
        private static void ApplyFlags(CheckboxArrayControl control, Sector s)
        {
            foreach (CheckBox c in control.Checkboxes)
            {
                switch (c.CheckState)
                {
                    case CheckState.Checked: s.SetFlag(c.Tag.ToString(), true); break;
                    case CheckState.Unchecked: s.SetFlag(c.Tag.ToString(), false); break;
                }
            }
        }

        //mxd
        private void MakeUndo()
        {
            if (undocreated) return;
            undocreated = true;

            //mxd. Make undo
            General.Map.UndoRedo.CreateUndo("Edit " + (sectors.Count > 1 ? sectors.Count + " sectors" : "sector"));
        }

        // This updates the sector height field
        private void UpdateSectorHeight()
        {
            int delta = 0;
            int index = -1; //mxd
            int i = 0; //mxd

            // Check all selected sectors
            foreach (Sector s in sectors)
            {
                if (index == -1)
                {
                    // First sector in list
                    delta = s.CeilHeight - s.FloorHeight;
                    index = i; //mxd
                }
                else if (delta != (s.CeilHeight - s.FloorHeight))
                {
                    // We can't show heights because the delta
                    // heights for the sectors is different
                    index = -1;
                    break;
                }

                i++;
            }

            if (index > -1)
            {
                int fh = floorheight.GetResult(sectorprops[index].FloorHeight); //mxd
                int ch = ceilingheight.GetResult(sectorprops[index].CeilHeight); //mxd
                int height = ch - fh;
                sectorheight.Text = height.ToString();
                sectorheight.Visible = true;
                sectorheightlabel.Visible = true;
            }
            else
            {
                sectorheight.Visible = false;
                sectorheightlabel.Visible = false;
            }
        }

        //mxd
        private void UpdateCeilingHeight()
        {
            int i = 0;
            int offset;

            if (heightoffset.Text == "++" || heightoffset.Text == "--") // Raise or lower by sector height
            {
                int sign = (heightoffset.Text == "++" ? 1 : -1);
                foreach (Sector s in sectors)
                {
                    offset = sectorprops[i].CeilHeight - sectorprops[i].FloorHeight;
                    s.CeilHeight += offset * sign;
                    i++;
                }
            }
            else
            {
                offset = heightoffset.GetResult(0);

                //restore values
                if (string.IsNullOrEmpty(ceilingheight.Text))
                {
                    foreach (Sector s in sectors)
                        s.CeilHeight = sectorprops[i++].CeilHeight + offset;
                }
                else //update values
                {
                    foreach (Sector s in sectors)
                        s.CeilHeight = ceilingheight.GetResult(sectorprops[i++].CeilHeight) + offset;
                }
            }
        }

        //mxd
        private void UpdateFloorHeight()
        {
            int i = 0;
            int offset;

            if (heightoffset.Text == "++" || heightoffset.Text == "--")
            {
                // Raise or lower by sector height
                int sign = (heightoffset.Text == "++" ? 1 : -1);
                foreach (Sector s in sectors)
                {
                    offset = sectorprops[i].CeilHeight - sectorprops[i].FloorHeight;
                    s.FloorHeight += offset * sign;
                    i++;
                }
            }
            else
            {
                offset = heightoffset.GetResult(0);

                //restore values
                if (string.IsNullOrEmpty(floorheight.Text))
                {
                    foreach (Sector s in sectors)
                        s.FloorHeight = sectorprops[i++].FloorHeight + offset;
                }
                else //update values
                {
                    foreach (Sector s in sectors)
                        s.FloorHeight = floorheight.GetResult(sectorprops[i++].FloorHeight) + offset;
                }
            }
        }

        #endregion

        #region ================== Events

        // OK clicked
        private void apply_Click(object sender, EventArgs e)
        {
            //mxd. Apply "Static" properties
            // Verify the tag
            tagSelector.ValidateTag(); //mxd
            if ((tagSelector.GetTag(0) < General.Map.FormatInterface.MinTag) || (tagSelector.GetTag(0) > General.Map.FormatInterface.MaxTag))
            {
                General.ShowWarningMessage("Sector tag must be between " + General.Map.FormatInterface.MinTag + " and " + General.Map.FormatInterface.MaxTag + ".", MessageBoxButtons.OK);
                return;
            }

            // Verify the effect
            if ((effect.Value < General.Map.FormatInterface.MinEffect) || (effect.Value > General.Map.FormatInterface.MaxEffect))
            {
                General.ShowWarningMessage("Sector effect must be between " + General.Map.FormatInterface.MinEffect + " and " + General.Map.FormatInterface.MaxEffect + ".", MessageBoxButtons.OK);
                return;
            }

            MakeUndo(); //mxd

            // Go for all sectors
            int tagoffset = 0; //mxd
            foreach (Sector s in sectors)
            {
                // Apply all flags
                ApplyFlags(flags, s);

                // Effects
                if (!effect.Empty) s.Effect = effect.Value;

                // Action
                s.Tag = General.Clamp(tagSelector.GetSmartTag(s.Tag, tagoffset++), General.Map.FormatInterface.MinTag, General.Map.FormatInterface.MaxTag); //mxd
            }

            // Done
            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty); //mxd
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Cancel clicked
        private void cancel_Click(object sender, EventArgs e)
        {
            //mxd. perform undo
            if (undocreated) General.Map.UndoRedo.WithdrawUndo();

            // And be gone
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        // Browse Effect clicked
        private void browseeffect_Click(object sender, EventArgs e)
        {
            effect.Value = EffectBrowserForm.BrowseEffect(this, effect.Value);
        }

        // Help
        private void SectorEditFormPSX_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            General.ShowHelp("w_sectoredit.html");
            hlpevent.Handled = true;
        }

        #endregion

        #region ================== mxd. Realtime Events

        // Ceiling height changes
        private void ceilingheight_TextChanged(object sender, EventArgs e)
        {
            if (preventchanges) return;
            MakeUndo(); //mxd

            UpdateCeilingHeight();
            UpdateSectorHeight();

            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty);
        }

        // Floor height changes
        private void floorheight_TextChanged(object sender, EventArgs e)
        {
            if (preventchanges) return;
            MakeUndo(); //mxd

            UpdateFloorHeight();
            UpdateSectorHeight();

            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty);
        }

        // Height offset changes
        private void heightoffset_WhenTextChanged(object sender, EventArgs e)
        {
            if (preventchanges) return;
            MakeUndo(); //mxd

            UpdateFloorHeight();
            UpdateCeilingHeight();
            UpdateSectorHeight();

            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty);
        }

        private void floortex_OnValueChanged(object sender, EventArgs e)
        {
            if (preventchanges) return;
            MakeUndo(); //mxd

            //restore values
            if (string.IsNullOrEmpty(floortex.TextureName))
            {
                int i = 0;
                foreach (Sector s in sectors) s.SetFloorTexture(sectorprops[i++].FloorTexture);

            }
            else //update values
            {
                foreach (Sector s in sectors) s.SetFloorTexture(floortex.GetResult(s.FloorTexture));
            }

            // Update the used textures
            General.Map.Data.UpdateUsedTextures();

            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty);
        }

        private void ceilingtex_OnValueChanged(object sender, EventArgs e)
        {
            if (preventchanges) return;
            MakeUndo(); //mxd

            //restore values
            if (string.IsNullOrEmpty(ceilingtex.TextureName))
            {
                int i = 0;
                foreach (Sector s in sectors) s.SetCeilTexture(sectorprops[i++].CeilTexture);

            }
            else //update values
            {
                foreach (Sector s in sectors) s.SetCeilTexture(ceilingtex.GetResult(s.CeilTexture));
            }

            // Update the used textures
            General.Map.Data.UpdateUsedTextures();

            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty);
        }

        private void brightness_WhenTextChanged(object sender, EventArgs e)
        {
            if (preventchanges) return;
            MakeUndo(); //mxd
            int i = 0;

            //restore values
            if (string.IsNullOrEmpty(brightness.Text))
            {
                foreach (Sector s in sectors) s.Brightness = sectorprops[i++].Brightness;

            }
            else //update values
            {
                foreach (Sector s in sectors)
                    s.Brightness = General.Clamp(brightness.GetResult(sectorprops[i++].Brightness), General.Map.FormatInterface.MinBrightness, General.Map.FormatInterface.MaxBrightness);
            }

            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty);
        }

        #endregion

        private void IdxColor_WhenTextChanged(object sender, EventArgs e)
        {
            if (preventchanges) return;
            MakeUndo(); //mxd
            int i = 0;

            //restore values
            if (string.IsNullOrEmpty(idxcolor.Text))
            {
                foreach (Sector s in sectors)
                {
                    s.IdxColor = sectorprops[i++].IdxColor;
                    // Apply new color
                    PixelColor rgb = Lights.GetColor(s.IdxColor);
                    pnlSectorColor.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);//frm.Color;
                }

            }
            else //update values
            {
                foreach (Sector s in sectors)
                {
                    s.IdxColor = General.Clamp(idxcolor.GetResult(sectorprops[i++].IdxColor), 0, 255);
                    // Apply new color
                    PixelColor rgb = Lights.GetColor(s.IdxColor);
                    pnlSectorColor.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);//frm.Color;
                }
            }

            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty);
        }

        private void IdxColorCeil_WhenTextChanged(object sender, EventArgs e)
        {
            if (preventchanges) return;
            MakeUndo(); //mxd
            int i = 0;

            //restore values
            if (string.IsNullOrEmpty(idxcolorCeil.Text))
            {
                foreach (Sector s in sectors)
                {
                    s.IdxColorCeil = sectorprops[i++].IdxColorCeil;
                    // Apply new color
                    PixelColor rgb = Lights.GetColor(s.IdxColorCeil);
                    pnlSectorColorCeil.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);//frm.Color;
                }

            }
            else //update values
            {
                foreach (Sector s in sectors)
                {
                    s.IdxColorCeil = General.Clamp(idxcolorCeil.GetResult(sectorprops[i++].IdxColorCeil), 0, 255);
                    // Apply new color
                    PixelColor rgb = Lights.GetColor(s.IdxColorCeil);
                    pnlSectorColorCeil.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);//frm.Color;
                }
            }

            General.Map.IsChanged = true;
            if (OnValuesChanged != null) OnValuesChanged(this, EventArgs.Empty);
        }

        private void drawfrom(object sender, EventArgs e)
        {
            LightColors frm = new LightColors();
            frm.IindexCol = idxcolor.GetResult(0);

            if (frm.ShowDialog(this.ParentForm) == DialogResult.OK)
            {
                // [GEC] Apply new color
                PixelColor rgb = Lights.GetColor(frm.IindexCol);
                idxcolor.Text = frm.IdxCol.ToString();
                pnlSectorColor.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);
            }
        }

        private void drawfromCeil(object sender, EventArgs e)
        {
            LightColors frm = new LightColors();
            frm.IindexCol = idxcolorCeil.GetResult(0);

            if (frm.ShowDialog(this.ParentForm) == DialogResult.OK)
            {
                // [GEC] Apply new color
                PixelColor rgb = Lights.GetColor(frm.IindexCol);
                idxcolorCeil.Text = frm.IdxCol.ToString();
                pnlSectorColorCeil.BackColor = Color.FromArgb(rgb.r, rgb.g, rgb.b);
            }
        }
    }
}