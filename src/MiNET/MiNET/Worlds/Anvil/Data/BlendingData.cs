using fNbt.Serialization;

namespace MiNET.Worlds.Anvil.Data
{
	[NbtObject]
	public class BlendingData
	{
		[NbtProperty("max_section")]
		public int MaxSection { get; set; }

		[NbtProperty("min_section")]
		public int MinSection { get; set; }
	}
}
