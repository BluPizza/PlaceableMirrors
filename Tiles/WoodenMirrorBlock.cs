using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Tiles
{
	public class WoodenMirrorBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileBlockLight[Type] = true;
			Main.tileSolid[Type] = true;

			TileID.Sets.AllBlocksWithSmoothBordersToResolveHalfBlockIssue[Type] = true;
			TileID.Sets.GemsparkFramingTypes[Type] = Type;

			DustType = 7;
			ItemDrop = ModContent.ItemType<Items.WoodenMirrorBlock>();

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.WoodenMirrorBlock}");
			AddMapEntry(new Color(198, 221, 218), name);
		}

		public override bool TileFrame(int x, int y, ref bool resetFrame, ref bool noBreak)
		{
			Framing.SelfFrame8Way(x, y, Main.tile[x, y], resetFrame);
			return false;
		}
	}
}