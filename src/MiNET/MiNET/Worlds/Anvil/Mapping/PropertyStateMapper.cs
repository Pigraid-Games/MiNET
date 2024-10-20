using System;
using System.Collections.Generic;
using System.Linq;
using fNbt;

namespace MiNET.Worlds.Anvil.Mapping
{
	public class PropertyStateMapper : IPropertyStateMapper
	{
		public string OldName { get; set; }
		public string NewName { get; set; }

		public Dictionary<string, PropertyValueStateMapper> ValuesMap { get; } = new Dictionary<string, PropertyValueStateMapper>();

		private readonly Func<string, NbtCompound, NbtString, NbtString> _func;

		public PropertyStateMapper(params PropertyValueStateMapper[] propertiesNameMap)
			: this(oldName: null, newName: null, propertiesNameMap)
		{

		}

		public PropertyStateMapper(Func<string, NbtCompound, NbtString, NbtString> func)
			: this(oldName: null, func)
		{

		}

		public PropertyStateMapper(string oldName, params PropertyValueStateMapper[] propertiesNameMap)
			: this(oldName, newName: null, propertiesNameMap)
		{

		}

		public PropertyStateMapper(string oldName, string newName, params PropertyValueStateMapper[] propertiesNameMap)
		{
			OldName = oldName;
			NewName = newName;

			foreach (var map in propertiesNameMap)
			{
				ValuesMap.Add(map.OldName, map);
			}
		}

		public PropertyStateMapper(string oldName, Func<string, NbtCompound, NbtString, NbtString> func, params PropertyValueStateMapper[] propertiesNameMap)
		{
			OldName = oldName;
			_func = func;

			foreach (var map in propertiesNameMap)
			{
				ValuesMap.Add(map.OldName, map);
			}
		}

		public NbtString Resolve(string oldName, NbtCompound properties, NbtString property)
		{
			return _func?.Invoke(oldName, properties, property)
				?? new NbtString(NewName ?? property.Name, ValuesMap.GetValueOrDefault(property.StringValue)?.Resolve(oldName, properties) ?? property.StringValue);
		}

		public PropertyStateMapper Clone()
		{
			return new PropertyStateMapper(
				OldName,
				(Func<string, NbtCompound, NbtString, NbtString>) _func?.Clone(),
				ValuesMap.Values.Select(v => v.Clone()).ToArray())
			{
				NewName = NewName
			};
		}
	}
}
