using MiNET.Worlds.Utils;

namespace MiNET.Worlds.Anvil
{
	public class AnvilDataUtils
	{
		public static void ReadAnyBitLengthShortFromLongs(long[] longs, short[] shorts, byte shortSize)
		{
			var longBitSize = sizeof(long) * 8;
			var valueBits = (1 << shortSize) - 1;

			var shortsInLongCount = longBitSize / shortSize;

			for (var i = 0; i < shorts.Length; i++)
			{
				var offset = i % shortsInLongCount * shortSize;
				var longsOffset = i / shortsInLongCount;

				shorts[i] = (short) (longs[longsOffset] >> offset & valueBits);
			}
		}

		public static void ReadAnvilPalettedContainerData(long[] longWords, PalettedContainerData data, byte longBlockSize)
		{
			var blockSize = data.DataProfile.BlockSize;
			var blockMask = (1 << longBlockSize) - 1;
			var blocksPerWord = data.DataProfile.BlocksPerWord;
			var blocksCount = data.BlocksCount;
			var words = data.Data;

			var longWordSize = sizeof(long) * 8;
			var blocksPerLongWord = longWordSize / longBlockSize;

			for (var i = 0; i != blocksCount; i++)
			{
				var index = (i & 0x0F0 | i >> 8 | i << 8) & 0xFFF;
				ref var word = ref words[index / blocksPerWord];

				var longShift = i % blocksPerLongWord * longBlockSize;
				var shift = index % blocksPerWord * blockSize;
				word |= (int) (longWords[i / blocksPerLongWord] >> longShift & blockMask) << shift;
			}
		}

		public static void ReadAnyBitLengthShortFromLongs(long[] longs, byte[] shorts, byte shortSize)
		{
			var longBitSize = sizeof(long) * 8;
			var valueBits = (1 << shortSize) - 1;

			var shortsInLongCount = longBitSize / shortSize;

			for (var i = 0; i < shorts.Length; i++)
			{
				var offset = i % shortsInLongCount * shortSize;
				var longsOffset = i / shortsInLongCount;

				shorts[i] = (byte) (longs[longsOffset] >> offset & valueBits);
			}
		}
	}
}
