using System;
using System.Collections.Generic;
using System.Linq;
using fNbt;

namespace MiNET.Worlds.Anvil.Mapping
{
	public class BlockStateMapper
	{
		public string OldName { get; set; }
		public string NewName { get; set; }

		public Dictionary<string, PropertyStateMapper> PropertiesMap { get; } = new Dictionary<string, PropertyStateMapper>();
		public List<AdditionalPropertyStateMapper> AdditionalProperties { get; } = new List<AdditionalPropertyStateMapper>();
		public Dictionary<string, SkipPropertyStateMapper> SkipProperties { get; } = new Dictionary<string, SkipPropertyStateMapper>();

		private readonly Func<BlockStateMapperContext, string> _func;

		public BlockStateMapper(Func<BlockStateMapperContext, string> func)
		{
			_func = func;
		}

		public BlockStateMapper(Action<BlockStateMapperContext> func, params IPropertyStateMapper[] propertiesMap)
			: this(null, null, func, propertiesMap)
		{

		}

		public BlockStateMapper(Func<BlockStateMapperContext, string> func, params IPropertyStateMapper[] propertiesMap)
			: this(null, null, func, propertiesMap)
		{

		}

		public BlockStateMapper(string oldName, Action<BlockStateMapperContext> func)
			: this(oldName, oldName, func)
		{

		}

		public BlockStateMapper(string oldName, Func<BlockStateMapperContext, string> func)
			: this(oldName, oldName, func)
		{

		}

		public BlockStateMapper(string oldName, Action<BlockStateMapperContext> func, params IPropertyStateMapper[] propertiesMap)
			: this(oldName, oldName, func, propertiesMap)
		{

		}

		public BlockStateMapper(string oldName, Func<BlockStateMapperContext, string> func, params IPropertyStateMapper[] propertiesMap)
			: this(oldName, oldName, func, propertiesMap)
		{

		}

		public BlockStateMapper(params IPropertyStateMapper[] propertiesMap)
			: this(oldName: null, propertiesMap)
		{

		}

		public BlockStateMapper(string oldName, params IPropertyStateMapper[] propertiesMap)
			: this(oldName, oldName, null, propertiesMap)
		{

		}

		public BlockStateMapper(string oldName, string newName, params IPropertyStateMapper[] propertiesMap)
			: this(oldName, newName, null, propertiesMap)
		{

		}

		public BlockStateMapper(string oldName, string newName, Action<BlockStateMapperContext> func, params IPropertyStateMapper[] propertiesMap)
			: this(oldName, newName, context =>
			{
				func(context);
				return context.OldName;
			}, propertiesMap)
		{
		}

		public BlockStateMapper(string oldName, string newName, Func<BlockStateMapperContext, string> func, params IPropertyStateMapper[] propertiesMap)
		{
			OldName = oldName;
			NewName = newName;

			_func = func;

			foreach (var map in propertiesMap)
			{
				if (map is PropertyStateMapper propertyStateMapper)
				{
					PropertiesMap.Add(propertyStateMapper.OldName ?? propertyStateMapper.GetHashCode().ToString(), propertyStateMapper);
				}
				else if (map is AdditionalPropertyStateMapper additionalPropertyStateMapper)
				{
					AdditionalProperties.Add(additionalPropertyStateMapper);
				}
				else if (map is SkipPropertyStateMapper skipPropertyStateMapper)
				{
					SkipProperties.Add(skipPropertyStateMapper.Name ?? skipPropertyStateMapper.GetHashCode().ToString(), skipPropertyStateMapper);
				}
			}
		}

		public string Resolve(BlockStateMapperContext context)
		{
			if (_func != null) context.OldName = _func(context);

			foreach (NbtString prop in context.Properties.ToArray())
			{
				if (SkipProperties.TryGetValue(prop.Name, out var skipMap) && skipMap.Resolve(context.OldName, context.Properties, prop))
				{
					context.Properties.Remove(prop.Name);
				}
				else if (PropertiesMap.TryGetValue(prop.Name, out var propMap))
				{
					context.Properties.Remove(prop.Name);
					context.Properties.Add(propMap.Resolve(context.OldName, context.Properties, prop));
				}
			}

			foreach (var prop in AdditionalProperties)
			{
				context.Properties[prop.Name] = prop.Resolve(context.OldName, context.Properties);
			}

			return NewName ?? context.OldName;
		}

		public string ResolveDefault(BlockStateMapperContext context)
		{
			if (_func != null) return _func(context);

			foreach (NbtString prop in context.Properties.ToArray())
			{
				var skipMap = SkipProperties.Values.FirstOrDefault(map => map.Name == prop.Name || map.Name == null);
				if (skipMap != null && skipMap.Resolve(context.OldName, context.Properties, prop))
				{
					context.Properties.Remove(prop.Name);
				}
				else
				{
					var propMap = PropertiesMap.Values.FirstOrDefault(map => map.OldName == prop.Name || map.OldName == null);

					if (propMap != null)
					{
						context.Properties.Remove(prop.Name);
						context.Properties.Add(propMap.Resolve(context.OldName, context.Properties, prop));
					}
				}
			}

			foreach (var prop in AdditionalProperties)
			{
				context.Properties[prop.Name] = prop.Resolve(context.OldName, context.Properties);
			}

			return NewName ?? context.OldName;
		}

		public BlockStateMapper Clone()
		{
			var propertiesMap = new List<IPropertyStateMapper>();

			foreach (var property in PropertiesMap.Values)
			{
				propertiesMap.Add(property.Clone());
			}

			foreach (var property in AdditionalProperties)
			{
				propertiesMap.Add(property.Clone());
			}

			foreach (var property in SkipProperties.Values)
			{
				propertiesMap.Add(property.Clone());
			}

			return new BlockStateMapper(OldName, NewName, (Func<BlockStateMapperContext, string>) _func?.Clone(), propertiesMap.ToArray());
		}
	}
}
