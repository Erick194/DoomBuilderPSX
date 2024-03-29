
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
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Geometry;
using CodeImp.DoomBuilder.Rendering;
using CodeImp.DoomBuilder.Types;
using CodeImp.DoomBuilder.VisualModes;
using CodeImp.DoomBuilder.Data;

#endregion

namespace CodeImp.DoomBuilder.BuilderModes
{
	internal sealed class VisualMiddleDouble : BaseVisualGeometrySidedef
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private bool repeatmidtex;
		private Plane topclipplane;
		private Plane bottomclipplane;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor / Setup

		// Constructor
		public VisualMiddleDouble(BaseVisualMode mode, VisualSector vs, Sidedef s) : base(mode, vs, s)
		{
			//mxd
			geometrytype = VisualGeometryType.WALL_MIDDLE;
			partname = "mid";
			
			// Set render pass
			this.RenderPass = RenderPass.Mask;
			
			// We have no destructor
			GC.SuppressFinalize(this);
		}
		
		// This builds the geometry. Returns false when no geometry created.
		public override bool Setup()
		{
            //[GEC]
            if (General.Map.PSXDOOM)
            {
                if (Sidedef.LongMiddleTexture == MapSet.EmptyLongName)
                {
                    if ((!Sidedef.Line.IsFlagSet("512")) && (!Sidedef.Line.IsFlagSet("1024")))//[GEC] Render Mid-Texture / Mid-Texture Translucent (0.5)
                    {
                        base.SetVertices(null);
                        return false;
                    }
                }
            }
            else
            {
                //mxd
                if (Sidedef.LongMiddleTexture == MapSet.EmptyLongName)
                {
                    base.SetVertices(null);
                    return false;
                }
            }
			
			Vector2D vl, vr;

			//mxd. lightfog flag support
			int lightvalue;
			bool lightabsolute;
			GetLightValue(out lightvalue, out lightabsolute);
			
			Vector2D tscale = new Vector2D(Sidedef.Fields.GetValue("scalex_mid", 1.0f),
										   Sidedef.Fields.GetValue("scaley_mid", 1.0f));
            Vector2D tscaleAbs = new Vector2D(Math.Abs(tscale.x), Math.Abs(tscale.y));
            Vector2D toffset = new Vector2D(Sidedef.Fields.GetValue("offsetx_mid", 0.0f),
											Sidedef.Fields.GetValue("offsety_mid", 0.0f));
			
			// Left and right vertices for this sidedef
			if(Sidedef.IsFront) 
			{
				vl = new Vector2D(Sidedef.Line.Start.Position.x, Sidedef.Line.Start.Position.y);
				vr = new Vector2D(Sidedef.Line.End.Position.x, Sidedef.Line.End.Position.y);
			} 
			else 
			{
				vl = new Vector2D(Sidedef.Line.End.Position.x, Sidedef.Line.End.Position.y);
				vr = new Vector2D(Sidedef.Line.Start.Position.x, Sidedef.Line.Start.Position.y);
			}

            if (General.Map.PSXDOOM)
            {
                if (Sidedef.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Scale xy
                {
                    if (Sidedef.IsFront)
                    {
                        vl.x = vl.x - (float)Math.Cos(Sidedef.Line.Angle) * 0.5f;
                        vl.y = vl.y - (float)Math.Sin(Sidedef.Line.Angle) * 0.5f;

                        vr.x = vr.x - (float)Math.Cos(Sidedef.Line.Angle) * 0.5f;
                        vr.y = vr.y - (float)Math.Sin(Sidedef.Line.Angle) * 0.5f;
                        //vl /= 1.002f;
                        //vr /= 1.002f;
                    }
                    else
                    {
                        vl.x = vl.x + (float)Math.Cos(Sidedef.Line.Angle) * 0.5f;
                        vl.y = vl.y + (float)Math.Sin(Sidedef.Line.Angle) * 0.5f;

                        vr.x = vr.x + (float)Math.Cos(Sidedef.Line.Angle) * 0.5f;
                        vr.y = vr.y + (float)Math.Sin(Sidedef.Line.Angle) * 0.5f;
                        //vl *= 1.002f;
                        //vr *= 1.002f;
                    }
                }
            }

            // Load sector data
            SectorData sd = mode.GetSectorData(Sidedef.Sector);
			SectorData osd = mode.GetSectorData(Sidedef.Other.Sector);
			if(!osd.Updated) osd.Update();

			// Load texture
			if(Sidedef.LongMiddleTexture != MapSet.EmptyLongName) 
			{
				base.Texture = General.Map.Data.GetTextureImage(Sidedef.LongMiddleTexture);
				if(base.Texture == null || base.Texture is UnknownImage) 
				{
					base.Texture = General.Map.Data.UnknownTexture3D;
					setuponloadedtexture = Sidedef.LongMiddleTexture;
				} 
				else if(!base.Texture.IsImageLoaded) 
				{
					setuponloadedtexture = Sidedef.LongMiddleTexture;
                }
			} 
			else 
			{
				// Use missing texture
				base.Texture = General.Map.Data.MissingTexture3D;
				setuponloadedtexture = 0;
			}

			// Get texture scaled size
			Vector2D tsz = new Vector2D(base.Texture.ScaledWidth, base.Texture.ScaledHeight);

            //[GEC] Texture Stretched
            float OffsetY1 = Sidedef.OffsetY;
            if (General.Map.PSXDOOM && General.Map.PSXDOOMTS)
            {
                //if (!Sidedef.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Normalize Height
                {
                    float geotop1 = Math.Min(Sidedef.Sector.CeilHeight, Sidedef.Other.Sector.CeilHeight);
                    float geobottom1 = Math.Max(Sidedef.Sector.FloorHeight, Sidedef.Other.Sector.FloorHeight);
                    float SecHeight = (geotop1 - geobottom1);

                    if (Sidedef.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Normalize Height
                    {
                        SecHeight = 128;
                    }

                    int OffsetY = Sidedef.OffsetY;

                    if (Sidedef.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
                    {
                        OffsetY = -Sidedef.OffsetY;
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

                        if (Sidedef.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
                        {
                            Height = -((256.0f - SecHeight) / SecHeight);
                        }

                        if (SecHeight >= (256.0f - (float)OffsetY))
                        {
                            if (Height < 0) tscale.y = (1.0f * Height);
                            else tscale.y = (-1.0f * Height);

                            if (neg == 1)
                                OffsetY1 = -OffsetY / Height;
                            else
                                OffsetY1 = OffsetY / Height;
                        }
                    }

                    if (neg == 1) { OffsetY %= -256; }
                    else { OffsetY %= 256; }
                    if ((SecHeight > 256.0f && OffsetY != 0))
                    {
                        tscale.y = (tscale.y / (SecHeight / 256.0f) / 10.0f);
                        OffsetY1 = Sidedef.OffsetY * (SecHeight / 128.0f);
                    }
                    else if (SecHeight > 256.0f)
                    {
                        tscale.y = (tscale.y / (SecHeight / 256.0f));
                        OffsetY1 = Sidedef.OffsetY * (SecHeight / 128.0f);
                    }

                    /*float flipY = 1.0f;
                    int OffsetY = Sidedef.OffsetY;
                    OffsetY %= -256;
                    if (OffsetY < 0) { flipY = -1.0f; }
                    if (OffsetY < -128) { flipY = 1.0f; }

                    if (flipY == -1.0f)
                    {
                        float Height = (SecHeight / 128.0f) * (SecHeight / 128.0f) * (SecHeight / 128.0f) * (SecHeight / 128.0f);
                        if (SecHeight > 128.0f) { tsz = new Vector2D(base.Texture.ScaledWidth, (base.Texture.ScaledHeight * flipY) * Height); }
                        else { tsz = new Vector2D(base.Texture.ScaledWidth, (base.Texture.ScaledHeight * flipY)); }
                    }
                    else
                    {
                        if (SecHeight > 216.0f && OffsetY != 0) { tsz = new Vector2D(base.Texture.ScaledWidth, (base.Texture.ScaledHeight * flipY) * 10.0f); }
                        else if (SecHeight > 256.0f) { tsz = new Vector2D(base.Texture.ScaledWidth, (base.Texture.ScaledHeight * flipY) * (SecHeight / 256.0f)); }
                        else { tsz = new Vector2D(base.Texture.ScaledWidth, (base.Texture.ScaledHeight * flipY)); }
                    }*/
                }
            }

            tsz = tsz / tscale;

			// Get texture offsets
			Vector2D tof = new Vector2D(Sidedef.OffsetX, OffsetY1/*Sidedef.OffsetY*/);
			tof = tof + toffset;
			tof = tof / tscaleAbs;
			if(General.Map.Config.ScaledTextureOffsets && !base.Texture.WorldPanning)
				tof = tof * base.Texture.Scale;

			// Determine texture coordinates plane as they would be in normal circumstances.
			// We can then use this plane to find any texture coordinate we need.
			// The logic here is the same as in the original VisualMiddleSingle (except that
			// the values are stored in a TexturePlane)
			// NOTE: I use a small bias for the floor height, because if the difference in
			// height is 0 then the TexturePlane doesn't work!
			TexturePlane tp = new TexturePlane();
			float floorbias = (Sidedef.Sector.CeilHeight == Sidedef.Sector.FloorHeight) ? 1.0f : 0.0f;
			float geotop = Math.Min(Sidedef.Sector.CeilHeight, Sidedef.Other.Sector.CeilHeight);
			float geobottom = Math.Max(Sidedef.Sector.FloorHeight, Sidedef.Other.Sector.FloorHeight);
			float zoffset = Sidedef.Sector.CeilHeight - Sidedef.Other.Sector.CeilHeight; //mxd

			// When lower unpegged is set, the middle texture is bound to the bottom
			if(Sidedef.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag)) 
				tp.tlt.y = tsz.y - (geotop - geobottom);

            //[GEC]
            if (General.Map.PSXDOOM)
            {
                if (Sidedef.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Automatic LowerUnpeggedFlag
                {
                    tp.tlt.y = tsz.y - (geotop - geobottom);
                }
            }

            if (zoffset > 0) tp.tlt.y -= zoffset; //mxd
			tp.trb.x = tp.tlt.x + (float)Math.Round(Sidedef.Line.Length); //mxd. (G)ZDoom snaps texture coordinates to integral linedef length
			tp.trb.y = tp.tlt.y + (Sidedef.Sector.CeilHeight - (Sidedef.Sector.FloorHeight + floorbias));

			// Apply texture offset
			tp.tlt += tof;
			tp.trb += tof;

			// Transform pixel coordinates to texture coordinates
			tp.tlt /= tsz;
			tp.trb /= tsz;

			// Left top and right bottom of the geometry that
			tp.vlt = new Vector3D(vl.x, vl.y, Sidedef.Sector.CeilHeight);
			tp.vrb = new Vector3D(vr.x, vr.y, Sidedef.Sector.FloorHeight + floorbias);

			// Make the right-top coordinates
			tp.trt = new Vector2D(tp.trb.x, tp.tlt.y);
			tp.vrt = new Vector3D(tp.vrb.x, tp.vrb.y, tp.vlt.z);

			// Keep top and bottom planes for intersection testing
			top = sd.Ceiling.plane;
			bottom = sd.Floor.plane;

			// Create initial polygon, which is just a quad between floor and ceiling
			WallPolygon poly = new WallPolygon();
            /*poly.Add(new Vector3D(vl.x, vl.y, sd.Floor.plane.GetZ(vl)));
			poly.Add(new Vector3D(vl.x, vl.y, sd.Ceiling.plane.GetZ(vl)));
			poly.Add(new Vector3D(vr.x, vr.y, sd.Ceiling.plane.GetZ(vr)));
			poly.Add(new Vector3D(vr.x, vr.y, sd.Floor.plane.GetZ(vr)));*/
            //[GEC]
            if (General.Map.PSXDOOM)
            {
                if (Sidedef.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Automatic Clip
                {
                    float z1 = Math.Max(sd.Ceiling.plane.GetZ(vl), 65536);
                    float z2 = Math.Max(sd.Ceiling.plane.GetZ(vr), 65536);

                    poly.Add(new Vector3D(vl.x, vl.y, sd.Floor.plane.GetZ(vl)));
                    poly.Add(new Vector3D(vl.x, vl.y, z1));
                    poly.Add(new Vector3D(vr.x, vr.y, z2));
                    poly.Add(new Vector3D(vr.x, vr.y, sd.Floor.plane.GetZ(vr)));
                }
                else
                {
                    poly.Add(new Vector3D(vl.x, vl.y, sd.Floor.plane.GetZ(vl)));
                    poly.Add(new Vector3D(vl.x, vl.y, sd.Ceiling.plane.GetZ(vl)));
                    poly.Add(new Vector3D(vr.x, vr.y, sd.Ceiling.plane.GetZ(vr)));
                    poly.Add(new Vector3D(vr.x, vr.y, sd.Floor.plane.GetZ(vr)));
                }
            }
            else
            {
                poly.Add(new Vector3D(vl.x, vl.y, sd.Floor.plane.GetZ(vl)));
                poly.Add(new Vector3D(vl.x, vl.y, sd.Ceiling.plane.GetZ(vl)));
                poly.Add(new Vector3D(vr.x, vr.y, sd.Ceiling.plane.GetZ(vr)));
                poly.Add(new Vector3D(vr.x, vr.y, sd.Floor.plane.GetZ(vr)));
            }

            // Determine initial color
            int lightlevel = lightabsolute ? lightvalue : sd.Ceiling.brightnessbelow + lightvalue;
            if (General.Map.PSXDOOM)//[GEC]
            {
                base.lightlevel = sd.Ceiling.sector.Brightness;
                lightlevel = 255;
            }

            //mxd. This calculates light with doom-style wall shading
            PixelColor wallbrightness = PixelColor.FromInt(mode.CalculateBrightness(lightlevel, Sidedef));
			PixelColor wallcolor = PixelColor.Modulate(sd.Ceiling.colorbelow, wallbrightness);
			fogfactor = CalculateFogFactor(lightlevel);

            if (General.Map.PSXDOOM)//[GEC]
            {
                fogfactor = CalculateFogFactor(255);
                base.lightmode = 1;
            }

            poly.SetShadingParams(Sidedef.Sector, wallcolor.WithAlpha(255)); // [GEC]

            // Cut off the part below the other floor and above the other ceiling
            if (General.Map.PSXDOOM)
            {
                if (!Sidedef.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture
                {
                    CropPoly(ref poly, osd.Ceiling.plane, true);
                    CropPoly(ref poly, osd.Floor.plane, true);
                }
            }
            else
            {
                CropPoly(ref poly, osd.Ceiling.plane, true);
                CropPoly(ref poly, osd.Floor.plane, true);
            }

			// Determine if we should repeat the middle texture
			repeatmidtex = Sidedef.IsFlagSet("wrapmidtex") || Sidedef.Line.IsFlagSet("wrapmidtex"); //mxd

            //[GEC] Texture repeat default in psxdoom
            if (General.Map.PSXDOOM)
            {
                repeatmidtex = true;

                if (Sidedef.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Disable Repeat Texture
                {
                    repeatmidtex = false;
                }
            }

            if (!repeatmidtex) 
			{
				// First determine the visible portion of the texture
				float textop;

				// Determine top portion height
				if(Sidedef.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
					textop = geobottom + tof.y + Math.Abs(tsz.y);
				else
					textop = geotop + tof.y;

                //[GEC]
                if (General.Map.PSXDOOM)
                {
                    if (Sidedef.Line.IsFlagSet("4096"))//[GEC] Clip Mid-Texture - Automatic LowerUnpeggedFlag
                    {
                        textop = geobottom + Math.Abs(tsz.y);
                    }
                }

                // Calculate bottom portion height
                float texbottom = textop - Math.Abs(tsz.y);

				// Create crop planes (we also need these for intersection testing)
				topclipplane = new Plane(new Vector3D(0, 0, -1), textop);
				bottomclipplane = new Plane(new Vector3D(0, 0, 1), -texbottom);

				// Crop polygon by these heights
				CropPoly(ref poly, topclipplane, true);
				CropPoly(ref poly, bottomclipplane, true);
			}

			//mxd. In(G)ZDoom, middle sidedef parts are not clipped by extrafloors of any type...
			List<WallPolygon> polygons = new List<WallPolygon> { poly };
			//ClipExtraFloors(polygons, sd.ExtraFloors, true); //mxd
			//ClipExtraFloors(polygons, osd.ExtraFloors, true); //mxd

			//if(polygons.Count > 0) 
			//{
				// Keep top and bottom planes for intersection testing
				top = osd.Ceiling.plane;
				bottom = osd.Floor.plane;

				// Process the polygon and create vertices
				List<WorldVertex> verts = CreatePolygonVertices(polygons, tp, sd, lightvalue, lightabsolute);
				if(verts.Count > 2) 
				{
					// Apply alpha to vertices
					byte alpha = SetLinedefRenderstyle(true);

                    if (General.Map.PSXDOOM)
                    {
                        if (Sidedef.Line.IsFlagSet("1024"))//[GEC] MidTranslucent (0.5)
                        {
                            this.RenderPass = RenderPass.Alpha;
                            alpha = (byte)(General.Clamp(0.5f, 0f, 1f) * 255);
                        }
                    }

                    if (alpha < 255) 
					{
						for(int i = 0; i < verts.Count; i++) 
						{
							WorldVertex v = verts[i];
							v.c = PixelColor.FromInt(v.c).WithAlpha(alpha).ToInt();
							verts[i] = v;
						}
					}

					base.SetVertices(verts);
					return true;
				}
			//}
			
			base.SetVertices(null); //mxd
			return false;
		}
		
		#endregion

		#region ================== Methods

		// This performs a fast test in object picking
		public override bool PickFastReject(Vector3D from, Vector3D to, Vector3D dir)
		{
			if(!repeatmidtex)
			{
				// When the texture is not repeated, leave when outside crop planes
				if((pickintersect.z < bottomclipplane.GetZ(pickintersect)) ||
				   (pickintersect.z > topclipplane.GetZ(pickintersect)))
				   return false;
			}
			
			return base.PickFastReject(from, to, dir);
		}

		//mxd. Alpha based picking
		public override bool PickAccurate(Vector3D from, Vector3D to, Vector3D dir, ref float u_ray) 
		{
			if(!BuilderPlug.Me.AlphaBasedTextureHighlighting || !Texture.IsImageLoaded || (!Texture.IsTranslucent && !Texture.IsMasked)) return base.PickAccurate(from, to, dir, ref u_ray);

			float u;
			new Line2D(from, to).GetIntersection(Sidedef.Line.Line, out u);
			if(Sidedef != Sidedef.Line.Front) u = 1.0f - u;

			// Some textures (e.g. HiResImage) may lie about their size, so use bitmap size instead
			Bitmap image = Texture.GetBitmap();

            lock (image)
            {
                // Determine texture scale...
                Vector2D imgscale = new Vector2D((float)Texture.Width / image.Width, (float)Texture.Height / image.Height);
                Vector2D texscale = (Texture is HiResImage) ? imgscale * Texture.Scale : Texture.Scale;

                // Get correct offset to texture space...
                int ox = (int)Math.Floor((u * Sidedef.Line.Length * UniFields.GetFloat(Sidedef.Fields, "scalex_mid", 1.0f) / texscale.x
                    + ((Sidedef.OffsetX + UniFields.GetFloat(Sidedef.Fields, "offsetx_mid")) / imgscale.x))
                    % image.Width);

                int oy;
                if (repeatmidtex)
                {
                    bool pegbottom = Sidedef.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag);
                    float zoffset = (pegbottom ? Sidedef.Sector.FloorHeight : Sidedef.Sector.CeilHeight);
                    oy = (int)Math.Floor(((pickintersect.z - zoffset) * UniFields.GetFloat(Sidedef.Fields, "scaley_mid", 1.0f) / texscale.y
                        - ((Sidedef.OffsetY - UniFields.GetFloat(Sidedef.Fields, "offsety_mid")) / imgscale.y))
                        % image.Height);
                }
                else
                {
                    float zoffset = bottomclipplane.GetZ(pickintersect);
                    oy = (int)Math.Ceiling(((pickintersect.z - zoffset) * UniFields.GetFloat(Sidedef.Fields, "scaley_mid", 1.0f) / texscale.y) % image.Height);
                }

                // Make sure offsets are inside of texture dimensions...
                if (ox < 0) ox += image.Width;
                if (oy < 0) oy += image.Height;

                // Check pixel alpha
                Point pixelpos = new Point(General.Clamp(ox, 0, image.Width - 1), General.Clamp(image.Height - oy, 0, image.Height - 1));
                return (image.GetPixel(pixelpos.X, pixelpos.Y).A > 0 && base.PickAccurate(from, to, dir, ref u_ray));
            }
		}
		
		// Return texture name
		public override string GetTextureName()
		{
			return this.Sidedef.MiddleTexture;
		}

		// This changes the texture
		protected override void SetTexture(string texturename)
		{
			this.Sidedef.SetTextureMid(texturename);
			General.Map.Data.UpdateUsedTextures();
			this.Setup();
		}

		protected override void SetTextureOffsetX(int x)
		{
			Sidedef.Fields.BeforeFieldsChange();
			Sidedef.Fields["offsetx_mid"] = new UniValue(UniversalType.Float, (float)x);
		}

		protected override void SetTextureOffsetY(int y)
		{
			Sidedef.Fields.BeforeFieldsChange();
			Sidedef.Fields["offsety_mid"] = new UniValue(UniversalType.Float, (float)y);
		}

		protected override void MoveTextureOffset(int offsetx, int offsety)
		{
			Sidedef.Fields.BeforeFieldsChange();
			float oldx = Sidedef.Fields.GetValue("offsetx_mid", 0.0f);
			float oldy = Sidedef.Fields.GetValue("offsety_mid", 0.0f);
			float scalex = Sidedef.Fields.GetValue("scalex_mid", 1.0f);
			float scaley = Sidedef.Fields.GetValue("scaley_mid", 1.0f);
			bool textureloaded = (Texture != null && Texture.IsImageLoaded); //mxd
			Sidedef.Fields["offsetx_mid"] = new UniValue(UniversalType.Float, GetRoundedTextureOffset(oldx, offsetx, scalex, textureloaded ? Texture.Width : -1)); //mxd

			//mxd. Don't clamp offsetY of clipped mid textures
			bool dontClamp = (!textureloaded || (!Sidedef.IsFlagSet("wrapmidtex") && !Sidedef.Line.IsFlagSet("wrapmidtex")));
			Sidedef.Fields["offsety_mid"] = new UniValue(UniversalType.Float, GetRoundedTextureOffset(oldy, offsety, scaley, dontClamp ? -1 : Texture.Height));
		}

		protected override Point GetTextureOffset()
		{
			float oldx = Sidedef.Fields.GetValue("offsetx_mid", 0.0f);
			float oldy = Sidedef.Fields.GetValue("offsety_mid", 0.0f);
			return new Point((int)oldx, (int)oldy);
		}

		//mxd
		protected override void ResetTextureScale() 
		{
			Sidedef.Fields.BeforeFieldsChange();
			if(Sidedef.Fields.ContainsKey("scalex_mid")) Sidedef.Fields.Remove("scalex_mid");
			if(Sidedef.Fields.ContainsKey("scaley_mid")) Sidedef.Fields.Remove("scaley_mid");
		}

		//mxd
		public override void OnTextureFit(FitTextureOptions options) 
		{
			if(!General.Map.UDMF) return;
			if(string.IsNullOrEmpty(Sidedef.MiddleTexture) || Sidedef.MiddleTexture == "-" || !Texture.IsImageLoaded) return;
			FitTexture(options);
			Setup();
		}
		
		#endregion
	}
}
