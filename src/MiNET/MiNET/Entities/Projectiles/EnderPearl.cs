using MiNET.Blocks;
using MiNET.Sounds;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Entities.Projectiles
{
	public class EnderPearl : Projectile
	{
		public EnderPearl(Player shooter, Level level) : base(shooter, EntityType.ThrownEnderPerl, level, 0, false)
		{
			Width = 0.25;
			Length = 0.25;
			Height = 0.25;

			Gravity = 0.03;
			Drag = 0.01;

			HealthManager.IsInvulnerable = true;
			Ttl = 1200;
			BroadcastMovement = true;
			DespawnOnImpact = true;
		}

		protected override void OnHitBlock(Block blockCollided)
		{
			BlockCoordinates position = blockCollided.Coordinates;
			var location = new PlayerLocation(position.X, position.Y + 1, position.Z);
			TeleportEntity(location);
		}

		protected override void OnHitEntity(Entity entityCollided)
		{
			TeleportEntity(entityCollided.KnownPosition);
			base.OnHitEntity(entityCollided);
		}

		private void TeleportEntity(PlayerLocation position, Entity entityCollided = null)
		{
			Shooter.Teleport(position);

			var sound = new Sound((short) LevelEventType.SoundEndermanTeleport, Shooter.KnownPosition);
			sound.Spawn(Shooter.Level);

			Shooter.HealthManager.TakeHit(this, 5, DamageCause.Fall);

			if (entityCollided != null)
			{
				entityCollided.HealthManager.TakeHit(Shooter, 1, DamageCause.EntityAttack);
			}
		}
	}
}
