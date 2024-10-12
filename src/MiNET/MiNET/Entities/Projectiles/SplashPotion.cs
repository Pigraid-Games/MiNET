using MiNET.Effects;
using MiNET.Particles;
using MiNET.Sounds;
using MiNET.Worlds;

namespace MiNET.Entities.Projectiles
{
	public class SplashPotion : Projectile
	{
		public readonly PotionType.PotionTypeEnum PotionType;

		public SplashPotion(Player shooter, Level level, PotionType.PotionTypeEnum potionType) : base(shooter, EntityType.ThrownSpashPotion, level, 0)
		{
			Width = 0.25;
			Length = 0.25;
			Height = 0.25;

			Gravity = 0.15;
			Drag = 0.25;

			Damage = -1;
			HealthManager.IsInvulnerable = true;
			DespawnOnImpact = true;
			BroadcastMovement = true;
			PotionType = potionType;
		}

		public override void DespawnEntity()
		{
			var sound = new Sound((short) LevelSoundEventType.Glass, KnownPosition);
			sound.Spawn(Shooter.Level);

			float minX = KnownPosition.X - 1;
			float maxX = KnownPosition.X + 1;
			float minY = KnownPosition.Y - 1;
			float maxY = KnownPosition.Y + 1;
			float minZ = KnownPosition.Z - 1;
			float maxZ = KnownPosition.Z + 1;

			foreach (Player player in Level.Players.Values)
			{
				var playerPos = player.KnownPosition;

				if (playerPos.X >= minX && playerPos.X <= maxX &&
					playerPos.Y >= minY && playerPos.Y <= maxY &&
					playerPos.Z >= minZ && playerPos.Z <= maxZ)
				{
					ApplyEffect(player);
				}
			}
			// Later will spawn depending on the color of the potion.
			var particle = new SplashPotionParticle(Level, KnownPosition, 0, 0, 255);
			particle.Spawn();

			base.DespawnEntity();
		}

