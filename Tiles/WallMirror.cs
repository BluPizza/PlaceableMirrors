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
	public class WallMirror : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;

			TileID.Sets.FramesOnKillWall[Type] = true;

			DustType = 7;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.WallMirror}");
			AddMapEntry(new Color(198, 221, 218), name);

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.AnchorWall = ConfigValues.RequireWall;
			TileObjectData.newTile.CoordinateHeights = new []{16, 16, 16};
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(ConfigValues.OriginX, ConfigValues.OriginY);
			TileObjectData.addTile(Type);
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
			int item = 0;
			switch (frameX / 36)
			{
				case 0:
					item = ModContent.ItemType<Items.WoodenWallMirror>();
					break;
				case 1:
					item = ModContent.ItemType<Items.EbonwoodWallMirror>();
					break;
				case 2:
					item = ModContent.ItemType<Items.RichMahoganyWallMirror>();
					break;
				case 3:
					item = ModContent.ItemType<Items.PearlwoodWallMirror>();
					break;
				case 4:
					item = ModContent.ItemType<Items.CactusWallMirror>();
					break;
				case 5:
					item = ModContent.ItemType<Items.FleshWallMirror>();
					break;
				case 6:
					item = ModContent.ItemType<Items.MushroomWallMirror>();
					break;
				case 7:
					item = ModContent.ItemType<Items.LivingWoodWallMirror>();
					break;
				case 8:
					item = ModContent.ItemType<Items.BoneWallMirror>();
					break;
				case 9:
					item = ModContent.ItemType<Items.SkywareWallMirror>();
					break;
				case 10:
					item = ModContent.ItemType<Items.ShadewoodWallMirror>();
					break;
				case 11:
					item = ModContent.ItemType<Items.LihzahrdWallMirror>();
					break;
				case 12:
					item = ModContent.ItemType<Items.BlueDungeonWallMirror>();
					break;
				case 13:
					item = ModContent.ItemType<Items.GreenDungeonWallMirror>();
					break;
				case 14:
					item = ModContent.ItemType<Items.PinkDungeonWallMirror>();
					break;
				case 15:
					item = ModContent.ItemType<Items.ObsidianWallMirror>();
					break;
				case 16:
					item = ModContent.ItemType<Items.GlassWallMirror>();
					break;
				case 17:
					item = ModContent.ItemType<Items.GoldenWallMirror>();
					break;
				case 18:
					item = ModContent.ItemType<Items.HoneyWallMirror>();
					break;
				case 19:
					item = ModContent.ItemType<Items.SteampunkWallMirror>();
					break;
				case 20:
					item = ModContent.ItemType<Items.PumpkinWallMirror>();
					break;
				case 21:
					item = ModContent.ItemType<Items.SpookyWallMirror>();
					break;
				case 22:
					item = ModContent.ItemType<Items.FrozenWallMirror>();
					break;
				case 23:
					item = ModContent.ItemType<Items.DynastyWallMirror>();
					break;
				case 24:
					item = ModContent.ItemType<Items.PalmWoodWallMirror>();
					break;
				case 25:
					item = ModContent.ItemType<Items.BorealWoodWallMirror>();
					break;
				case 26:
					item = ModContent.ItemType<Items.SlimeWallMirror>();
					break;
				case 27:
					item = ModContent.ItemType<Items.MartianWallMirror>();
					break;
				case 28:
					item = ModContent.ItemType<Items.MeteoriteWallMirror>();
					break;
				case 29:
					item = ModContent.ItemType<Items.GraniteWallMirror>();
					break;
				case 30:
					item = ModContent.ItemType<Items.MarbleWallMirror>();
					break;
				case 31:
					item = ModContent.ItemType<Items.CrystalWallMirror>();
					break;
				case 32:
					item = ModContent.ItemType<Items.SpiderWallMirror>();
					break;
				case 33:
					item = ModContent.ItemType<Items.LesionWallMirror>();
					break;
				case 34:
					item = ModContent.ItemType<Items.SolarWallMirror>();
					break;
				case 35:
					item = ModContent.ItemType<Items.VortexWallMirror>();
					break;
				case 36:
					item = ModContent.ItemType<Items.NebulaWallMirror>();
					break;
				case 37:
					item = ModContent.ItemType<Items.StardustWallMirror>();
					break;
				case 38:
					item = ModContent.ItemType<Items.SandstoneWallMirror>();
					break;
				case 39:
					item = ModContent.ItemType<Items.BambooWallMirror>();
					break;
				case 40:
					item = ModContent.ItemType<Items.ReefWallMirror>();
					break;
				case 41:
					item = ModContent.ItemType<Items.BalloonWallMirror>();
					break;
				case 42:
					item = ModContent.ItemType<Items.AshWoodWallMirror>();
					break;
			}
			if (item > 0)
				Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, item);
		}

		public override void PostDraw(int x, int y, SpriteBatch sb)
		{
			PlaceableMirrors.GlowmaskMirror(x, y, sb);
		}
	}
}