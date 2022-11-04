using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace PlaceableMirrors.Tiles
{
	public class SmallConch : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;

			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;

			DustType = 7;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.SmallConch}");
			AddMapEntry(new Color(117, 56, 52), name);

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.CoordinateHeights = new []{18};
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.addTile(Type);
		}

		public override bool Drop(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			int style = tile.TileFrameX / 18;
			if (style == 0)
				Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<Items.SmallMagicConch>());
			else if (style == 1)
				Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<Items.SmallDemonConch>());
			return base.Drop(x, y);
		}
		
		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override void MouseOver(int x, int y)
		{
			int style = Main.tile[x, y].TileFrameX / 18;
			if (style == 0)
				PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.SmallMagicConch>());
			else if (style == 1)
				PlaceableMirrors.MouseOverMirrors(x, y, ModContent.ItemType<Items.SmallDemonConch>());
		}

		public override bool RightClick(int x, int y)
		{
			int style = Main.tile[x, y].TileFrameX / 18;
			if (style == 0)
				return PlaceableMirrors.ToOcean(x, y);
			else if (style == 1)
				return PlaceableMirrors.ToUnderworld(x, y);
			else
				return false;
		}
	}
}