using System;
using fNbt;

namespace MiNET.Worlds.Anvil.Mapping
{
	public class AdditionalPropertyStateMapper : IPropertyStateMapper
	{
		public string Name { get; set; }
		public string Value { get; set; }

		private readonly Func<string, NbtCompound, string> _func;

		public AdditionalPropertyStateMapper(string name, string value)
		{
			Name = name;
			Value = value;
		}

		public AdditionalPropertyStateMapper(string name, Func<string, NbtCompound, string> func)
		{
			Name = name;
			_func = func;
		}

		public NbtString Resolve(string oldName, NbtCompound properties)
		{
			return new NbtString(Name, _func?.Invoke(oldName, properties) ?? Value);
		}

		public AdditionalPropertyStateMapper Clone()
		{
			return new AdditionalPropertyStateMapper(
				Name,
				(Func<string, NbtCompound, string>) _func?.Clone())
			{
				Value = Value
			};
		}
	}
}
