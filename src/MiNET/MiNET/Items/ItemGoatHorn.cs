using System;
using System.Collections.Generic;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Items
{
	public partial class ItemGoatHorn
	{
		private Dictionary<Player, long> playerCooldowns = new Dictionary<Player, long>();
		private const int CooldownTicks = 120;

		public ItemGoatHorn() : base()
		{
			MaxStackSize = 1;
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

			switch (Metadata)
			{
				case 0: // Ponder
					world.BroadcastSound(player.KnownPosition, LevelSoundEventType.GoatCall0);
					break;
				case 1: // Sing
					world.BroadcastSound(player.KnownPosition, LevelSoundEventType.GoatCall1);
					break;
				case 2: // Seek
					world.BroadcastSound(player.KnownPosition, LevelSoundEventType.GoatCall2);
					break;
				case 3: // Feel
					world.BroadcastSound(player.KnownPosition, LevelSoundEventType.GoatCall3);
					break;
				case 4: // Admire
					world.BroadcastSound(player.KnownPosition, LevelSoundEventType.GoatCall4);
					break;
				case 5: // Call
					world.BroadcastSound(player.KnownPosition, LevelSoundEventType.GoatCall5);
					break;
				case 6: // Yearn
					world.BroadcastSound(player.KnownPosition, LevelSoundEventType.GoatCall6);
					break;
				case 7: // Dream
					world.BroadcastSound(player.KnownPosition, LevelSoundEventType.GoatCall7);
					break;
				default:
					// unknown horn
					break;
			}
			playerCooldowns[player] = currentTick;
		}
	}
}
