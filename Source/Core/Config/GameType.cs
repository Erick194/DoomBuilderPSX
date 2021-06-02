using System.Collections.Generic;

namespace CodeImp.DoomBuilder.Config 
{
	public struct GameType
	{
		public const string UNKNOWN = "UNKNOWN_GAME";
		public const string DOOM = "doom";
		public const string HERETIC = "heretic";
		public const string HEXEN = "hexen";
		public const string STRIFE = "strife";
		public const string CHEX = "chex";
        public const string PSXDOOM = "psxdoom";//[GEC]

        public static readonly HashSet<string> GameTypes = new HashSet<string> { DOOM, HERETIC, HEXEN, STRIFE, CHEX, PSXDOOM };
		public static readonly Dictionary<string, string> GldefsLumpsPerGame = new Dictionary<string, string>
		{
			{ DOOM, "DOOMDEFS" },
			{ HERETIC, "HTICDEFS" },
			{ HEXEN, "HEXNDEFS" },
			{ STRIFE, "STRFDEFS" },
			{ CHEX, "DOOMDEFS" }, // Is that so?..
            { PSXDOOM, "DOOMDEFS" },
        };
	}
}
