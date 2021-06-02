
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
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Rendering;

#endregion

namespace CodeImp.DoomBuilder.BuilderModes
{
	public class ResultTextureStretched : ErrorResult
	{
		#region ================== Variables

		private readonly Sidedef side;
		private readonly SidedefPart part;
        private readonly int mode;
        private static string[] modestr = {" ", "inverted", "stretched", "inverted and stretched" };

        #endregion

        #region ================== Properties

        //public override int Buttons { get { return 2; } }
        //public override string Button1Text { get { return "Add Default Texture"; } }
        //public override string Button2Text { get { return "Browse Texture..."; } } //mxd

        #endregion

        #region ================== Constructor / Destructor

        // Constructor
        public ResultTextureStretched(Sidedef sd, SidedefPart part, int mode)
		{
			// Initialize
			this.side = sd;
			this.part = part;
            this.mode = mode;
            this.viewobjects.Add(sd);
			this.hidden = sd.IgnoredErrorChecks.Contains(this.GetType());
            this.description = "Find textures inverted and stretched";
        }

        #endregion

        #region ================== Methods

        // This sets if this result is displayed in ErrorCheckForm (mxd)
        internal override void Hide(bool hide) 
		{
			hidden = hide;
			Type t = this.GetType();
			if(hide) side.IgnoredErrorChecks.Add(t);
			else if(side.IgnoredErrorChecks.Contains(t)) side.IgnoredErrorChecks.Remove(t);
		}

		// This must return the string that is displayed in the listbox
		public override string ToString()
		{
			string sidestr = side.IsFront ? "front" : "back";

            switch (part)
			{
				case SidedefPart.Upper:
                    return "Linedef " + side.Line.Index + " has " + modestr[mode] + " the upper texture (" + sidestr + " side)";

                case SidedefPart.Middle:
                    return "Linedef " + side.Line.Index + " has " + modestr[mode] + " the middle texture (" + sidestr + " side)";

                case SidedefPart.Lower:
                    return "Linedef " + side.Line.Index + " has " + modestr[mode] + " the lower texture (" + sidestr + " side)";

                default:
					return "ERROR";
			}
		}

		// Rendering
		public override void PlotSelection(IRenderer2D renderer)
		{
			renderer.PlotLinedef(side.Line, General.Colors.Selection);
			renderer.PlotVertex(side.Line.Start, ColorCollection.VERTICES);
			renderer.PlotVertex(side.Line.End, ColorCollection.VERTICES);
		}

		#endregion
	}

    public class ResultTextureAnim : ErrorResult
    {
        #region ================== Variables

        private readonly Sidedef side;
        private readonly SidedefPart part;
        private readonly bool missing;

        #endregion

        #region ================== Properties

        public override int Buttons { get { return 1; } }
        public override string Button1Text { get { return "Set First Animation"; } }

        #endregion

        #region ================== Constructor / Destructor

        // Constructor
        public ResultTextureAnim(Sidedef sd, SidedefPart part, bool missing)
        {
            // Initialize
            this.side = sd;
            this.part = part;
            this.missing = missing;
            this.viewobjects.Add(sd);
            this.hidden = sd.IgnoredErrorChecks.Contains(this.GetType());
            this.description = "Find incorrect animated textures";
        }

        #endregion

        #region ================== Methods

        // This sets if this result is displayed in ErrorCheckForm (mxd)
        internal override void Hide(bool hide)
        {
            hidden = hide;
            Type t = this.GetType();
            if (hide) side.IgnoredErrorChecks.Add(t);
            else if (side.IgnoredErrorChecks.Contains(t)) side.IgnoredErrorChecks.Remove(t);
        }

        // This must return the string that is displayed in the listbox
        public override string ToString()
        {
            string sidestr = side.IsFront ? "front" : "back";


            switch (part)
            {
                case SidedefPart.Upper:
                    return "Linedef " + side.Line.Index + " has incorrect animation in upper texture \"" + side.HighTexture + "\" (" + sidestr + " side)";

                case SidedefPart.Middle:
                    if (missing) { return "Linedef " + side.Line.Index + " has missing middle texture (" + sidestr + " side)"; }
                    else { return "Linedef " + side.Line.Index + " has incorrect animation in middle texture \"" + side.MiddleTexture + "\" (" + sidestr + " side)"; }

                case SidedefPart.Lower:
                    return "Linedef " + side.Line.Index + " has incorrect animation in lower texture \"" + side.LowTexture + "\" (" + sidestr + " side)";

                default:
                    return "ERROR";
            }
        }

