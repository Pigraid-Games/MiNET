using System;
using fNbt;

namespace MiNET.Worlds.Anvil.Mapping
{
	public class PropertyValueStateMapper
	{
		public string OldName { get; set; }
		public string NewName { get; set; }

		private readonly Func<string, NbtCompound, string, string> _func;

		public PropertyValueStateMapper(string oldName, string newName)
		{
			OldName = oldName;
			NewName = newName;
		}

		public PropertyValueStateMapper(string oldName, Func<string, NbtCompound, string, string> func)
		{
			OldName = oldName;
			_func = func;
		}

		public string Resolve(string oldName, NbtCompound properties)
		{
			return _func?.Invoke(oldName, properties, OldName) ?? NewName;
		}

		public PropertyValueStateMapper Clone()
		{
			return new PropertyValueStateMapper(
				OldName,
				(Func<string, NbtCompound, string, string>) _func?.Clone())
			{
				NewName = NewName
			};
		}
	}
}
