﻿using System.Collections.Generic;

namespace MiNET.Net
{
	public class Experiments : List<Experiment>, IPacketDataObject
	{
		public bool WereAnyExperimentsAnyToggled { get; set; }

		public void Write(Packet packet)
		{
			packet.Write((uint)Count);

			foreach (var experiment in this)
			{
				packet.Write(experiment);
			}

			packet.Write(WereAnyExperimentsAnyToggled);
		}

		public static Experiments Read(Packet packet)
		{
			var experiments = new Experiments();
			var count = packet.ReadUint();

			for (var i = 0; i < count; i++)
			{
				experiments.Add(Experiment.Read(packet));
			}

			experiments.WereAnyExperimentsAnyToggled = packet.ReadBool();

			return experiments;
		}
	}

	public class Experiment : IPacketDataObject
	{
		public string Name { get; }

		public bool Enabled { get; }

		public Experiment(string name, bool enabled)
		{
			Name = name;
			Enabled = enabled;
		}

		public void Write(Packet packet)
		{
			packet.Write(Name);
			packet.Write(Enabled);
		}

		public static Experiment Read(Packet packet)
		{
			var name = packet.ReadString();
			var enabled = packet.ReadBool();

			return new Experiment(name, enabled);
		}
	}
}