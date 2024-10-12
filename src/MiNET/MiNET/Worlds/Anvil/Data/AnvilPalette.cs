using System.Collections.Generic;
using fNbt.Serialization;

namespace MiNET.Worlds.Anvil.Data
{
	[NbtObject]
	public class AnvilPalette<T>
	{
		[NbtProperty("data")]
		public long[] Data { get; set; }

		[NbtProperty("palette")]
		public List<T> Palette { get; set; }
	}
}
