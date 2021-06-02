
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

/*using CodeImp.DoomBuilder.Map;
using System.Threading;
using System;*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using CodeImp.DoomBuilder.Data;
using CodeImp.DoomBuilder.Geometry;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.VisualModes;

#endregion

namespace CodeImp.DoomBuilder.BuilderModes
{
	[ErrorChecker("Check Psx Doom Errors", false, 4000)]
	public class CheckPsxErrors : ErrorChecker
	{
		#region ================== Constants

		private const int PROGRESS_STEP = 1000;
        public const int YFlip = 1;
        public const int Stretched = 2;
        private static string[] animtextures = { "BFALL", "ENERGY0", "FIRE0", "FLAME0", "LAVWAL0", "SFALL", "SLIM0", "TVSNOW0", "WARN0", "WFALL" };
        private static string[] animflats = { "BLOOD", "BSLIME0", "ENERG0", "LAVA0", "WATER0", "SLIME0", "GLOW0", "CSLIME0" };

        #endregion

        #region ================== Constructor / Destructor

        // Constructor
        public CheckPsxErrors()
		{
            SetTotalProgress((General.Map.Map.Linedefs.Count + General.Map.Map.Sectors.Count) / PROGRESS_STEP);
        }

		#endregion

		#region ================== Methods

		// This runs the check
		public override void Run()
		{
            string str;
            int progress = 0;
			int stepprogress = 0;

            // Go for all the liendefs
            foreach (Linedef l in General.Map.Map.Linedefs)
            {
                // Check if we need to align any part of the front sidedef
                if (l.Front != null)
                {
                    CheckErrors(l.Front);
                }

                // Check if we need to align any part of the back sidedef
                if (l.Back != null)
                {
                    CheckErrors(l.Back);
                }

                // Handle thread interruption
                try { Thread.Sleep(0); } catch (ThreadInterruptedException) { return; }

                // We are making progress!
                if ((++progress / PROGRESS_STEP) > stepprogress)
                {
                    stepprogress = (progress / PROGRESS_STEP);
                    AddProgress(1);
                }
            }

            // Go for all the sectors
            foreach (Sector s in General.Map.Map.Sectors)
            {
                // Check floor texture
                if (s.LongFloorTexture != MapSet.EmptyLongName)
                {
                    str = s.FloorTexture;
                    str = str.Remove(str.Length - 1);

                    for (int i = 0; i < animflats.Length; i++)
                    {
                        if (str.Equals(animflats[i]) && s.FloorTexture != (animflats[i] + "1"))
                        {
                            SubmitResult(new ResultFlatAnim(s, false));
                        }
                    }
                }

                // Check ceiling texture
                if (s.LongCeilTexture != MapSet.EmptyLongName)
                {
                    str = s.CeilTexture;
                    str = str.Remove(str.Length - 1);

                    for (int i = 0; i < animflats.Length; i++)
                    {
                        if (str.Equals(animflats[i]) && s.CeilTexture != (animflats[i] + "1"))
                        {
                            SubmitResult(new ResultFlatAnim(s, true));
                        }
                    }
                }

                // Handle thread interruption
                try { Thread.Sleep(0); } catch (ThreadInterruptedException) { return; }

                // We are making progress!
                if ((++progress / PROGRESS_STEP) > stepprogress)
                {
                    stepprogress = (progress / PROGRESS_STEP);
                    AddProgress(1);
                }
            }
        }

        private void CheckErrors(Sidedef sd)
        {
            string str;
            int Mode = 0;
            if (sd.Other != null && sd.Line.IsFlagSet(General.Map.Config.DoubleSidedFlag))
            {
                // Create upper part
                if ((sd.LongHighTexture != MapSet.EmptyLongName))
                {
                    Mode = 0;

                    //[GEC] Texture Stretched
                    if (General.Map.PSXDOOM && General.Map.PSXDOOMTS)
                    {
                        float SecHeight = ((float)sd.Sector.CeilHeight - sd.Other.Sector.CeilHeight);

                        int OffsetY = -sd.OffsetY;

                        if (sd.Line.IsFlagSet(General.Map.Config.UpperUnpeggedFlag))
                        {
                            OffsetY = sd.OffsetY;
                        }

                        if (OffsetY < 0)
                        {
                            OffsetY %= -256;
                            OffsetY = -(-256 - OffsetY);
                        }

                        int neg = 0;

                        if (OffsetY < 0) { OffsetY = -OffsetY; neg = 1; }
                        OffsetY %= 256;
                        if (neg == 1) { OffsetY = 256 - OffsetY; }


                        float flipY = 1.0f;

                        if (neg == 1)
                        {
                            //if (OffsetY >= (128 - (OffsetY % 128))) { flipY = -1.0f; }
                            if (SecHeight >= (256.0f - (float)OffsetY)) { flipY = -1.0f; }
                            if (OffsetY >= 256) { flipY = 1.0f; }
                        }
                        else
                        {
                            //if (OffsetY >= (128 - (OffsetY % 128))) { flipY = -1.0f; }
                            if (SecHeight >= (256.0f - (float)OffsetY)) { flipY = -1.0f; }
                            if (OffsetY == 0) { flipY = 1.0f; }
                        }

                        if (flipY == -1.0f)
                        {
                            float Height = ((256.0f - SecHeight) / SecHeight);

                            if (SecHeight >= (256.0f - (float)OffsetY))
                            {
                                Mode |= YFlip;
                            }
                        }

                        if (neg == 1) { OffsetY %= -256; }
                        else { OffsetY %= 256; }
                        if ((SecHeight > 256.0f && OffsetY != 0))
                        {
                            Mode |= Stretched;
                        }
                        else if (SecHeight > 256.0f)
                        {
                            Mode |= Stretched;
                        }

                        if (Mode != 0)
                        {
                            SubmitResult(new ResultTextureStretched(sd, SidedefPart.Upper, Mode));
                        }


                        str = sd.HighTexture;
                        str = str.Remove(str.Length - 1);
                        for (int i = 0; i < animtextures.Length; i++)
                        {
                            if (str.Equals(animtextures[i]) && sd.HighTexture != (animtextures[i] + "1"))
                            {
                                SubmitResult(new ResultTextureAnim(sd, SidedefPart.Upper, false));
                            }
                        }
                    }
                }

                // Create lower part
                if (sd.LongLowTexture != MapSet.EmptyLongName)
                {
                    //[GEC] Texture Stretched
                    float OffsetY1 = sd.OffsetY;
                    if (General.Map.PSXDOOM && General.Map.PSXDOOMTS)
                    {
                        float SecHeight = (float)sd.Other.Sector.FloorHeight - sd.Sector.FloorHeight;
                        float SecHeight2 = (float)sd.Sector.CeilHeight - sd.Other.Sector.FloorHeight;

                        if (SecHeight2 < 128)
                            SecHeight2 += 256;

                        SecHeight2 %= 128;

                        int OffsetY = sd.OffsetY;

                        if (sd.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
                        {
                            if (OffsetY < 0)
                            {
                                OffsetY %= -128;
                                OffsetY = 128 + OffsetY;
                            }

                            OffsetY %= 128;
                            OffsetY = (OffsetY + (int)SecHeight2);
                            OffsetY &= -129;

                            if (SecHeight > 240.0f)
                            {
                                float Height = -((256.0f - SecHeight) / SecHeight);

                                if (SecHeight2 >= (240.0f - (float)OffsetY))
                                {
                                    Mode |= YFlip;
                                }

                                if ((SecHeight > 240.0f && OffsetY != 0))
                                {
                                    Mode |= Stretched;
                                }
                                else if ((SecHeight > 240.0f))
                                {
                                    Mode |= Stretched;
                                }
                            }
                            else
                            {
                                float Height = -((256.0f - SecHeight) / SecHeight);

                                if (SecHeight >= (256.0f - (float)OffsetY))
                                {
                                    Mode |= YFlip;
                                }
                            }
                        }
                        else
                        {
                            //NO_LowerUnpeggedFlag = false;

                            if (OffsetY > 0)
                            {
                                OffsetY %= 256;
                                OffsetY = -(256 - OffsetY);
                            }

                            int neg = 0;

                            if (OffsetY < 0) { OffsetY = -OffsetY; neg = 1; }
                            OffsetY %= 256;
                            if (neg == 1) { OffsetY = 256 - OffsetY; }


                            float flipY = 1.0f;

                            if (neg == 1)
                            {
                                if (SecHeight >= (256.0f - (float)OffsetY)) { flipY = -1.0f; }
                                if (OffsetY >= 256) { flipY = 1.0f; }
                            }
                            else
                            {
                                if (SecHeight >= (256.0f - (float)OffsetY)) { flipY = -1.0f; }
                                if (OffsetY == 0) { flipY = 1.0f; }
                            }

                            if (flipY == -1.0f)
                            {
                                float Height = ((256.0f - SecHeight) / SecHeight);

                                if (SecHeight >= (256.0f - (float)OffsetY))
                                {
                                    Mode |= YFlip;
                                }
                            }

                            if (neg == 1) { OffsetY %= -256; }
                            else { OffsetY %= 256; }
                            if ((SecHeight > 256.0f && OffsetY != 0))
                            {
                                Mode |= Stretched;
                            }
                            else if (SecHeight > 256.0f)
                            {
                                Mode |= Stretched;
                            }
                        }

                        if (Mode != 0)
                        {
                            SubmitResult(new ResultTextureStretched(sd, SidedefPart.Lower, Mode));
                        }

                        str = sd.LowTexture;
                        str = str.Remove(str.Length - 1);
                        for (int i = 0; i < animtextures.Length; i++)
                        {
                            if (str.Equals(animtextures[i]) && sd.LowTexture != (animtextures[i] + "1"))
                            {
                                SubmitResult(new ResultTextureAnim(sd, SidedefPart.Lower, false));
                            }
                        }
                    }
                }

                // Create middle part
                /*if (sd.MiddleTexture == "-")
                {
                    if ((sd.Line.IsFlagSet("512")) || (sd.Line.IsFlagSet("1024")))//[GEC] Render Mid-Texture / Mid-Texture Translucent (0.5)
                    {
                        SubmitResult(new ResultTextureAnim(sd, SidedefPart.Middle, true));
                    }
                }*/

                if (sd.LongMiddleTexture != MapSet.EmptyLongName)
                {
                    Mode = 0;
                    //[GEC] Texture Stretched
                    if (General.Map.PSXDOOM && General.Map.PSXDOOMTS)
                    {
                        //if (!sd.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Normalize Height
                        {
                            float geotop1 = Math.Min(sd.Sector.CeilHeight, sd.Other.Sector.CeilHeight);
                            float geobottom1 = Math.Max(sd.Sector.FloorHeight, sd.Other.Sector.FloorHeight);
                            float SecHeight = (geotop1 - geobottom1);

                            if (sd.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Normalize Height
                            {
                                SecHeight = 128;
                            }

                            int OffsetY = sd.OffsetY;

                            if (sd.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
                            {
                                OffsetY = -sd.OffsetY;
                            }

                            if (OffsetY > 0)
                            {
                                OffsetY %= 256;
                                OffsetY = -(256 - OffsetY);
                            }

                            int neg = 0;

                            if (OffsetY < 0) { OffsetY = -OffsetY; neg = 1; }
                            OffsetY %= 256;
                            if (neg == 1) { OffsetY = 256 - OffsetY; }


                            float flipY = 1.0f;

                            if (neg == 1)
                            {
                                if (SecHeight >= (256.0f - (float)OffsetY)) { flipY = -1.0f; }
                                if (OffsetY >= 256) { flipY = 1.0f; }
                            }
                            else
                            {
                                if (SecHeight >= (256.0f - (float)OffsetY)) { flipY = -1.0f; }
                                if (OffsetY == 0) { flipY = 1.0f; }
                            }

                            if (flipY == -1.0f)
                            {
                                float Height = ((256.0f - SecHeight) / SecHeight);

                                if (sd.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
                                {
                                    Height = -((256.0f - SecHeight) / SecHeight);
                                }

                                if (SecHeight >= (256.0f - (float)OffsetY))
                                {
                                    Mode |= YFlip;
                                }
                            }

                            if (neg == 1) { OffsetY %= -256; }
                            else { OffsetY %= 256; }
                            if ((SecHeight > 256.0f && OffsetY != 0))
                            {
                                Mode |= Stretched;
                            }
                            else if (SecHeight > 256.0f)
                            {
                                Mode |= Stretched;
                            }

                            if (Mode != 0)
                            {
                                SubmitResult(new ResultTextureStretched(sd, SidedefPart.Middle, Mode));
                            }
                        }

                        str = sd.MiddleTexture;
                        str = str.Remove(str.Length - 1);
                        for (int i = 0; i < animtextures.Length; i++)
                        {
                            if (str.Equals(animtextures[i]) && sd.MiddleTexture != (animtextures[i] + "1"))
                            {
                                SubmitResult(new ResultTextureAnim(sd, SidedefPart.Middle, false));
                            }
                        }
                    }
                }
            }
            else
            {
                // Create middle part
                if (sd.LongMiddleTexture != MapSet.EmptyLongName)
                {
                    //[GEC] Texture Stretched
                    if (General.Map.PSXDOOM && General.Map.PSXDOOMTS)
                    {
                        Mode = 0;
                        float SecHeight = (sd.Sector.CeilHeight - sd.Sector.FloorHeight);

                        int OffsetY = sd.OffsetY;

                        if (sd.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
                        {
                            OffsetY = -sd.OffsetY;
                        }

                        if (OffsetY > 0)
                        {
                            OffsetY %= 256;
                            OffsetY = -(256 - OffsetY);
                        }

                        int neg = 0;

                        if (OffsetY < 0) { OffsetY = -OffsetY; neg = 1; }
                        OffsetY %= 256;
                        if (neg == 1) { OffsetY = 256 - OffsetY; }


                        float flipY = 1.0f;

                        if (neg == 1)
                        {
                            //if (OffsetY >= (128 - (OffsetY % 128))) { flipY = -1.0f; }
                            if (SecHeight >= (256.0f - (float)OffsetY)) { flipY = -1.0f; }
                            if (OffsetY >= 256) { flipY = 1.0f; }
                        }
                        else
                        {
                            //if (OffsetY >= (128 - (OffsetY % 128))) { flipY = -1.0f; }
                            if (SecHeight >= (256.0f - (float)OffsetY)) { flipY = -1.0f; }
                            if (OffsetY == 0) { flipY = 1.0f; }
                        }

                        if (flipY == -1.0f)
                        {
                            float Height = ((256.0f - SecHeight) / SecHeight);

                            if (sd.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
                            {
                                Height = -((256.0f - SecHeight) / SecHeight);
                            }

                            if (SecHeight >= (256.0f - (float)OffsetY))
                            {
                                Mode |= YFlip;
                            }
                        }

                        if (neg == 1) { OffsetY %= -256; }
                        else { OffsetY %= 256; }
                        if ((SecHeight > 256.0f && OffsetY != 0))
                        {
                            Mode |= Stretched;
                        }
                        else if (SecHeight > 256.0f)
                        {
                            Mode |= Stretched;
                        }

                        if (Mode != 0)
                        {
                            SubmitResult(new ResultTextureStretched(sd, SidedefPart.Middle, Mode));
                        }

                        str = sd.MiddleTexture;
                        str = str.Remove(str.Length - 1);
                        for (int i = 0; i < animtextures.Length; i++)
                        {
                            if (str.Equals(animtextures[i]) && sd.MiddleTexture != (animtextures[i] + "1"))
                            {
                                SubmitResult(new ResultTextureAnim(sd, SidedefPart.Middle, false));
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
