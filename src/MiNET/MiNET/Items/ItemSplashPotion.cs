using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET.Entities;
using MiNET.Entities.Projectiles;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Items
{
	public partial class ItemSplashPotion
	{
		public ItemSplashPotion()
		{
			MaxStackSize = 1;
		}

		public override void UseItem(Level world, Player player, BlockCoordinates blockCoordinates)
		{
			float force = 1.5f;

			var splashPotion = new SplashPotion(player, world, (PotionType.PotionTypeEnum) Metadata)
			{
				KnownPosition = (PlayerLocation) player.KnownPosition.Clone()
			};
			splashPotion.KnownPosition.Y += 1.62f;
			splashPotion.Velocity = splashPotion.KnownPosition.GetDirectionVector().Normalize() * force;
			splashPotion.SpawnEntity();
		}
	}
}
