﻿#region LICENSE

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
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2020 Niclas Olofsson.
// All Rights Reserved.

#endregion

using System.Numerics;
using MiNET.Blocks;
using MiNET.Utils;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Items
{
	//A door specifies its hinge side in the block data of its upper block, 
	// and its facing and opened status in the block data of its lower block
	public abstract class ItemDoorBase : ItemBlock
	{
		public ItemDoorBase() : base()
		{
		}

		public override bool PlaceBlock(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoords)
		{
			//TODO - should move to the DoorBase

			var direction = player.KnownPosition.GetDirection().Opposite();

			var coordinates = GetNewCoordinatesFromFace(blockCoordinates, face);

			// Base block, meta sets orientation
			DoorBase block = BlockFactory.GetBlockById<DoorBase>(Id);
			block.Coordinates = coordinates;
			block.Direction = direction;
			block.UpperBlockBit = false;

			int x = blockCoordinates.X;
			int y = blockCoordinates.Y;
			int z = blockCoordinates.Z;

			int xd = 0;
			int zd = 0;

			if (direction == Direction.East) zd = 1;
			else if (direction == Direction.South) xd = -1;
			else if (direction == Direction.West) zd = -1;
			else if (direction == Direction.North) xd = 1;

			int i1 = (world.GetBlock(x - xd, y, z - zd).IsSolid ? 1 : 0) + (world.GetBlock(x - xd, y + 1, z - zd).IsSolid ? 1 : 0);
			int j1 = (world.GetBlock(x + xd, y, z + zd).IsSolid ? 1 : 0) + (world.GetBlock(x + xd, y + 1, z + zd).IsSolid ? 1 : 0);
			bool flag = world.GetBlock(x - xd, y, z - zd).Id == block.Id || world.GetBlock(x - xd, y + 1, z - zd).Id == block.Id;
			bool flag1 = world.GetBlock(x + xd, y, z + zd).Id == block.Id || world.GetBlock(x + xd, y + 1, z + zd).Id == block.Id;
			bool flag2 = false;

			if (flag && !flag1)
			{
				flag2 = true;
			}
			else if (j1 > i1)
			{
				flag2 = true;
			}

			if (!block.CanPlace(world, player, blockCoordinates, face)) return false;

			block.DoorHingeBit = flag2;

			// The upper door block, meta marks upper and
			// sets orientation based on adjacent blocks
			var blockUpper = BlockFactory.GetBlockById<DoorBase>(Id);
			blockUpper.Coordinates = coordinates.BlockUp();
			blockUpper.Direction = direction;
			blockUpper.UpperBlockBit = true;
			blockUpper.DoorHingeBit = flag2;

			world.SetBlock(block);
			world.SetBlock(blockUpper);

			if (player.GameMode == GameMode.Survival)
			{
				var itemInHand = player.Inventory.GetItemInHand();
				itemInHand.Count--;
				player.Inventory.SetInventorySlot(player.Inventory.InHandSlot, itemInHand);
			}

			return true;
		}
	}
}