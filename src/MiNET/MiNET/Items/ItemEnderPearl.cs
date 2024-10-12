using System;
using System.Collections.Generic;
using MiNET.Entities.Projectiles;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Items
{
	public partial class ItemEnderPearl
	{
		private Dictionary<Player, long> playerCooldowns = new Dictionary<Player, long>();
		private const int CooldownTicks = 20;

		public ItemEnderPearl()
		{
			MaxStackSize = 16;
		}

		public override void UseItem(Level world, Player player, BlockCoordinates blockCoordinates)
		{
			long currentTick = world.TickTime;
			if (playerCooldowns.ContainsKey(player))
			{
				long lastUsedTick = playerCooldowns[player];
				if (currentTick - lastUsedTick < CooldownTicks)
				{
					return;
				}
			}

			float force = 1.5f;

			var enderPearl = new EnderPearl(player, world);
			enderPearl.KnownPosition = (PlayerLocation) player.KnownPosition.Clone();
			enderPearl.KnownPosition.Y += 1.62f;
			enderPearl.Velocity = enderPearl.KnownPosition.GetDirectionVector().Normalize() * force;
			enderPearl.SpawnEntity();

			playerCooldowns[player] = currentTick;
		}
	}
}
