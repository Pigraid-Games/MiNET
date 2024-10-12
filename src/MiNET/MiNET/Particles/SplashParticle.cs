#region LICENSE

// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE. 
// The License is based on the Mozilla Public License Version 1.1, but Sections 14 
// and 15 have been added to cover use of software over a computer network and 
// provide for limited attribution for the Original Developer. In addition, Exhibit A has 
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2018 Niclas Olofsson. 
// All Rights Reserved.

#endregion

using System;
using System.Numerics;
using MiNET.Net;
using MiNET.Worlds;

namespace MiNET.Particles
{
	public class SplashPotionParticle : LegacyParticle
	{
		public SplashPotionParticle(Level level, Vector3 coordinates, int r, int g, int b) : base(ParticleType.Splash, level)
		{
			Data = CustomPotionColor(r, g, b);
			Position = coordinates;
		}

		public override void Spawn()
		{
			McpeLevelEvent particleEvent = McpeLevelEvent.CreateObject();
			particleEvent.eventId = (int) LevelEventType.ParticlesPotionSplash;
			particleEvent.position = Position;
			particleEvent.data = Data;
			Level.RelayBroadcast(particleEvent);
		}

		public static int CustomPotionColor(int red, int green, int blue)
		{
			red = Math.Clamp(red, 0, 255);
			green = Math.Clamp(green, 0, 255);
			blue = Math.Clamp(blue, 0, 255);

			int colorCode = (red << 16) + (green << 8) + blue;

			if (colorCode > 0x00FFFFFF)
			{
				colorCode &= 0x00FFFFFF;
			}

			return colorCode;
		}
	}
}