using System.Drawing;

namespace MiNET.Effects
{
	public class TurtleMaster : Effect
	{
		public TurtleMaster() : base(EffectType.TurtleMaster)
		{
			ParticleColor = Color.FromArgb(0xF8, 0x24, 0x23);
		}

		public override void SendAdd(Player player)
		{
			Effect slownessEffect = new Slowness
			{
				Duration = Duration,
				Level = Level + 3,
				Particles = false
			};
			Effect resistanceEffect = new Resistance
			{
				Duration = Duration,
				Level = Level + 2,
				Particles = false
			};
			player.SetEffect(slownessEffect);
			player.SetEffect(resistanceEffect);

			base.SendAdd(player);
		}

		public override void SendUpdate(Player player)
		{
			base.SendAdd(player);
		}

		public override void SendRemove(Player player)
		{
			base.SendRemove(player);
		}
	}
}