        // Rendering
        public override void PlotSelection(IRenderer2D renderer)
        {
            renderer.PlotLinedef(side.Line, General.Colors.Selection);
            renderer.PlotVertex(side.Line.Start, ColorCollection.VERTICES);
            renderer.PlotVertex(side.Line.End, ColorCollection.VERTICES);
        }

        // Fix by setting default texture animation
        public override bool Button1Click(bool batchMode)
        {
            string str;
            if (!batchMode) General.Map.UndoRedo.CreateUndo("Return last texture");
            General.Settings.FindDefaultDrawSettings();
            switch (part)
            {
                case SidedefPart.Upper:
                    str = side.HighTexture;
                    str = str.Remove(str.Length - 1);
                    side.SetTextureHigh(str + "1");
                    break;
                case SidedefPart.Middle:
                    str = side.MiddleTexture;
                    str = str.Remove(str.Length - 1);
                    side.SetTextureMid(str + "1");
                    break;
                case SidedefPart.Lower:
                    str = side.LowTexture;
                    str = str.Remove(str.Length - 1);
                    side.SetTextureLow(str + "1");
                    break;
            }

            General.Map.Map.Update();
            return true;
        }
        #endregion
    }

    public class ResultFlatAnim : ErrorResult
    {
        #region ================== Variables

        private readonly Sector sector;
        private readonly bool ceiling;

        #endregion

        #region ================== Properties

        public override int Buttons { get { return 1; } }
        public override string Button1Text { get { return "Set First Animation"; } }

        #endregion

        #region ================== Constructor / Destructor

        // Constructor
        public ResultFlatAnim(Sector s, bool ceiling)
        {
            // Initialize
            this.sector = s;
            this.ceiling = ceiling;
            this.viewobjects.Add(s);
            this.hidden = s.IgnoredErrorChecks.Contains(this.GetType()); //mxd

            this.description = "Find incorrect animated flats";
        }

        #endregion

        #region ================== Methods

        // This sets if this result is displayed in ErrorCheckForm (mxd)
        internal override void Hide(bool hide)
        {
            hidden = hide;
            Type t = this.GetType();
            if (hide) sector.IgnoredErrorChecks.Add(t);
            else if (sector.IgnoredErrorChecks.Contains(t)) sector.IgnoredErrorChecks.Remove(t);
        }

        // This must return the string that is displayed in the listbox
        public override string ToString()
        {
            if (ceiling)
                return "Sector " + sector.Index + " has incorrect animation in ceiling flat \"" + sector.CeilTexture + "\"";
            else
                return "Sector " + sector.Index + " has incorrect animation in floor flat \"" + sector.FloorTexture + "\"";
        }

        // Rendering
        public override void PlotSelection(IRenderer2D renderer)
        {
            renderer.PlotSector(sector, General.Colors.Selection);
        }

        //mxd. More rendering
        public override void RenderOverlaySelection(IRenderer2D renderer)
        {
            if (!General.Settings.UseHighlight) return;
            renderer.RenderHighlight(sector.FlatVertices, General.Colors.Selection.WithAlpha(64).ToInt());
        }

        // Fix by setting default flat
        public override bool Button1Click(bool batchMode)
        {
            string str;
            if (!batchMode) General.Map.UndoRedo.CreateUndo("Return last flat");
            General.Settings.FindDefaultDrawSettings();

            if (ceiling)
            {
                str = sector.CeilTexture;
                str = str.Remove(str.Length - 1);
                sector.SetCeilTexture(str + "1");
            }
            else
            {
                str = sector.FloorTexture;
                str = str.Remove(str.Length - 1);
                sector.SetFloorTexture(str + "1");
            }

            General.Map.Map.Update();
            General.Map.Data.UpdateUsedTextures();
            return true;
        }
        #endregion
    }
}
