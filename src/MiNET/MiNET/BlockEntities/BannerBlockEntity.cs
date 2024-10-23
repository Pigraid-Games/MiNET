#region LICENSE

// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE. 
// The License is based on the Mozilla Public License Version 1.1, but Sections 14 
// and 15 have been added to cover use of software over a computer network and 
// provide for limited attribution for the Original Developer. In addition, Exhibit A has 
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2018 Niclas Olofsson. 
// All Rights Reserved.

#endregion

using System.Collections.Generic;
using fNbt.Serialization;

namespace MiNET.BlockEntities
{
	public class BannerBlockEntity : BlockEntity
	{
		/// <summary>
		/// The type of the block entity. 0 is normal banner. 1 is ominous banner.
		/// </summary>
		public int Type { get; set; }

		[NbtProperty("Base")]
		public int BaseColor { get; set; }

		public List<BannerPattern> Patterns { get; set; } = new List<BannerPattern>();

		public BannerBlockEntity() : base(BlockEntityIds.Banner)
		{
		}
	}

	[NbtObject]
	public class BannerPattern
	{
		public string Pattern { get; set; }
		public int Color { get; set; }
	}

	public static class BannerPatterns
	{
		public const string Base = "b";

		public const string StripeBottom = "bs";
		public const string StripeTop = "ts";
		public const string StripeLeft = "ls";
		public const string StripeRight = "rs";
		public const string StripeCenter = "cs";
		public const string StripeMiddle = "ms";
		public const string StripeDownRight = "drs";
		public const string StripeDownLeft = "dls";

		public const string SmallStripes = "ss";

		public const string Cross = "cr";
		public const string StraightCross = "sc";

		public const string DiagonalLeft = "ld";
		public const string DiagonalRight = "rud";
		public const string DiagonalUpLeft = "lud";
		public const string DiagonalUpRight = "rd";

		public const string VerticalHalfLeft = "vh";
		public const string VerticalHalfRight = "vhr";
		public const string HorizontalHalfTop = "hh";
		public const string HorizontalHalfBottom = "hhb";

		public const string CornerBottomLeft = "bl";
		public const string CornerBottomRight = "br";
		public const string CornerTopLeft = "tl";
		public const string CornerTopRight = "tr";

		public const string TriangleBottom = "bt";
		public const string TriangleTop = "tt";

		public const string TrianglesBottom = "bts";
		public const string TrianglesTop = "tts";

		public const string Circle = "mc";
		public const string Rhombus = "mr";
		public const string Border = "bo";
		public const string CurlyBorder = "cbo";
		public const string Bricks = "bri";

		public const string GradientDown = "gra";
		public const string GradientUp = "gru";

		public const string Creeper = "cre";
		public const string Skull = "sku";
		public const string Flower = "flo";
		public const string Mojang = "moj";
		public const string Globe = "glb";
		public const string Piglin = "big";
		public const string Flow = "flw";
		public const string Guster = "gus";
	}
}