﻿#region LICENSE

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
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2018 Niclas Olofsson. 
// All Rights Reserved.

#endregion

using System.Linq;
using System.Numerics;
using fNbt;
using fNbt.Serialization;
using log4net;
using MiNET.Blocks;
using MiNET.Effects;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.BlockEntities
{
	public class BeaconBlockEntity : BlockEntity
	{
		[NbtProperty("primary")]
		public EffectType Primary { get; set; } = EffectType.Speed;
		[NbtProperty("secondary")]
		public EffectType Secondary { get; set; } = EffectType.Regeneration;

		public BeaconBlockEntity() : base(BlockEntityIds.Beacon)
		{
			UpdatesOnTick = true;
		}

		public override void SetCompound(NbtCompound compound)
		{
			base.SetCompound(compound);
			_nextUpdate = 0;
		}

		private long _nextUpdate;

		public override void OnTick(Level level)
		{
			if (_nextUpdate > level.TickTime) return;

			_nextUpdate = level.TickTime + 80;

			if (!HaveSkyLight(level)) return;

			var pyramidLevels = GetPyramidLevels(level);

			var duration = 180 + pyramidLevels * 40;
			var range = 10 + pyramidLevels * 10;

			var prim = Primary;
			var sec = Secondary;

			var effectPrim = GetEffect(prim);

			if (effectPrim != null && pyramidLevels > 0)
			{
				effectPrim.Level = pyramidLevels == 4 && prim == sec ? 1 : 0;
				effectPrim.Duration = duration;
				effectPrim.Particles = true;

				var players = level.Players.Where(player => player.Value.IsSpawned && Vector3.Distance(Coordinates, player.Value.KnownPosition) <= range);
				foreach (var player in players)
				{
					player.Value.SetEffect(effectPrim, true);

					if (pyramidLevels == 4 && prim != sec)
					{
						var regen = new Regeneration
						{
							Level = 0,
							Duration = duration,
							Particles = true
						};

						player.Value.SetEffect(regen);
					}
				}
			}
		}

		private static readonly ILog Log = LogManager.GetLogger(typeof(BeaconBlockEntity));

		private bool HaveSkyLight(Level level)
		{
			var height = level.GetHeight(Coordinates);

			if (height == Coordinates.Y + 1) return true;

			for (var y = 1; y < height - Coordinates.Y; y++)
			{
				if (level.IsTransparent(Coordinates + (BlockCoordinates.Up * y))) continue;
				if (level.IsBlock<Bedrock>(Coordinates + (BlockCoordinates.Up * y))) continue;

				return false;
			}

			return true;
		}

		private static Effect GetEffect(EffectType prim)
		{
			Effect eff = null;
			switch (prim)
			{
				case EffectType.Speed:
					eff = new Speed();
					break;
				case EffectType.Slowness:
					eff = new Slowness();
					break;
				case EffectType.Haste:
					eff = new Haste();
					break;
				case EffectType.MiningFatigue:
					eff = new MiningFatigue();
					break;
				case EffectType.Strength:
					eff = new Strength();
					break;
				case EffectType.InstantHealth:
					eff = new InstantHealth();
					break;
				case EffectType.InstantDamage:
					eff = new InstantDamage();
					break;
				case EffectType.JumpBoost:
					eff = new JumpBoost();
					break;
				case EffectType.Nausea:
					eff = new Nausea();
					break;
				case EffectType.Regeneration:
					eff = new Regeneration();
					break;
				case EffectType.Resistance:
					eff = new Resistance();
					break;
				case EffectType.FireResistance:
					eff = new FireResistance();
					break;
				case EffectType.WaterBreathing:
					eff = new WaterBreathing();
					break;
				case EffectType.Invisibility:
					eff = new Invisibility();
					break;
				case EffectType.Blindness:
					eff = new Blindness();
					break;
				case EffectType.NightVision:
					eff = new NightVision();
					break;
				case EffectType.Hunger:
					eff = new Hunger();
					break;
				case EffectType.Weakness:
					eff = new Weakness();
					break;
				case EffectType.Poison:
					eff = new Poison();
					break;
				case EffectType.Wither:
					eff = new Wither();
					break;
				case EffectType.HealthBoost:
					eff = new HealthBoost();
					break;
				case EffectType.Absorption:
					eff = new Absorption();
					break;
				case EffectType.Saturation:
					eff = new Saturation();
					break;
			}
			return eff;
		}

		private int GetPyramidLevels(Level level)
		{
			for (var i = 1; i < 5; i++)
			{
				for (var x = -i; x < i + 1; x++)
				{
					for (var z = -i; z < i + 1; z++)
					{
						var block = level.GetBlock(Coordinates + new BlockCoordinates(x, -i, z));
						if (block is GoldBlock || block is IronBlock || block is EmeraldBlock || block is DiamondBlock || block is CopperBlock) continue;

						return i - 1;
					}
				}
			}

			return 4;
		}
	}
}