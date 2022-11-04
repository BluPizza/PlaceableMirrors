using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace PlaceableMirrors.Tiles
{
	public class FunctionalWallMirror : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;

			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;

			DustType = DustID.MagicMirror;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.FunctionalWallMirror}");
			AddMapEntry(new Color(151, 221, 229), name);

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.AnchorWall = ConfigValues.RequireWall;
			TileObjectData.newTile.CoordinateHeights = new []{16, 16, 16};
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(ConfigValues.OriginX, ConfigValues.OriginY);
			TileObjectData.addTile(Type);
		}

		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableSmartInteractFunctionalMirror;
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
			int item = 0;
			switch (frameX / 36)
			{
				case 0:
					item = ModContent.ItemType<Items.FunctionalWoodenWallMirror>();
					break;
				case 1:
					item = ModContent.ItemType<Items.FunctionalEbonwoodWallMirror>();
					break;
				case 2:
					item = ModContent.ItemType<Items.FunctionalRichMahoganyWallMirror>();
					break;
				case 3:
					item = ModContent.ItemType<Items.FunctionalPearlwoodWallMirror>();
					break;
				case 4:
					item = ModContent.ItemType<Items.FunctionalCactusWallMirror>();
					break;
				case 5:
					item = ModContent.ItemType<Items.FunctionalFleshWallMirror>();
					break;
				case 6:
					item = ModContent.ItemType<Items.FunctionalMushroomWallMirror>();
					break;
				case 7:
					item = ModContent.ItemType<Items.FunctionalLivingWoodWallMirror>();
					break;
				case 8:
					item = ModContent.ItemType<Items.FunctionalBoneWallMirror>();
					break;
				case 9:
					item = ModContent.ItemType<Items.FunctionalSkywareWallMirror>();
					break;
				case 10:
					item = ModContent.ItemType<Items.FunctionalShadewoodWallMirror>();
					break;
				case 11:
					item = ModContent.ItemType<Items.FunctionalLihzahrdWallMirror>();
					break;
				case 12:
					item = ModContent.ItemType<Items.FunctionalBlueDungeonWallMirror>();
					break;
				case 13:
					item = ModContent.ItemType<Items.FunctionalGreenDungeonWallMirror>();
					break;
				case 14:
					item = ModContent.ItemType<Items.FunctionalPinkDungeonWallMirror>();
					break;
				case 15:
					item = ModContent.ItemType<Items.FunctionalObsidianWallMirror>();
					break;
				case 16:
					item = ModContent.ItemType<Items.FunctionalGlassWallMirror>();
					break;
				case 17:
					item = ModContent.ItemType<Items.FunctionalGoldenWallMirror>();
					break;
				case 18:
					item = ModContent.ItemType<Items.FunctionalHoneyWallMirror>();
					break;
				case 19:
					item = ModContent.ItemType<Items.FunctionalSteampunkWallMirror>();
					break;
				case 20:
					item = ModContent.ItemType<Items.FunctionalPumpkinWallMirror>();
					break;
				case 21:
					item = ModContent.ItemType<Items.FunctionalSpookyWallMirror>();
					break;
				case 22:
					item = ModContent.ItemType<Items.FunctionalFrozenWallMirror>();
					break;
				case 23:
					item = ModContent.ItemType<Items.FunctionalDynastyWallMirror>();
					break;
				case 24:
					item = ModContent.ItemType<Items.FunctionalPalmWoodWallMirror>();
					break;
				case 25:
					item = ModContent.ItemType<Items.FunctionalBorealWoodWallMirror>();
					break;
				case 26:
					item = ModContent.ItemType<Items.FunctionalSlimeWallMirror>();
					break;
				case 27:
					item = ModContent.ItemType<Items.FunctionalMartianWallMirror>();
					break;
				case 28:
					item = ModContent.ItemType<Items.FunctionalMeteoriteWallMirror>();
					break;
				case 29:
					item = ModContent.ItemType<Items.FunctionalGraniteWallMirror>();
					break;
				case 30:
					item = ModContent.ItemType<Items.FunctionalMarbleWallMirror>();
					break;
				case 31:
					item = ModContent.ItemType<Items.FunctionalCrystalWallMirror>();
					break;
				case 32:
					item = ModContent.ItemType<Items.FunctionalSpiderWallMirror>();
					break;
				case 33:
					item = ModContent.ItemType<Items.FunctionalLesionWallMirror>();
					break;
				case 34:
					item = ModContent.ItemType<Items.FunctionalSolarWallMirror>();
					break;
				case 35:
					item = ModContent.ItemType<Items.FunctionalVortexWallMirror>();
					break;
				case 36:
					item = ModContent.ItemType<Items.FunctionalNebulaWallMirror>();
					break;
				case 37:
					item = ModContent.ItemType<Items.FunctionalStardustWallMirror>();
					break;
				case 38:
					item = ModContent.ItemType<Items.FunctionalSandstoneWallMirror>();
					break;
				case 39:
					item = ModContent.ItemType<Items.FunctionalBambooWallMirror>();
					break;
				case 40:
					item = ModContent.ItemType<Items.FunctionalReefWallMirror>();
					break;
				case 41:
					item = ModContent.ItemType<Items.FunctionalBalloonWallMirror>();
					break;
				case 42:
					item = ModContent.ItemType<Items.FunctionalAshWoodWallMirror>();
					break;
			}
			if (item > 0) {
				Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, item);
			}
		}

		public override void MouseOver(int x, int y)
		{
			PlaceableMirrors.MouseOverMirrors(x, y, ItemID.MagicMirror);
		}

		public override void PostDraw(int x, int y, SpriteBatch sb)
		{
			PlaceableMirrors.GlowmaskMirror(x, y, sb);
		}

		public override bool RightClick(int x, int y)
		{
			return PlaceableMirrors.ToSpawn(x, y, 0);
		}
	}
}