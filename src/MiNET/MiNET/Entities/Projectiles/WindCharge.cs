using System;
using System.Collections.Generic;
using System.Numerics;
using MiNET.Particles;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Entities.Projectiles
{
	public class WindCharge : Projectile
	{

		public WindCharge(Player shooter, Level level) : base(shooter, EntityType.ThrownWindCharge, level, 0)
		{
			Width = 0.25;
			Length = 0.25;
			Height = 0.25;

			Gravity = 0.03;
			Drag = 0.01;

			HealthManager.IsInvulnerable = true;
			DespawnOnImpact = true;
			BroadcastMovement = true;
		}

		public override void DespawnEntity()
		{
			// Spawn particle
			var windChargeparticle = new LegacyParticle(ParticleType.WindExplosion, Level)
			{
				Position = KnownPosition
			};
			windChargeparticle.Spawn();

			// Spawn sound
			Level.BroadcastSound(KnownPosition, LevelSoundEventType.WindChargeBurst, 0);

			// Process the knockback for players
			float minX = KnownPosition.X - 2;
			float maxX = KnownPosition.X + 2;
			float minY = KnownPosition.Y - 2;
			float maxY = KnownPosition.Y + 2;
			float minZ = KnownPosition.Z - 2;
			float maxZ = KnownPosition.Z + 2;

			foreach (Player player in Level.Players.Values)
			{
				var playerPos = player.KnownPosition;

				if (playerPos.X >= minX && playerPos.X <= maxX &&
					playerPos.Y >= minY && playerPos.Y <= maxY &&
					playerPos.Z >= minZ && playerPos.Z <= maxZ)
				{
					// Calculate knockback direction (vector from the center of the area)
					Vector3 direction = (playerPos - new Vector3(KnownPosition.X, KnownPosition.Y, KnownPosition.Z)).Normalize();
					
					Vector3 knockbackForce = direction;
					
					player.Knockback(knockbackForce);
				}
			}
			base.DespawnEntity();
		}
	}
}
