using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace PlaceableMirrors.Tiles
{
	public class MagicMirrorPlatform : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileTable[Type] = true;

			TileID.Sets.Platforms[Type] = true;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);

			DustType = DustID.MagicMirror;
			ItemDrop = ModContent.ItemType<Items.MagicMirrorPlatform>();

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.MagicMirrorPlatform}");
			AddMapEntry(new Color(141, 211, 219), name);

			TileObjectData.newTile.CoordinateHeights = new[] {16};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleMultiplier = 27;
			TileObjectData.addTile(Type);
		}

		public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
		{
			r = 0.2f;
			g = 0.4f;
			b = 0.5f;
		}
	}
}