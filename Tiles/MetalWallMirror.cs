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
	public class MetalWallMirror : ModTile
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
					item = ModContent.ItemType<Items.CopperWallMirror>();
					break;
				case 16:
					item = ModContent.ItemType<Items.AdamantiteWallMirror>();
					break;
			}
			if (item > 0)
				Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, item);
		}
	}
}