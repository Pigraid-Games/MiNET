using System.Collections.Generic;

namespace MiNET.Worlds.Anvil.Mapping
{
	public class StateMapper
	{
		private readonly Dictionary<string, BlockStateMapper> _map = new Dictionary<string, BlockStateMapper>();
		private readonly List<BlockStateMapper> _defaultMap = new List<BlockStateMapper>();

		public void Add(BlockStateMapper map)
		{
			Add(map.OldName, map);
		}

		public void Add(string name, BlockStateMapper map)
		{
			_map.Add(name, map);
		}

		public bool TryAdd(BlockStateMapper map)
		{
			return TryAdd(map.OldName, map);
		}

		public bool TryAdd(string name, BlockStateMapper map)
		{
			return _map.TryAdd(name, map);
		}

		public void AddDefault(BlockStateMapper map)
		{
			_defaultMap.Add(map);
		}

		public string Resolve(BlockStateMapperContext context)
		{
			if (_map.TryGetValue(context.OldName, out var map))
			{
				context.OldName = map.Resolve(context);
			}

			foreach (var defMap in _defaultMap)
			{
				defMap.ResolveDefault(context);
			}

			return context.OldName;
		}
	}
}
