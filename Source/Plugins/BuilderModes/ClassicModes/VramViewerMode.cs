
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

using System.Windows.Forms;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Rendering;
using CodeImp.DoomBuilder.Editing;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

#endregion

namespace CodeImp.DoomBuilder.BuilderModes
{
	[EditMode(DisplayName = "Vram Viewer Mode",
			  SwitchAction = "vramviewer",
			  ButtonImage = "VramViewer.png",
			  ButtonOrder = 400,
			  ButtonGroup = "002_tools",
			  AllowCopyPaste = false,
			  Volatile = true,
			  UseByDefault = true,
              SupportedMapFormats = new[] {"PSXDoomMapSetIO"})]

    public sealed class VramViewerMode : BaseClassicMode
	{
        #region ================== Constants

        #endregion

        #region ================== Variables
        

        public struct Vram
        {
            public string TextureName;
            public int X;
            public int Y;

            // Constructor
            public Vram(string TextureName, int X, int Y)
            {
                this.TextureName = TextureName;
                this.X = X;
                this.Y = Y;
            }
        }

        public List<string> VramTextures = new List<string>();
        public List<string> SwitchTextures = new List<string>();
        public List<Vram> VramT = new List<Vram>();

        private string Skyname = null;
        public byte[] Box1 = new byte[256 * 128];
        public int BlockCnt = 0;
        public int FlatCount = 0;
        public int[,] Block =
        {
            {640, 0},
            {768, 0},
            {896, 0},
            {0, 256},
            {128, 256},
            {256, 256},
            {384, 256},
            {512, 256},
            {640, 256},
            {768, 256},
            {896, 256}
        };
        #endregion

        #region ================== Properties

        internal bool Volatile { get { return attributes.Volatile; } set { attributes.Volatile = value; } } //mxd

		#endregion

		#region ================== Constructor / Disposer

		#endregion

		#region ================== Events

		// Cancelled
		public override void OnCancel()
		{
            // Cancel base class
            base.OnCancel();

            // Return to base mode
            General.Editing.ChangeMode(General.Editing.PreviousStableMode.Name);
        }

        public void FreeBox()
        {
            for (int i = 0; i < 256 * 128; i++)
            {
                Box1[i] = 0x00;
            }
        }

        public int AddToBuffer(int w, int h, ref int x, ref int y)
        {
            int position = (0 * 128) + 0;
            int X = 0, Y = 0;
            int i, j;

            bool NoSpace = false;
            bool NoSpaceX = false;
            bool NoSpaceY = false;

            for (i = 0; i < (128 * 256); i++)
            {
                if (i == (128 * 256) - 1)
                {
                    NoSpace = true;
                    break;
                }

                if (Box1[i] == 0x00)
                {
                    Y = (i / 128);
                    X = i - (Y * 128);

                    if (w == 32)
                    {
                        if (X != 0 && (X != 32) && (X != 64) && (X != 96))
                        {
                            if (X < 32)
                            {
                                X += (32 - X);
                            }
                            else if (X < 64)
                            {
                                X += (64 - X);
                            }
                            else if (X < 96)
                            {
                                X += (96 - X);
                            }
                        }
                    }

                    //Check Widht
                    if (w > (128 - X))
                    {
                        if (i == (128 * 256) - 1)
                        {
                            NoSpace = true;
                            break;
                        }
                        continue;
                    }

                    for (j = 0; j < w; j++)
                    {
                        position = ((Y) * 128) + (X + j);
                        if (Box1[position] != 0x00)
                        {
                            NoSpaceX = true;
                            break;
                        }
                    }
                    if (NoSpaceX)
                    {
                        NoSpaceX = false;
                        continue;
                    }

                    //Check Height
                    if (h > (256 - Y))
                    {
                        if (i == (128 * 256) - 1)
                        {
                            NoSpace = true;
                            break;
                        }
                        continue;
                    }

                    for (j = 0; j < h; j++)
                    {
                        position = ((Y + j) * 128) + (X);
                        if (Box1[position] != 0x00)
                        {
                            NoSpaceY = true;
                            break;
                        }
                    }
                    if (NoSpaceY)
                    {
                        NoSpaceY = false;
                        continue;
                    }

                    break;
                }
            }

            if (!NoSpace)
            {
                x = X;
                y = Y;

                for (int py = 0; py < h; py++)
                {
                    for (int px = 0; px < w; px++)
                    {
                        position = ((py + Y) * 128) + (px + X);
                        Box1[position] = 0xff;
                    }
                }
                return 1;
            }
            else
            {
                x = y = 0;
                return 0;
            }
        }

