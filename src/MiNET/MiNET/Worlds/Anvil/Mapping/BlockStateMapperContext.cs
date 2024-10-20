using fNbt;
using MiNET.BlockEntities;

namespace MiNET.Worlds.Anvil.Mapping
{
	public class BlockStateMapperContext
	{
		public string OldName { get; set; }
		public string NewName { get; set; }
		public NbtCompound Properties { get; set; }
		public BlockEntity BlockEntityTemplate { get; set; }

		public BlockStateMapperContext(string oldName, NbtCompound properties)
		{
			OldName = oldName;
			Properties = properties;
		}
	}
}
