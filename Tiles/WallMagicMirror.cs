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
	public class WallMagicMirror : ModTile
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
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.LargeMagicMirror}");
			AddMapEntry(new Color(151, 221, 229), name);

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
			if (Main.rand.NextBool(40) && ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableDustEffects)
			{
				Dust dust = Dust.NewDustDirect(new Vector2(x * 16, y * 16), 16, 16, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
				dust.noGravity = true;
			}
		}

		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableSmartInteractMagicMirror;
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.WallMagicMirror>());
		}

		public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
		{
			r = 0.6f;
			g = 0.9f;
			b = 0.9f;
		}

		public override void MouseOver(int x, int y)
		{
			PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallMagicMirror>());
		}

		public override bool RightClick(int x, int y)
		{
			return PlaceableMirrors.ToSpawn(x, y, 0);
		}
	}
}