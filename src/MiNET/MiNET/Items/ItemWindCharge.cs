using System;
using System.Collections.Generic;
using MiNET.Entities.Projectiles;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Items
{
	public partial class ItemWindCharge
	{
		private Dictionary<Player, long> playerCooldowns = new Dictionary<Player, long>();
		private const int CooldownTicks = 20;

		public ItemWindCharge() : base()
		{
			MaxStackSize = 64;
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

			var windCharge = new WindCharge(player, world);
			windCharge.KnownPosition = (PlayerLocation) player.KnownPosition.Clone();
			windCharge.KnownPosition.Y += 1.62f;
			windCharge.Velocity = windCharge.KnownPosition.GetDirectionVector().Normalize() * force;
			windCharge.Gravity = 0;
			windCharge.Ttl = 100;
			windCharge.SpawnEntity();
			world.BroadcastSound(player.KnownPosition, LevelSoundEventType.Throw);
			var itemInHand = player.Inventory.GetItemInHand();
			itemInHand.Count--;

			playerCooldowns[player] = currentTick;
		}
	}
}
