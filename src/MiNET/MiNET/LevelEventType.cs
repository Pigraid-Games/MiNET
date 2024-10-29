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
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2019 Niclas Olofsson.
// All Rights Reserved.

#endregion

namespace MiNET
{
	public enum LevelEventType : short
	{
		Undefined = 0,
		SoundClick = 1000,
		SoundClickFail = 1001,
		SoundLaunch = 1002,
		SoundOpenDoor = 1003,
		SoundFizz = 1004,
		SoundFuse = 1005,
		SoundPlayRecording = 1006,
		SoundGhastWarning = 1007,
		SoundGhastFireball = 1008,
		SoundBlazeFireball = 1009,
		SoundZombieWoodenDoor = 1010,
		SoundZombieDoorCrash = 1012,
		SoundZombieInfected = 1016,
		SoundZombieConverted = 1017,
		SoundEndermanTeleport = 1018,
		SoundAnvilBroken = 1020,
		SoundAnvilUsed = 1021,
		SoundAnvilLand = 1022,
		SoundInfinityArrowPickup = 1030,
		SoundTeleportEnderPearl = 1032,
		SoundAddItem = 1040,
		SoundItemFrameBreak = 1041,
		SoundItemFramePlace = 1042,
		SoundItemFrameRemoveItem = 1043,
		SoundItemFrameRotateItem = 1044,
		SoundCameraTakePicture = 1050,
		SoundExperienceOrbPickup = 1051,
		SoundTotemUsed = 1052,
		SoundArmorStandBreak = 1060,
		SoundArmorStandHit = 1061,
		SoundArmorStandLand = 1062,
		SoundArmorStandPlace = 1063,
		SoundPointedDripstoneLand = 1064,
		SoundDyeUsed = 1065,
		SoundInkSacUsed = 1066,
		SoundAmethystResonate = 1067,
		QueueCustomMusic = 1900,
		PlayCustomMusic = 1901,
		StopCustomMusic = 1902,
		SetMusicVolume = 1903,
		ParticlesShoot = 2000,
		ParticlesDestroyBlock = 2001,
		ParticlesPotionSplash = 2002,
		ParticlesEyeOfEnderDeath = 2003,
		ParticlesMobBlockSpawn = 2004,
		ParticleCropGrowth = 2005,
		ParticleSoundGuardianGhost = 2006,
		ParticleDeathSmoke = 2007,
		ParticleDenyBlock = 2008,
		ParticleGenericSpawn = 2009,
		ParticlesDragonEgg = 2010,
		ParticlesCropEaten = 2011,
		ParticlesCrit = 2012,
		ParticlesTeleport = 2013,
		ParticlesCrackBlock = 2014,
		ParticlesBubble = 2015,
		ParticlesEvaporate = 2016,
		ParticlesDestroyArmorStand = 2017,
		ParticlesBreakingEgg = 2018,
		ParticleDestroyEgg = 2019,
		ParticlesEvaporateWater = 2020,
		ParticlesDestroyBlockNoSound = 2021,
		ParticlesKnockbackRoar = 2022,
		ParticlesTeleportTrail = 2023,
		ParticlesPointCloud = 2024,
		ParticlesExplosion = 2025,
		ParticlesBlockExplosion = 2026,
		ParticlesVibrationSignal = 2027,
		ParticlesDripstoneDrip = 2028,
		ParticlesFizzEffect = 2029,
		WaxOn = 2030,
		WaxOff = 2031,
		Scrape = 2032,
		ParticlesElectricSpark = 2033,
		ParticleTurtleEgg = 2034,
		ParticlesSculkShriek = 2035,
		SculkCatalystBloom = 2036,
		SculkCharge = 2037,
		SculkChargePop = 2038,
		SonicExplosion = 2039,
		DustPlume = 2040,
		StartRaining = 3001,
		StartThunderstorm = 3002,
		StopRaining = 3003,
		StopThunderstorm = 3004,
		GlobalPause = 3005,
		SimTimeStep = 3006,
		SimTimeScale = 3007,
		ActivateBlock = 3500,
		CauldronExplode = 3501,
		CauldronDyeArmor = 3502,
		CauldronCleanArmor = 3503,
		CauldronFillPotion = 3504,
		CauldronTakePotion = 3505,
		CauldronFillWater = 3506,
		CauldronTakeWater = 3507,
		CauldronAddDye = 3508,
		CauldronCleanBanner = 3509,
		CauldronFlush = 3510,
		AgentSpawnEffect = 3511,
		CauldronFillLava = 3512,
		CauldronTakeLava = 3513,
		CauldronFillPowderSnow = 3514,
		CauldronTakePowderSnow = 3515,
		StartBlockCracking = 3600,
		StopBlockCracking = 3601,
		UpdateBlockCracking = 3602,
		ParticlesCrackBlockDown = 3603,
		ParticlesCrackBlockUp = 3604,
		ParticlesCrackBlockNorth = 3605,
		ParticlesCrackBlockSouth = 3606,
		ParticlesCrackBlockWest = 3607,
		ParticlesCrackBlockEast = 3608,
		ParticlesShootWhiteSmoke = 3609,
		ParticlesBreezeWindExplosion = 3610,
		ParticlesTrialSpawnerDetection = 3611,
		ParticlesTrialSpawnerSpawning = 3612,
		ParticlesTrialSpawnerEjecting = 3613,
		ParticlesWindExplosion = 3614,
		ParticlesTrialSpawnerDetectionCharged = 3615,
		ParticlesTrialSpawnerBecomeCharged = 3616,
		AllPlayersSleeping = 3617,
		SleepingPlayers = 9801,
		JumpPrevented = 9810,
		AnimationVaultActivate = 9811,
		AnimationVaultDeactivate = 9812,
		AnimationVaultEjectItem = 9813,
		AnimationSpawnCobweb = 9814,
		ParticleSmashAttackGroundDust = 9815,

