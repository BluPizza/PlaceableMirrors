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
	public class ZenithMirror : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileNoAttach[Type] = true;

			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;

			DustType = DustID.Terragrim;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.ZenithMirror}");
			AddMapEntry(new Color(24, 22, 48), name);

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.AnchorWall = ConfigValues.RequireWall;
			TileObjectData.newTile.CoordinateHeights = new []{16, 16, 16};
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.addTile(Type);
		}

		public override void DrawEffects(int x, int y, SpriteBatch sb, ref TileDrawInfo drawData)
		{
			if (Main.rand.NextBool(40) && ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableDustEffects)
			{
				Dust dust = Dust.NewDustDirect(new Vector2(x * 16, y * 16), 16, 16, DustID.Terragrim, 0f, 0f, 150, default, 1.5f);
				dust.noGravity = true;
			}
		}

		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableSmartInteractZenithMirror;
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 48, ModContent.ItemType<Items.ZenithMirror>());
		}

		public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
		{
			r = 0.9f;
			g = 0.8f;
			b = 0.9f;
		}

		public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
		{
			width = 1;
			height = 1;
		}

		public override void MouseOver(int x, int y)
		{
			int tileX = Main.tile[x, y].TileFrameX / 18;
			int tileY = Main.tile[x, y].TileFrameY / 18;

			if (tileX == 0 && tileY == 1 && ConfigValues.ZenithMirrorFunctionWater)
			{
				PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallWaterMirror>());
			}
			else if (tileX == 1 && tileY == 2 && ConfigValues.ZenithMirrorFunctionLava)
			{
				PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallLavaMirror>());
			}
			else if (tileX == 2 && tileY == 2 && ConfigValues.ZenithMirrorFunctionTeleportation)
			{
				if (!ConfigValues.OldRecipeZenith)
					PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallTeleportationMirror>());
				else
					PlaceableMirrors.MouseOverMirrors(x, y, ItemID.TeleportationPotion);
			}
			else if (tileX == 0 && tileY == 2 && ConfigValues.ZenithMirrorFunctionWormhole)
			{
				if (!ConfigValues.OldRecipeZenith)
					PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallWormholeMirror>());
				else
					PlaceableMirrors.MouseOverMirrors(x, y, ItemID.WormholePotion);
				
			}
			else if (tileX == 2 && tileY == 1 && ConfigValues.ZenithMirrorFunctionReturn)
			{
				PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallReturnMirror>());
			}
			else if (tileX == 1 && tileY == 1 && (ConfigValues.ZenithMirrorFunctionMagic || ConfigValues.ZenithMirrorFunctionUltimate))
			{
				if (!ConfigValues.OldRecipeZenith)
					PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.CopperWallMirror>());
				else if (!ConfigValues.AltRecipeZenith)
					PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.TerraMirror>());
				else
					PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallMagicMirror>());
			}
			else if (ConfigValues.ZenithMirrorFunctionMagic)
			{
				if (!ConfigValues.AltRecipeZenith)
					PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.TerraMirror>());
				else
					PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallMagicMirror>());
			}
		}

		public override bool RightClick(int x, int y)
		{
			int tileX = Main.tile[x, y].TileFrameX / 18;
			int tileY = Main.tile[x, y].TileFrameY / 18;

			if (tileX == 0 && tileY == 1 && ConfigValues.ZenithMirrorFunctionWater)
			{
				return PlaceableMirrors.ToOcean(x, y);
			}
			else if (tileX == 1 && tileY == 2 && ConfigValues.ZenithMirrorFunctionLava)
			{
				return PlaceableMirrors.ToUnderworld(x, y);
			}
			else if (tileX == 2 && tileY == 2 && ConfigValues.ZenithMirrorFunctionTeleportation)
			{
				return PlaceableMirrors.ToRandom(x, y);
			}
			else if (tileX == 0 && tileY == 2 && ConfigValues.ZenithMirrorFunctionWormhole)
			{
				return PlaceableMirrors.ToPlayer(x, y);
			}
			else if (tileX == 2 && tileY == 1 && ConfigValues.ZenithMirrorFunctionReturn)
			{
				return PlaceableMirrors.ToSpawnAndBack(x, y);
			}
			else if (tileX == 1 && tileY == 1 && ConfigValues.ZenithMirrorFunctionUltimate)
			{
				return PlaceableMirrors.ToAnywhere(x, y);
			}
			else if (ConfigValues.ZenithMirrorFunctionMagic)
			{
				return PlaceableMirrors.ToSpawn(x, y, 2);
			}
			else
				return false;
		}
	}
}