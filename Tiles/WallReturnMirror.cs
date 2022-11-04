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
	public class WallReturnMirror : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileNoAttach[Type] = true;

			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;

			DustType = DustID.GemAmethyst;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.ReturnMirror}");
			AddMapEntry(new Color(196, 159, 219), name);

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
				Dust dust = Dust.NewDustDirect(new Vector2(x * 16, y * 16), 16, 16, DustID.GemAmethyst, 0f, 0f, 150, default, 1.2f);
				dust.noGravity = true;
			}
			if (Main.rand.NextBool(50) && ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableDustEffects)
			{
				Dust dust2 = Dust.NewDustDirect(new Vector2(x * 16, y * 16), 16, 16, DustID.GemSapphire, 0f, 0f, 150, default, 1.2f);
				dust2.noGravity = true;
			}
		}

		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return ModContent.GetInstance<PlaceableMirrorsClientConfig>().EnableSmartInteractReturnMirror;
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.WallReturnMirror>());
		}

		public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
		{
			r = 0.8f;
			g = 0.6f;
			b = 0.9f;
		}

		public override void MouseOver(int x, int y)
		{
			PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.WallReturnMirror>()); 
		}

		public override bool RightClick(int x, int y)
		{
			return PlaceableMirrors.ToSpawnAndBack(x, y);
		}
	}
}