		AddParticleMask = 0x4000
	}

	public enum LevelSoundEventType
	{
		ItemUseOn = 0,
		Hit = 1,
		Step = 2,
		Fly = 3,
		Jump = 4,
		Break = 5,
		Place = 6,
		HeavyStep = 7,
		Gallop = 8,
		Fall = 9,
		Ambient = 10,
		AmbientBaby = 11,
		AmbientInWater = 12,
		Breathe = 13,
		Death = 14,
		DeathInWater = 15,
		DeathToZombie = 16,
		Hurt = 17,
		HurtInWater = 18,
		Mad = 19,
		Boost = 20,
		Bow = 21,
		SquishBig = 22,
		SquishSmall = 23,
		FallBig = 24,
		FallSmall = 25,
		Splash = 26,
		Fizz = 27,
		Flap = 28,
		Swim = 29,
		Drink = 30,
		Eat = 31,
		Takeoff = 32,
		Shake = 33,
		Plop = 34,
		Land = 35,
		Saddle = 36,
		Armor = 37,
		ArmorPlace = 38,
		AddChest = 39,
		Throw = 40,
		Attack = 41,
		AttackNoDamage = 42,
		AttackStrong = 43,
		Warn = 44,
		Shear = 45,
		Milk = 46,
		Thunder = 47,
		Explode = 48,
		Fire = 49,
		Ignite = 50,
		Fuse = 51,
		Stare = 52,
		Spawn = 53,
		Shoot = 54,
		BreakBlock = 55,
		Launch = 56,
		Blast = 57,
		LargeBlast = 58,
		Twinkle = 59,
		Remedy = 60,
		Unfect = 61,
		LevelUp = 62,
		BowHit = 63,
		BulletHit = 64, 
		ExtinguishFire = 65,
		ItemFizz = 66,
		ChestOpen = 67,
		ChestClosed = 68,
		ShulkerBoxOpen = 69,
		ShulkerBoxClosed = 70,
		EnderChestOpen = 71,
		EnderChestClosed = 72,
		PowerOn = 73,
		PowerOff = 74,
		Attach = 75,
		Detach = 76,
		Deny = 77,
		Tripod = 78,
		Pop = 79,
		DropSlot = 80,
		Note = 81,
		Thorns = 82,
		PistonIn = 83,
		PistonOut = 84,
		Portal = 85,
		Water = 86,
		LavaPop = 87,
		Lava = 88,
		Burp = 89,
		BucketFillWater = 90,
		BucketFillLava = 91,
		BucketEmptyWater = 92,
		BucketEmptyLava = 93,
		EquipChain = 94,
		EquipDiamond = 95,
		EquipGeneric = 96,
		EquipGold = 97,
		EquipIron = 98,
		EquipLeather = 99,
		EquipElytra = 100,
		Record13 = 101,
		RecordCat = 102,
		RecordBlocks = 103,
		RecordChirp = 104,
		RecordFar = 105,
		RecordMall = 106,
		RecordMellohi = 107,
		RecordStal = 108,
		RecordStrad = 109,
		RecordWard = 110,
		Record11 = 111,
		RecordWait = 112,
		RecordNull = 113,
		Flop = 114,
		GuardianCurse = 115,
		MobWarning = 116,
		MobWarningBaby = 117,
		Teleport = 118,
		ShulkerOpen = 119,
		ShulkerClose = 120,
		Haggle = 121,
		HaggleYes = 122,
		HaggleNo = 123,
		HaggleIdle = 124,
		ChorusGrow = 125,
		ChorusDeath = 126,
		Glass = 127,
		PotionBrewed = 128,
		CastSpell = 129,
		PrepareAttackSpell = 130,
		PrepareSummon = 131,
		PrepareWololo = 132,
		Fang = 133,
		Charge = 134,
		TakePicture = 135,
		PlaceLeashKnot = 136,
		BreakLeashKnot = 137,
		AmbientGrowl = 138,
		AmbientWhine = 139,
		AmbientPant = 140,
		AmbientPurr = 141,
		AmbientPurreow = 142,
		DeathMinVolume = 143,
		DeathMidVolume = 144,
		ImitateBlaze = 145,
		ImitateCaveSpider = 146,
		ImitateCreeper = 147,
		ImitateElderGuardian = 148,
		ImitateEnderDragon = 149,
		ImitateEnderman = 150,
		ImitateEndermite = 151,
		ImitateEvocationIllager = 152,
		ImitateGhast = 153,
		ImitateHusk = 154,
		ImitateIllusionIllager = 155,
		ImitateMagmaCube = 156,
		ImitatePolarBear = 157,
		ImitateShulker = 158,
		ImitateSilverfish = 159,
		ImitateSkeleton = 160,
		ImitateSlime = 161,
		ImitateSpider = 162,
		ImitateStray = 163,
		ImitateVex = 164,
		ImitateVindicationIllager = 165,
		ImitateWitch = 166,
		ImitateWither = 167,
		ImitateWitherSkeleton = 168,
		ImitateWolf = 169,
		ImitateZombie = 170,
		ImitateZombiePigman = 171,
		ImitateZombieVillager = 172,
		EnderEyePlaced = 173,
		EndPortalCreated = 174,
		AnvilUse = 175,
		BottleDragonBreath = 176,
		PortalTravel = 177,
		TridentHit = 178,
		TridentReturn = 179,
		TridentRiptide_1 = 180,
		TridentRiptide_2 = 181,
		TridentRiptide_3 = 182,
		TridentThrow = 183,
		TridentThunder = 184,
		TridentHitGround = 185,
		Default = 186,
		FletchingTableUse = 187,
		ElemConstructOpen = 188,
		IceBombHit = 189,
		BalloonPop = 190,
		LTReactionIceBomb = 191,
		LTReactionBleach = 192,
		LTReactionElephantToothpaste = 193,
		LTReactionElephantToothpaste2 = 194,
		LTReactionGlowStick = 195,
		LTReactionGlowStick2 = 196,
		LTReactionLuminol = 197,
		LTReactionSalt = 198,
		LTReactionFertilizer = 199,
		LTReactionFireball = 200,
		LTReactionMagnesiumSalt = 201,
		LTReactionMiscFire = 202,
		LTReactionFire = 203,
		LTReactionMiscExplosion = 204,
		LTReactionMiscMystical = 205,
		LTReactionMiscMystical2 = 206,
		LTReactionProduct = 207,
		SparklerUse = 208,
		GlowStickUse = 209,
		SparklerActive = 210,
		ConvertToDrowned = 211,
		BucketFillFish = 212,
		BucketEmptyFish = 213,
		BubbleColumnUpwards = 214,
		BubbleColumnDownwards = 215,
		BubblePop = 216,
		BubbleUpInside = 217,
		BubbleDownInside = 218,
		HurtBaby = 219,
		DeathBaby = 220,
		StepBaby = 221,
		SpawnBaby = 222,
		Born = 223,
		TurtleEggBreak = 224,
		TurtleEggCrack = 225,
		TurtleEggHatched = 226,
		LayEgg = 227,
		TurtleEggAttacked = 228,
		BeaconActivate = 229,
		BeaconAmbient = 230,
		BeaconDeactivate = 231,
		BeaconPower = 232,
		ConduitActivate = 233,
		ConduitAmbient = 234,
		ConduitAttack = 235,
		ConduitDeactivate = 236,
		ConduitShort = 237,
		Swoop = 238,
		BambooSaplingPlace = 239,
		PreSneeze = 240,
		Sneeze = 241,
		AmbientTame = 242,
		Scared = 243,
		ScaffoldingClimb = 244,
		CrossbowLoadingStart = 245,
		CrossbowLoadingMiddle = 246,
		CrossbowLoadingEnd = 247,
		CrossbowShoot = 248,
		CrossbowQuickChargeStart = 249,
		CrossbowQuickChargeMiddle = 250,
		CrossbowQuickChargeEnd = 251,
		AmbientAggressive = 252,
		AmbientWorried = 253,
		CantBreed = 254,
		ShieldBlock = 255,
		LecternBookPlace = 256,
		GrindstoneUse = 257,
		Bell = 258,
		CampfireCrackle = 259,
		Roar = 260,
		Stun = 261,
		SweetBerryBushHurt = 262,
		SweetBerryBushPick = 263,
		CartographyTableUse = 264,
		StonecutterUse = 265,
		ComposterEmpty = 266,
		ComposterFill = 267,
		ComposterFillLayer = 268,
		ComposterReady = 269,
		BarrelOpen = 270,
		BarrelClose = 271,
		RaidHorn = 272,
		LoomUse = 273,
		AmbientInRaid = 274,
		UICartographyTableUse = 275,
		UIStonecutterUse = 276,
		UILoomUse = 277,
		SmokerUse = 278,
		BlastFurnaceUse = 279,
		SmithingTableUse = 280,
		Screech = 281,
		Sleep = 282,
		FurnaceUse = 283,
		MooshroomConvert = 284,
		MilkSuspiciously = 285,
		Celebrate = 286,
		JumpPrevent = 287,
		AmbientPollinate = 288,
		BeehiveDrip = 289,
		BeehiveEnter = 290,
		BeehiveExit = 291,
		BeehiveWork = 292,
		BeehiveShear = 293,
		HoneybottleDrink = 294,
		AmbientCave = 295,
		Retreat = 296,
		ConvertToZombified = 297,
		Admire = 298,
		StepLava = 299,
		Tempt = 300,
		Panic = 301,
		Angry = 302,
		AmbientMoodWarpedForest = 303,
		AmbientMoodSoulsandValley = 304,
		AmbientMoodNetherWastes = 305,
		AmbientMoodBasaltDeltas = 306,
		AmbientMoodCrimsonForest = 307,
		RespawnAnchorCharge = 308,
		RespawnAnchorDeplete = 309,
		RespawnAnchorSetSpawn = 310,
		RespawnAnchorAmbient = 311,
		SoulEscapeQuiet = 312,
		SoulEscapeLoud = 313,
		RecordPigstep = 314,
		LinkCompassToLodestone = 315,
		UseSmithingTable = 316,
		EquipNetherite = 317,
		AmbientLoopWarpedForest = 318,
		AmbientLoopSoulsandValley = 319,
		AmbientLoopNetherWastes = 320,
		AmbientLoopBasaltDeltas = 321,
		AmbientLoopCrimsonForest = 322,
		AmbientAdditionWarpedForest = 323,
		AmbientAdditionSoulsandValley = 324,
		AmbientAdditionNetherWastes = 325,
		AmbientAdditionBasaltDeltas = 326,
		AmbientAdditionCrimsonForest = 327,
		SculkSensorPowerOn = 328,
		SculkSensorPowerOff = 329,
		BucketFillPowderSnow = 330,
		BucketEmptyPowderSnow = 331,
		PointedDripstoneCauldronDripWater = 332,
		PointedDripstoneCauldronDripLava = 333,
		PointedDripstoneDripWater = 334,
		PointedDripstoneDripLava = 335,
		CaveVinesPickBerries = 336,
		BigDripleafTiltDown = 337,
		BigDripleafTiltUp = 338,
		CopperWaxOn = 339,
		CopperWaxOff = 340,
		Scrape = 341,
		PlayerHurtDrown = 342,
		PlayerHurtOnFire = 343,
		PlayerHurtFreeze = 344,
		UseSpyglass = 345,
		StopUsingSpyglass = 346,
		AmethystBlockChime = 347,
		AmbientScreamer = 348,
		HurtScreamer = 349,
		DeathScreamer = 350,
		MilkScreamer = 351,
		JumpToBlock = 352,
		PreRam = 353,
		PreRamScreamer = 354,
		RamImpact = 355,
		RamImpactScreamer = 356,
		SquidInkSquirt = 357,
		GlowSquidInkSquirt = 358,
		ConvertToStray = 359,
		CakeAddCandle = 360,
		ExtinguishCandle = 361,
		AmbientCandle = 362,
		BlockClick = 363,
		BlockClickFail = 364,
		SculkCatalystBloom = 365,
		SculkShriekerShriek = 366,
		NearbyClose = 367,
		NearbyCloser = 368,
		NearbyClosest = 369,
		Agitated = 370,
		RecordOtherside = 371,
		Tongue = 372,
		CrackIronGolem = 373,
		RepairIronGolem = 374,
		Listening = 375,
		Heartbeat = 376,
		HornBreak = 377,
		SculkSpread = 379,
		SculkCharge = 380,
		SculkSensorPlace = 381,
		SculkShriekerPlace = 382,
		GoatCall0 = 383,
		GoatCall1 = 384,
		GoatCall2 = 385,
		GoatCall3 = 386,
		GoatCall4 = 387,
		GoatCall5 = 388,
		GoatCall6 = 389,
		GoatCall7 = 390,
		ImitateWarden = 426,
		ListeningAngry = 427,
		Item_Given = 428,
		Item_Taken = 429,
		Disappeared = 430,
		Reappeared = 431,
		DrinkMilk = 432,
		FrogspawnHatched = 433,
		LaySpawn = 434,
		FrogspawnBreak = 435,
		SonicBoom = 436,
		SonicCharge = 437,
		Item_Thrown = 438,
		Record5 = 439,
		ConvertToFrog = 440,
		RecordPlaying = 441,
		EnchantingTableUse = 442,
		StepSand = 443,
		DashReady = 444,
		BundleDropContents = 445,
		BundleInsert = 446,
		BundleRemoveOne = 447,
		PressurePlateClickOff = 448,
		PressurePlateClickOn = 449,
		ButtonClickOff = 450,
		ButtonClickOn = 451,
		DoorOpen = 452,
		DoorClose = 453,
		TrapdoorOpen = 454,
		TrapdoorClose = 455,
		FenceGateOpen = 456,
		FenceGateClose = 457,
		Insert = 458,
		Pickup = 459,
		InsertEnchanted = 460,
		PickupEnchanted = 461,
		Brush = 462,
		BrushCompleted = 463,
		ShatterDecoratedPot = 464,
		BreakDecoratedPot = 465,
		SnifferEggCrack = 466,
		SnifferEggHatched = 467,
		WaxedSignInteractFail = 468,
		RecordRelic = 469,
		Bump = 470,
		PumpkinCarve = 471,
		ConvertHuskToZombie = 472,
		PigDeath = 473,
		HoglinConvertToZombified = 474,
		AmbientUnderwaterEnter = 475,
		AmbientUnderwaterExit = 476,
		BottleFill = 477,
		BottleEmpty = 478,
		CrafterCraft = 479,
		CrafterFail = 480,
		DecoratedPotInsert = 481,
		DecoratedPotInsertFail = 482,
		CrafterDisableSlot = 483,
		CopperBulbTurnOn = 490,
		CopperBulbTurnOff = 491,
		AmbientInAir = 492,
		BreezeWindChargeBurst = 493,
		ImitateBreeze = 494,
		MobArmadilloBrush = 495,
		MobArmadilloScuteDrop = 496,
		ArmorEquipWolf = 497,
		ArmorUnequipWolf = 498,
		Reflect = 499,
		VaultOpenShutter = 500,
		VaultCloseShutter = 501,
		VaultEjectItem = 502,
		VaultInsertItem = 503,
		VaultInsertItemFail = 504,
		VaultAmbient = 505,
		VaultActivate = 506,
		VaultDeactivate = 507,
		HurtReduced = 508,
		WindChargeBurst = 509,
		ImitateBogged = 510,
		ArmorCrackWolf = 511,
		ArmorBreakWolf = 512,
		ArmorRepairWolf = 513,
		MaceSmashAir = 514,
		MaceSmashGround = 515,
		TrialSpawnerChargeActivate = 516,
		TrialSpawnerAmbientOminous = 517,
		OminousItemSpawnerSpawnItem = 518,
		OminousBottleEndUse = 519,
		MaceHeavySmashGround = 520,
		OminousItemSpawnerSpawnItemBegin = 521,
		ApplyEffectBadOmen = 523,
		ApplyEffectRaidOmen = 524,
		ApplyEffectTrialOmen = 525,
		OminousItemSpawnerAboutToSpawnItem = 526,
		RecordCreator = 527,
		RecordCreatorMusicBox = 528,
		RecordPrecipice = 529,
		VaultRejectRewardedPlayer = 530
	}
}