        private void AddToVram(string TextureName, bool F_SKY)
        {
            bool result = false;

            if (TextureName.Contains("F_SKY") && F_SKY)//remove f_sky
            {
                Skyname = TextureName.Substring(2, TextureName.Length - 2);
                return;
            }

            if (VramTextures.Count != 0)
            {
                for (int i = 0; i < VramTextures.Count; i++) //Verifica si ya existe;
                {
                    result = VramTextures[i].Equals(TextureName);
                    if (result != false)
                        break;
                }

                if (result == false)
                    VramTextures.Add(TextureName);
            }
            else
            {
                VramTextures.Add(TextureName);
            }
        }

        private void FindFlats()
        {
            foreach (Sector s in General.Map.Map.Sectors)
            {
                AddToVram(s.CeilTexture, true);
                AddToVram(s.FloorTexture, !General.Map.PSXDOOM_IFST);
            }
        }

        private void FindTextures(int Width)
        {
            foreach (Sidedef sid in General.Map.Map.Sidedefs)
            {
                Bitmap image;

                if (sid.HighTexture != null)
                {
                    image = General.Map.Data.GetTextureBitmap(sid.HighTexture);

                    if (image != null)
                        if (image.Width == Width)
                            AddToVram(sid.HighTexture, false);
                }
                if (sid.MiddleTexture != null)
                {
                    image = General.Map.Data.GetTextureBitmap(sid.MiddleTexture);

                    if (image != null)
                        if (image.Width == Width)
                            AddToVram(sid.MiddleTexture, false);
                }
                if (sid.LowTexture != null)
                {
                    image = General.Map.Data.GetTextureBitmap(sid.LowTexture);

                    if (image != null)
                        if (image.Width == Width)
                            AddToVram(sid.LowTexture, false);
                }
            }
        }

        private void AddToSwitch(string TextureName)
        {
            bool result = false;

            if (SwitchTextures.Count != 0)
            {
                for (int i = 0; i < SwitchTextures.Count; i++) //Verifica si ya existe;
                {
                    result = SwitchTextures[i].Equals(TextureName);
                    if (result != false)
                        break;
                }

                if (result == false)
                    SwitchTextures.Add(TextureName);
            }
            else
            {
                SwitchTextures.Add(TextureName);
            }
        }

        private void FindSwitch()
        {
            if (VramTextures.Count != 0)
            {
                for (int i = 0; i < VramTextures.Count; i++)
                {
                    string srtA = VramTextures[i];

                    if (srtA.Contains("SW1"))
                    {
                        srtA = "SW2" + srtA.Substring(3, srtA.Length - 3);
                        //AddToVram
                        AddToSwitch(srtA);
                        continue;
                    }

                    if (srtA.Contains("SW2"))
                    {
                        srtA = "SW1" + srtA.Substring(3, srtA.Length - 3);
                        AddToSwitch(srtA);
                        continue;
                    }
                }

                //for (int i = 0; i < SwitchTextures.Count; i++)
                for (int i = SwitchTextures.Count - 1; i >= 0; --i)//Copy to VRAM
                {
                    string srtA = SwitchTextures[i];
                    AddToVram(srtA, false);
                }
            }
        }

        // Mode engages

        // Mode starts
        public override void OnEngage()
		{
            base.OnEngage();
            //renderer.SetPresentation(Presentation.Standard);
            //General.Map.Map.SelectionType = SelectionType.All;

            VramT.Clear();
            SwitchTextures.Clear();
            VramTextures.Clear();

            Skyname = null;
            BlockCnt = 0;
            FlatCount = 0;
            FreeBox();

            FindFlats();
            FlatCount = VramTextures.Count;

            if (Skyname != null)// Add Sky Texture
                VramTextures.Add(Skyname);

            FindTextures(16);
            FindTextures(64);
            FindSwitch();
            FindTextures(128);

            if (VramTextures.Count != 0)
            {
                for (int i = 0; i < VramTextures.Count; i++)
                {
                Found:
                    int x = 0;
                    int y = 0;

                    if(i == FlatCount && BlockCnt  == 0)
                    {
                        FreeBox();
                        BlockCnt = 1;
                    }

                    Bitmap image = General.Map.Data.GetTextureBitmap(VramTextures[i]);

                    if (image != null)
                    {
                        int find = AddToBuffer(image.Width / 2, image.Height, ref x, ref y);

                        if (find == 0)
                        {
                            FreeBox();
                            BlockCnt++;

                            if (BlockCnt >= 11)
                                BlockCnt = 0;

                            goto Found;
                        }

                        x += Block[BlockCnt, 0];
                        y += Block[BlockCnt, 1];

                        VramT.Add(new Vram(VramTextures[i], x, y));
                    }
                }

                VramTextures.Clear();
            }

            // Show toolbox window
            BuilderPlug.Me.VramViewerForm.Show((Form)General.Interface, this);
		}

