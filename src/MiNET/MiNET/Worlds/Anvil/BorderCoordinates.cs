using System;
using fNbt.Serialization;

namespace MiNET.Worlds.Anvil
{
	[NbtObject]
	public class BorderCoordinates : ICloneable
	{
		[NbtProperty("BorderCenterX")]
		public double X { get; set; }

		[NbtProperty("BorderCenterZ")]
		public double Z { get; set; }

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
