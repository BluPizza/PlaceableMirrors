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
	public class ShellMirror : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileNoAttach[Type] = true;

			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;

			DustType = DustID.MagicMirror;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.ShellMirror}");
			AddMapEntry(new Color(3, 168, 137), name);

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.AnchorWall = ConfigValues.RequireWall;
			TileObjectData.newTile.CoordinateHeights = new []{16, 16, 16};
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(ConfigValues.OriginX, ConfigValues.OriginY);
			TileObjectData.addTile(Type);
		}

		public override void DrawEffects(int x, int y, SpriteBatch sb, ref TileDrawInfo drawData)
		{
			if (Main.rand.NextBool(50) && ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableDustEffects)
			{
				Dust dust = Dust.NewDustDirect(new Vector2(x * 16, y * 16), 16, 16, DustID.Water, 0f, 0f, 150, default, 1.5f);
				dust.noGravity = true;
			}
			if (Main.rand.NextBool(50) && ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableDustEffects)
			{
				Dust dust = Dust.NewDustDirect(new Vector2(x * 16, y * 16), 16, 16, DustID.Lava, 0f, 0f, 150, default, 1.5f);
				dust.noGravity = true;
			}
		}

		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableSmartInteractShellMirror;
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 48, ModContent.ItemType<Items.ShellMirror>());
		}

		public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
		{
			r = 0f;
			g = 0.7f;
			b = 0.5f;
		}

		public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
		{
			width = 2;
			height = 1;
		}

		public override void MouseOver(int x, int y)
		{
			int tileX = Main.tile[x, y].TileFrameX / 18;
			int tileY = Main.tile[x, y].TileFrameY / 18;

			if (((tileX == 0 && tileY == 0) || (tileX == 1 && tileY == 0)))
			{
				PlaceableMirrors.MouseOverMirrors(x, y, ItemID.MagicConch);
			}
			else if (((tileX == 0 && tileY == 2) || (tileX == 1 && tileY == 2)))
			{
				PlaceableMirrors.MouseOverMirrors(x, y, ItemID.DemonConch);
			}
			else
			{
				PlaceableMirrors.MouseOverMirrors(x, y, ItemID.MagicMirror);
			}
		}

		public override bool RightClick(int x, int y)
		{
			int tileX = Main.tile[x, y].TileFrameX / 18;
			int tileY = Main.tile[x, y].TileFrameY / 18;

			if (((tileX == 0 && tileY == 0) || (tileX == 1 && tileY == 0)))
			{
				return PlaceableMirrors.ToOcean(x, y);
			}
			else if (((tileX == 0 && tileY == 2) || (tileX == 1 && tileY == 2)))
			{
				return PlaceableMirrors.ToUnderworld(x, y);
			}
			else
			{
				return PlaceableMirrors.ToSpawn(x, y, 0);
			}
		}
	}
}