		// Disenagaging
		public override void OnDisengage()
		{
            base.OnDisengage();

			// Hide object info
			General.Interface.HideInfo();
			
			// Hide toolbox window
			BuilderPlug.Me.VramViewerForm.Hide();
        }

        // This applies the curves and returns to the base mode
        public override void OnAccept()
        {
            // Snap to map format accuracy
            General.Map.Map.SnapAllToAccuracy();

            // Update caches
            General.Map.Map.Update();
            General.Map.IsChanged = true;

            // Return to base mode
            General.Editing.ChangeMode(General.Editing.PreviousStableMode.Name);
        }

		#endregion
	}
}



/*private void RemoveRepeat()
{
    if (VramTextures.Count != 0)
    {
    Buscar:
        for (int i = 0; i < VramTextures.Count; i++)
        {
            string srtA = VramTextures[i];

            if (srtA.Contains("F_SKY"))//remove f_sky
            {
                Skyname = srtA.Substring(2, srtA.Length - 2);
                //General.ErrorLogger.Add(ErrorType.Error, srtA);

                //VramTextures.Add(srtA);
                VramTextures.RemoveAt(i);
                goto Buscar;
            }

            for (int j = i + 1; j < VramTextures.Count; j++)
            {
                string srtB = VramTextures[j];

                bool result = srtA.Equals(srtB);
                if (result != false)
                {
                    VramTextures.RemoveAt(j);
                    goto Buscar;
                }
            }
        }
    }

    if (Skyname != null)
    {
        VramTextures.Add(Skyname);
        Skyname = null;
    }
}

private void FindTextures(int Width)
{
    foreach (Sidedef sid in General.Map.Map.Sidedefs)
    {
        Bitmap image;

        if (sid.HighTexture != null)
        {
            image = General.Map.Data.GetTextureBitmap(sid.HighTexture);

            if (image != null)
                if (image.Width == Width)
                    VramTextures.Add(sid.HighTexture);
        }
        if (sid.MiddleTexture != null)
        {
            image = General.Map.Data.GetTextureBitmap(sid.MiddleTexture);

            if (image != null)
                if (image.Width == Width)
                    VramTextures.Add(sid.MiddleTexture);
        }
        if (sid.LowTexture != null)
        {
            image = General.Map.Data.GetTextureBitmap(sid.LowTexture);

            if (image != null)
                if (image.Width == Width)
                    VramTextures.Add(sid.LowTexture);
        }
    }

    RemoveRepeat();
}

private void FindSwitch()
{
    SwitchTextures.Clear();

    if (VramTextures.Count != 0)
    {
        for (int i = 0; i < VramTextures.Count; i++)
        {
            string srtA = VramTextures[i];

            if (srtA.Contains("SW1"))//
            {
                string srtB = "SW2";

                srtA = srtA.Substring(3, srtA.Length - 3);
                srtA = srtB + srtA;
                //General.ErrorLogger.Add(ErrorType.Error, srtA);

                SwitchTextures.Add(srtA);
            }
            else if (srtA.Contains("SW2"))//
            {
                string srtB = "SW1";

                srtA = srtA.Substring(3, srtA.Length - 3);
                srtA = srtB + srtA;
                //General.ErrorLogger.Add(ErrorType.Error, srtA);

                SwitchTextures.Add(srtA);
            }
        }
    }

    if (SwitchTextures.Count != 0)
    {
        for (int i = 0; i < SwitchTextures.Count; i++)
        {
            string srtA = SwitchTextures[i];

            //General.ErrorLogger.Add(ErrorType.Error, srtA);
            VramTextures.Add(srtA);
        }

        SwitchTextures.Clear();
    }

    RemoveRepeat();
}*/
