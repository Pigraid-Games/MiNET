using MiNET.Utils.Vectors;
using System.Collections.Generic;
using System;
using MiNET.Worlds;
using MiNET.Entities.Projectiles;
using fNbt;
using fNbt.Serialization;

namespace MiNET.Items
{
	public partial class ItemCrossbow
	{
		// Track the player's reload state: true if reloading, false otherwise
		private Dictionary<Player, bool> playerReloads = new Dictionary<Player, bool>();

		// Track if the crossbow is fully charged for the player
		private Dictionary<Player, bool> playerCharged = new Dictionary<Player, bool>();

		public ItemCrossbow() : base()
		{
			MaxStackSize = 1; // Crossbow can only be stacked once
		}

		// Handle when the player starts using the crossbow (e.g. reloading or shooting)
		public override void UseItem(Level world, Player player, BlockCoordinates blockCoordinates)
		{
			// Check if the player has already fully charged the crossbow
			if (playerCharged.ContainsKey(player) && playerCharged[player])
			{
				// The player is fully charged and is now shooting
				playerCharged.Remove(player);  // Remove charged state
				playerReloads.Remove(player);  // Remove reload state

				float force = 1.5f;
				var arrow = new Arrow(player, world, 6);
				arrow.KnownPosition = (PlayerLocation) player.KnownPosition.Clone();
				arrow.KnownPosition.Y += 1.62f;
				arrow.Velocity = arrow.KnownPosition.GetDirectionVector().Normalize() * force * 3;
				arrow.BroadcastMovement = true;
				arrow.DespawnOnImpact = false;
				
				arrow.SpawnEntity();
				player.Inventory.DamageItemInHand(ItemDamageReason.ItemUse, player, null);
				world.BroadcastSound(player.KnownPosition, LevelSoundEventType.CrossbowShoot);
				return;
			}
			else if (playerReloads.ContainsKey(player) && playerReloads[player])
			{
				// The player has finished reloading and now the crossbow is fully charged
				playerCharged[player] = true;
				world.BroadcastSound(player.KnownPosition, LevelSoundEventType.CrossbowLoadingEnd);
				return;
			}
			else
			{
				// Player is starting to reload the crossbow
				playerReloads[player] = true;
				world.BroadcastSound(player.KnownPosition, LevelSoundEventType.CrossbowLoadingStart);
			}
		}
		
		public override void Release(Level world, Player player, BlockCoordinates blockCoordinates)
		{
			if (playerReloads.ContainsKey(player) && playerReloads[player] && !playerCharged.ContainsKey(player))
			{
				// Player released before fully charging, cancel the reload
				playerReloads.Remove(player);
				world.BroadcastSound(player.KnownPosition, LevelSoundEventType.CrossbowLoadingMiddle);
			}
		}
	}
}
