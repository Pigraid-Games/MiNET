using System.Collections.Generic;
using fNbt;
using fNbt.Serialization;
using fNbt.Serialization.NamingStrategy;
using MiNET.Utils.Vectors;

namespace MiNET.Worlds.Anvil.Data
{
	[NbtObject]
	public class RegionChunk
	{
		public int DataVersion { get; set; }

		public long InhabitedTime { get; set; }

		public long LastUpdate { get; set; }

		public string Status { get; set; }

		[NbtProperty("isLightOn")]
		public bool IsLightOn { get; set; }

		[NbtFlatProperty(typeof(CoordinatesStrategy))]
		public ChunkCoordinates Coordinates { get; set; }

		[NbtProperty("yPos")]
		public int YPosition { get; set; }

		[NbtProperty("blending_data")]
		public BlendingData BlendingData { get; set; }

		[NbtProperty("Heightmaps")]
		public HeightMaps HeightMaps { get; set; }

		// TODO
		//public NbtList PostProcessing { get; set; }

		// TODO
		//[NbtProperty("block_ticks")]
		//public NbtList BlockTicks { get; set; }

		// TODO
		//[NbtProperty("fluid_ticks")]
		//public NbtList FluidTicks { get; set; }

		// TODO
		//[NbtProperty("structures")]
		//public NbtCompound Structures { get; set; }

		[NbtProperty("block_entities")]
		public List<NbtCompound> BlockEntities { get; set; }

		[NbtProperty("sections")]
		public List<RegionChunkSection> Sections { get; set; }

		public void PopulateChunk(ChunkColumn chunk)
		{
			HeightMaps?.PopulateChunk(chunk);

			foreach (var section in Sections)
			{
				section.PopulateChunk(chunk);
			}
		}

		private class CoordinatesStrategy : NbtNamingStrategy
		{
			public override string ResolveMemberName(string name)
			{
				return $"{name.ToLower()}Pos";
			}
		}
	}
}