		protected void ApplyEffect(Entity entity)
		{
			var player = entity as Player;
			// Players have 200 health points
			// 20 ticks for 1 sec
			switch (PotionType)
			{
				case Entities.PotionType.PotionTypeEnum.NightVision:
					if (player is null)
						return;
					Effect nightVisionEffect = new NightVision
					{
						Duration = 2580, // 2.15 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(nightVisionEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongNightVision:
					if (player is null)
						return;
					Effect longNightVisionEffect = new NightVision
					{
						Duration = 7200, // 6.00 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longNightVisionEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.Invisibility:
					if (player is null)
						return;
					Effect invisibilityEffect = new Invisibility
					{
						Duration = 2580, // 2.15 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(invisibilityEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongInvisibility:
					if (player is null)
						return;
					Effect longInvisibilityEffect = new Invisibility
					{
						Duration = 7200, // 6.00 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longInvisibilityEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.Leaping:
					// TODO: Need to implement the Leaping effect
					break;
				case Entities.PotionType.PotionTypeEnum.LongLeaping:
					// TODO: Need to implement the Leaping effect
					break;
				// case PotionTypeEnum.StrongLeaping: break;
				case Entities.PotionType.PotionTypeEnum.FireResistance:
					if (player is null)
						return;
					Effect fireResistanceEffect = new FireResistance
					{
						Duration = 2580, // 2.15 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(fireResistanceEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongFireResistance:
					if (player is null)
						return;
					Effect longFireResistanceEffect = new FireResistance
					{
						Duration = 7200, // 6.00 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longFireResistanceEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.Swiftness:
					if (player is null)
						return;
					// TODO: Need to implement swiftness effect
					break;
				case Entities.PotionType.PotionTypeEnum.LongSwiftness:
					if (player is null)
						return;
					// TODO: Need to implement swiftness effect
					break;
				case Entities.PotionType.PotionTypeEnum.StrongSwiftness:
					if (player is null)
						return;
					// TODO: Need to implement swiftness effect
					break;
				case Entities.PotionType.PotionTypeEnum.Slowness:
					if (player is null)
						return;
					Effect slownessEffect = new Slowness
					{
						Duration = 1284, // 1.07 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(slownessEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongSlowness:
					if (player is null)
						return;
					Effect longSlownessEffect = new Slowness
					{
						Duration = 3600, // 3.00 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longSlownessEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.WaterBreathing:
					if (player is null)
						return;
					Effect waterBreathingEffect = new WaterBreathing
					{
						Duration = 2580, // 2.15 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(waterBreathingEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongWaterBreathing:
					if (player is null)
						return;
					Effect longWaterBreathingEffect = new WaterBreathing
					{
						Duration = 7200, // 6.00 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longWaterBreathingEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.Healing:
					if (entity.HealthManager.Health + 40 >= entity.HealthManager.MaxHealth)
					{
						entity.HealthManager.Health = entity.HealthManager.MaxHealth;
					}
					else
					{
						entity.HealthManager.Health += 40;
					}
					player?.SendUpdateAttributes();
					break;
				case Entities.PotionType.PotionTypeEnum.StrongHealing:
					if (entity.HealthManager.Health + 80 >= entity.HealthManager.MaxHealth)
					{
						entity.HealthManager.Health = entity.HealthManager.MaxHealth;
					}
					else
					{
						entity.HealthManager.Health += 80;
					}
					player?.SendUpdateAttributes();
					break;
				case Entities.PotionType.PotionTypeEnum.Harming:
					player.HealthManager.TakeHit(Shooter, 3, DamageCause.Magic);
					break;
				case Entities.PotionType.PotionTypeEnum.StrongHarming:
					player.HealthManager.TakeHit(Shooter, 6, DamageCause.Magic);
					break;
				case Entities.PotionType.PotionTypeEnum.Poison:
					if (player is null)
						return;
					Effect poisonEffect = new Poison
					{
						Duration = 396, // 0.33 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(poisonEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongPoison:
					if (player is null)
						return;
					Effect longPoisonEffect = new Poison
					{
						Duration = 1560, // 1.30 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longPoisonEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.StrongPoison:
					if (player is null)
						return;
					Effect strongPoisonEffect = new Poison
					{
						Duration = 192, // 0.16 mins
						Level = 2,
						Particles = true
					};
					player.SetEffect(strongPoisonEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.Regeneration:
					if (player is null)
						return;
					Effect regenerationEffect = new Regeneration
					{
						Duration = 396, // 0.33 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(regenerationEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongRegeneration:
					if (player is null)
						return;
					Effect longRegenerationEFfect = new Regeneration
					{
						Duration = 1560, // 1.30 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longRegenerationEFfect);
					break;
				case Entities.PotionType.PotionTypeEnum.StrongRegeneration:
					if (player is null)
						return;
					Effect strongRegenerationEffect = new Regeneration
					{
						Duration = 192, // 0.16 mins
						Level = 2,
						Particles = true
					};
					player.SetEffect(strongRegenerationEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.Strength:
					if (entity is null)
						break;
					Effect strengthEffect = new Strength
					{
						Duration = 2580, // 2.15 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(strengthEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongStrength:
					if (player is null)
						return;
					Effect longStrengthEffect = new Strength
					{
						Duration = 7200, // 6.00 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longStrengthEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.StrongStrength:
					if (player is null)
						return;
					Effect strongStrengthEffect = new Strength
					{
						Duration = 1284, // 1.07 mins
						Level = 2,
						Particles = true
					};
					player.SetEffect(strongStrengthEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.Weakness:
					if (player is null)
						return;
					Effect weakness = new Weakness
					{
						Duration = 1284, // 1.07 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(weakness);
					break;
				case Entities.PotionType.PotionTypeEnum.LongWeakness:
					if (player is null)
						return;
					Effect longWeakenss = new Weakness
					{
						Duration = 3600, // 3.00 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longWeakenss);
					break;
				//case PotionTypeEnum.Decay: break;
				case Entities.PotionType.PotionTypeEnum.TurtleMaster:
					if (player is null)
						return;
					Effect turtleMasterEffect = new TurtleMaster
					{
						Duration = 180, // 0.15 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(turtleMasterEffect);
					break;
				case Entities.PotionType.PotionTypeEnum.LongTurtleMaster:
					if (player is null)
						return;
					Effect longTurtleMasterEffect = new TurtleMaster
					{
						Duration = 360, // 0.30 mins
						Level = 1,
						Particles = true
					};
					player.SetEffect(longTurtleMasterEffect);
					break;
				//case PotionTypeEnum.StrongTurtleMaster: break;
				case Entities.PotionType.PotionTypeEnum.SlowFalling:
					if (player is null)
						return;
					// TODO: Implement slow falling
					break;
				case Entities.PotionType.PotionTypeEnum.LongSlowFalling:
					// TODO: Implement slow falling
					break;
			}
		}
	}
}
