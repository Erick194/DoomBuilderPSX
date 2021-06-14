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
		public Lights.ShadingParams shadeParams; // [GEC]
		
		// Constructors
		public WallPolygon() { }
		public WallPolygon(int capacity) : base(capacity) { }
		
		// This copies all the wall properties
		public void CopyProperties(WallPolygon target)
		{
			target.shadeParams = this.shadeParams; // [GEC]
		}

		 // [GEC]
		public void SetShadingParams(Sector sector, PixelColor baseColor)
		{
			Lights.ComputeShadingParams(sector, baseColor, out shadeParams);
		}

		// [GEC]
		public PixelColor GetColorForZ(float z)
		{
			return Lights.GetColorForZ(z, shadeParams);
		}
	}
}
