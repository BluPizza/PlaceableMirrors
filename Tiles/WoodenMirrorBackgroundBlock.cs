using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Tiles
{
	public class WoodenMirrorBackgroundBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.AllBlocksWithSmoothBordersToResolveHalfBlockIssue[Type] = true;
			TileID.Sets.GemsparkFramingTypes[Type] = (ushort) ModContent.TileType<Tiles.WoodenMirrorBlock>();

			DustType = 7;
			ItemDrop = ModContent.ItemType<Items.WoodenMirrorBackgroundBlock>();

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.WoodenMirrorBackgroundBlock}");
			AddMapEntry(new Color(188, 211, 208), name);
		}

		public override bool TileFrame(int x, int y, ref bool resetFrame, ref bool noBreak)
		{
			Framing.SelfFrame8Way(x, y, Main.tile[x, y], resetFrame);
			return false;
		}
	}
}