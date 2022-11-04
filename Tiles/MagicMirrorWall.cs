using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Tiles
{
	public class MagicMirrorWall : ModWall
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = true;

			DustType = DustID.MagicMirror;
			ItemDrop = ModContent.ItemType<Items.MagicMirrorWall>();

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.MagicMirrorWall}");
			AddMapEntry(new Color(141, 211, 219), name);
		}

		public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
		{
			r = 0.2f;
			g = 0.4f;
			b = 0.5f;
		}
	}
}