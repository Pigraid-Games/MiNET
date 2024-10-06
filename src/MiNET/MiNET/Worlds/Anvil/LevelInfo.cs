#region LICENSE

// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE.
// The License is based on the Mozilla Public License Version 1.1, but Sections 14
// and 15 have been added to cover use of software over a computer network and
// provide for limited attribution for the Original Developer. In addition, Exhibit A has
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2019 Niclas Olofsson.
// All Rights Reserved.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using fNbt.Serialization;
using fNbt.Serialization.NamingStrategy;
using MiNET.Utils.Vectors;

namespace MiNET.Worlds.Anvil
{
	[NbtObject]
	public class LevelInfo : ICloneable
	{
		[NbtProperty("version")]
		public int NbtVersion { get; set; }

		public int DataVersion { get; set; }

		public VersionInfo Version { get; set; }

		public bool WasModded { get; set; }

		public string LevelName { get; set; }


		[NbtFlatProperty(typeof(SpawnNamingStrategy))]
		public BlockCoordinates Spawn { get; set; }
		public float SpawnAngle { get; set; }


		public long Time { get; set; }
		public long DayTime { get; set; }
		public Difficulty Difficulty { get; set; }
		public bool DifficultyLocked { get; set; }
		public long LastPlayed { get; set; }
		public bool MapFeatures { get; set; }


		[NbtProperty("allowCommands")]
		public bool AllowCommands { get; set; }
		public Dictionary<string, string> GameRules { get; set; }
		public int GameType { get; set; }


		[NbtProperty("hardcore")]
		public bool Hardcore { get; set; }

		[NbtFlatProperty]
		public BorderInfo BorderInfo { get; set; }

		#region Generation

		[NbtProperty("WorldGenSettings")]
		public WorldGenerationSettings GenerationSettings { get; set; }

		[NbtProperty("generatorName")]
		public string GeneratorName { get; set; }

		[NbtProperty("generatorOptions")]
		public string GeneratorOptions { get; set; }

		[NbtProperty("generatorVersion")]
		public int GeneratorVersion { get; set; }

		[NbtProperty("initialized")]
		public bool Initialized { get; set; }

		#endregion

		#region Weather

		[NbtProperty("clearWeatherTime")]
		public int ClearWeatherTime { get; set; }

		[NbtProperty("raining")]
		public bool Raining { get; set; }

		[NbtProperty("rainTime")]
		public int RainTime { get; set; }

		[NbtProperty("thundering")]
		public bool Thundering { get; set; }

		[NbtProperty("thunderTime")]
		public int ThunderTime { get; set; }

		#endregion

		// DataPacks

		// DimensionData

		// Player

		// WanderingTrader info

		public object Clone()
		{
			var clone = (LevelInfo) MemberwiseClone();
			clone.Version = (VersionInfo) Version.Clone();
			clone.GameRules = GameRules.ToDictionary();
			clone.BorderInfo = (BorderInfo) BorderInfo.Clone();
			clone.GenerationSettings = (WorldGenerationSettings) GenerationSettings.Clone();

			return clone;
		}

		private class SpawnNamingStrategy : NbtNamingStrategy
		{
			public override string ResolveMemberName(string name)
			{
				return $"Spawn{name}";
			}
		}
	}
}