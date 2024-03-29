
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
	internal sealed class VisualMiddleSingle : BaseVisualGeometrySidedef
	{
		#region ================== Constants

		#endregion
		
		#region ================== Variables

		#endregion
		
		#region ================== Properties

		#endregion
		
		#region ================== Constructor / Setup
		
		// Constructor
		public VisualMiddleSingle(BaseVisualMode mode, VisualSector vs, Sidedef s) : base(mode, vs, s)
		{
			//mxd
			geometrytype = VisualGeometryType.WALL_MIDDLE;
			partname = "mid";
			
			// We have no destructor
			GC.SuppressFinalize(this);
		}
		
		// This builds the geometry. Returns false when no geometry created.
		public override bool Setup()
		{
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

			// Load sector data
			SectorData sd = mode.GetSectorData(Sidedef.Sector);
			
			// Texture given?
			if(Sidedef.LongMiddleTexture != MapSet.EmptyLongName)
			{
				// Load texture
				base.Texture = General.Map.Data.GetTextureImage(Sidedef.LongMiddleTexture);
				if(base.Texture == null || base.Texture is UnknownImage)
				{
					base.Texture = General.Map.Data.UnknownTexture3D;
					setuponloadedtexture = Sidedef.LongMiddleTexture;
				}
				else
				{
					if(!base.Texture.IsImageLoaded)
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
                float SecHeight = (Sidedef.Sector.CeilHeight - Sidedef.Sector.FloorHeight);

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

                if (OffsetY < 0) { OffsetY = -OffsetY; neg = 1;}
                OffsetY %= 256;
                if (neg == 1) { OffsetY = 256 - OffsetY;}
                

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
                    if (SecHeight >= (256.0f - (float)OffsetY)){ flipY = -1.0f; }
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

                if (neg == 1) {OffsetY %= -256; }
                else { OffsetY %= 256; }
                if ((SecHeight > 256.0f && OffsetY != 0))
                {
                    //tscale.y = tscale.y / ((SecHeight / 128.0f) *  10.0f);
                    tscale.y = (tscale.y / (SecHeight / 256.0f) / 10.0f);
                    OffsetY1 = Sidedef.OffsetY * (SecHeight / 128.0f);
                }
                else if (SecHeight > 256.0f)
                {
                    tscale.y = (tscale.y / (SecHeight / 256.0f));
                    OffsetY1 = Sidedef.OffsetY * (SecHeight / 128.0f);
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
			if(Sidedef.Line.IsFlagSet(General.Map.Config.LowerUnpeggedFlag))
			{
				// When lower unpegged is set, the middle texture is bound to the bottom
				tp.tlt.y = tsz.y - (Sidedef.Sector.CeilHeight - Sidedef.Sector.FloorHeight);
			}
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

            

            // Get ceiling and floor heights
            float fl = sd.Floor.plane.GetZ(vl);
			float fr = sd.Floor.plane.GetZ(vr);
			float cl = sd.Ceiling.plane.GetZ(vl);
			float cr = sd.Ceiling.plane.GetZ(vr);
			
			// Anything to see?
			if(((cl - fl) > 0.01f) || ((cr - fr) > 0.01f))
			{
				// Keep top and bottom planes for intersection testing
				top = sd.Ceiling.plane;
				bottom = sd.Floor.plane;
				
				// Create initial polygon, which is just a quad between floor and ceiling
				WallPolygon poly = new WallPolygon();
				poly.Add(new Vector3D(vl.x, vl.y, fl));
				poly.Add(new Vector3D(vl.x, vl.y, cl));
				poly.Add(new Vector3D(vr.x, vr.y, cr));
				poly.Add(new Vector3D(vr.x, vr.y, fr));
				
				// Determine initial color
				int lightlevel = lightabsolute ? lightvalue : sd.Ceiling.brightnessbelow + lightvalue;
                if (General.Map.PSXDOOM)//[GEC]
                {
                    base.lightlevel = sd.Ceiling.sector.Brightness;
                    lightlevel = 256;
                }

                //mxd. This calculates light with doom-style wall shading
                PixelColor wallbrightness = PixelColor.FromInt(mode.CalculateBrightness(lightlevel, Sidedef));
				PixelColor wallcolor = PixelColor.Modulate(sd.Ceiling.colorbelow, wallbrightness);
				fogfactor = CalculateFogFactor(lightlevel);

                if (General.Map.PSXDOOM)//[GEC]
                {
                    fogfactor = CalculateFogFactor(256);
                    base.lightmode = 1;
                }

				poly.SetShadingParams(Sidedef.Sector, wallcolor.WithAlpha(255)); // [GEC]

                // Cut out pieces that overlap 3D floors in this sector
                List<WallPolygon> polygons = new List<WallPolygon> { poly };
				ClipExtraFloors(polygons, sd.ExtraFloors, false); //mxd

				if(polygons.Count > 0)
				{
					// Process the polygon and create vertices
					List<WorldVertex> verts = CreatePolygonVertices(polygons, tp, sd, lightvalue, lightabsolute);
					if(verts.Count > 2)
					{
						base.SetVertices(verts);
						return true;
					}
				}
			}
			
			base.SetVertices(null); //mxd
			return false;
		}

		#endregion
		
		#region ================== Methods

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
			Sidedef.Fields["offsetx_mid"] = new UniValue(UniversalType.Float, GetRoundedTextureOffset(oldx, offsetx, scalex, Texture.Width)); //mxd
			Sidedef.Fields["offsety_mid"] = new UniValue(UniversalType.Float, GetRoundedTextureOffset(oldy, offsety, scaley, Texture.Height)); //mxd
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

			// Update linked effects
			SectorData sd = mode.GetSectorDataEx(Sector.Sector);
			if(sd != null) sd.Reset(true);
		}
		
		#endregion
	}
}
