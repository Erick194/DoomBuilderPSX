
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

#endregion

namespace CodeImp.DoomBuilder.Rendering
{
	public enum RenderPass : int
	{
		Solid = 0,
		Mask = 1,
		Alpha = 2,
		Additive = 3,
        Subtractive = 4 //[GEC]
    }
}

