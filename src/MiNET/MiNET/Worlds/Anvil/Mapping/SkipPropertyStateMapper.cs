using System;
using fNbt;

namespace MiNET.Worlds.Anvil.Mapping
{
	public class SkipPropertyStateMapper : IPropertyStateMapper
	{
		public string Name { get; set; }

		private readonly Func<string, NbtCompound, NbtString, bool> _func;

		public SkipPropertyStateMapper(string name)
		{
			Name = name;
		}

		public SkipPropertyStateMapper(string name, Func<string, NbtCompound, NbtString, bool> func)
		{
			Name = name;
			_func = func;
		}

		public bool Resolve(string oldName, NbtCompound properties, NbtString value)
		{
			return _func?.Invoke(oldName, properties, value) ?? true;
		}

		public SkipPropertyStateMapper Clone()
		{
			return new SkipPropertyStateMapper(Name, (Func<string, NbtCompound, NbtString, bool>) _func?.Clone());
		}
	}
}
