#region === Copyright (c) 2010 Pascal van der Heiden ===

using System.Collections.Generic;
using CodeImp.DoomBuilder.Geometry;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Rendering;

#endregion

namespace CodeImp.DoomBuilder.BuilderModes
{
	internal class WallPolygon : List<Vector3D>
	{
		// [GEC] DC: the lower and upper colors for the wall polygon and the z values at which does colors are applied.
		// These values are used to compute the color for a vertex depending on it's height with two colored lighting.
		public PixelColor lowerColor;
		public PixelColor upperColor;
		public float lowerColorZ;
		public float upperColorZ;
		
		// Constructors
		public WallPolygon() { }
		public WallPolygon(int capacity) : base(capacity) { }
		
		// This copies all the wall properties
		public void CopyProperties(WallPolygon target)
		{
			target.lowerColor = this.lowerColor; // [GEC]
			target.upperColor = this.upperColor;
			target.lowerColorZ = this.lowerColorZ;
			target.upperColorZ = this.upperColorZ;
		}

		// [GEC] DC: figure out the lower and upper wall colors and the Z values at which they apply.
		// Use an input sector and base color to decide.
		public void SetupDualColoredLighting(Sector sector, PixelColor baseColor)
		{
			lowerColorZ = sector.FloorHeight;
			upperColorZ = sector.CeilHeight;

			// Note: if the upper color is undefined, use the lower color as the upper color
			int upperColorIdx = (sector.IdxColorCeil != 0) ? sector.IdxColorCeil : sector.IdxColor;
			lowerColor = PixelColor.Modulate(baseColor, Lights.GetColor(sector.IdxColor)).WithAlpha(255);
			upperColor = PixelColor.Modulate(baseColor, Lights.GetColor(upperColorIdx)).WithAlpha(255);
		}

		// [GEC] DC: dual color calculation.
		// Gets the color to use for the given Z (height) value given the specified dual color lighting params.
		public static PixelColor GetColorForZ(
			float z,
			PixelColor lowerColor,
			PixelColor upperColor,
			float lowerColorZ,
			float upperColorZ
		)
		{
			// Same color? If so then don't do any interpolation:
			if (lowerColor.Equals(upperColor))
				return lowerColor;

			// If there is zero or invalid sized z range then just return the floor color
			float zRange = upperColorZ - lowerColorZ;

			if (zRange <= 0.0f)
				return lowerColor;

			// Interpolate between the two colors based on z
			float t = (z - lowerColorZ) / zRange;
			return PixelColor.Lerp(lowerColor, upperColor, t);
		}

		public static PixelColor GetColorForZ(float z, WallPolygon poly)
        {
			return GetColorForZ(z, poly.lowerColor, poly.upperColor, poly.lowerColorZ, poly.upperColorZ);
        }
	}
}
